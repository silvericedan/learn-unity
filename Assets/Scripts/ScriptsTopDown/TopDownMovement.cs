using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : AButtonPressed
{

	private Transform tfm;

	// Hay 2 velocidades declaradas
	// Al pulsar barra espaciadora alterna entre las 2
	private float speed = 12;
	private float focusSpeed = 4;
	private float currentSpeed;

	// Distancia maxima a la que se puede mover el jugador desde el centro, en unidades
	// Para que la distancia sea siempre la misma, el tamaño de la ventana tiene que estar
	// configurado en Edit / Project Settings
	private float horizontalLimit;
	private float verticalLimit;

	public GameObject bullet;

	private float shootIntervalTime = 0.2f;
	public float timer = 0.00f;
	public bool canShoot = true;

	public override void DownPressed()
	{
		if (tfm.position.y > -verticalLimit)
		{
			tfm.Translate(new Vector3(0, -currentSpeed, 0) * Time.deltaTime);
		}
	}

	public override void UpPressed()
	{
		if (tfm.position.y < verticalLimit)
		{
			tfm.Translate(new Vector3(0, currentSpeed, 0) * Time.deltaTime);
		}
	}

	public override void LeftPressed()
	{
		if (tfm.position.x > -horizontalLimit)
		{
			tfm.Translate(new Vector3(-currentSpeed, 0, 0) * Time.deltaTime);
		}
	}

	public override void RightPressed()
	{
		if (tfm.position.x < horizontalLimit)
		{
			tfm.Translate(new Vector3(currentSpeed, 0, 0) * Time.deltaTime);
		}
	}

	public override void SpacePressed()
	{
		// Al pulsar espacio cambiar la velocidad
		currentSpeed = focusSpeed;

		Shoot();
	}

	public void Shoot()
    {
    	if (canShoot)
    	{
	        GameObject clone = Instantiate(bullet, transform.position, Quaternion.identity);
	        Rigidbody2D clonerb = clone.GetComponent<Rigidbody2D>();
	        clonerb.velocity = new Vector3(0, 10, 0);
	        clonerb.transform.localScale = new Vector3(5, 5, 5);

	        canShoot = false;
	        timer = shootIntervalTime;
    	}
    }

    // Start is called before the first frame update
    void Start()
    {
        tfm = GetComponent<Transform>();
        currentSpeed = speed;

        // Obtener la coordenada de la esquina superior derecha, relativa a la camara
        // y obtener la coordenada equivalente del mundo
        // Esto funciona porque la camara está fija, si la camara se moviera o siguiera
        // al jugador, esto va a dar cualquier cosa
        Vector2 topRightCorner = new Vector2(1, 1);
     	Vector2 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner);

     	// En base a eso, obtener la distancia maxima de movimiento
     	horizontalLimit = edgeVector.x;
     	verticalLimit = edgeVector.y;

     	Debug.Log(horizontalLimit);
     	Debug.Log(verticalLimit);
    }

    // Update is called once per frame
    void Update()
    {
        PressUp();
        PressDown();
        PressLeft();
        PressRight();
        PressSpace();

        // Al soltar espacio volver a la velocidad normal
        // Esta hecho aca porque la abstracta no tiene metodos KeyUp
        if (Input.GetKeyUp(KeyCode.Space))
        {
        	currentSpeed = speed;
        }

        if (timer <= 0.00f)
        {
        	canShoot = true;
        }
        else
        {
        	timer -= Time.deltaTime;	
        }

    }
}
