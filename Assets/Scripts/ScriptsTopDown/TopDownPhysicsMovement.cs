using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // para poder usar texto

public class TopDownPhysicsMovement : AButtonPressed
{
	Rigidbody2D rb;
	public Text scoreText;

    public GameObject prefab;

	int score;

	public override void DownPressed()
	{
		rb.AddForce(transform.up * -1f);
	}

	public override void LeftPressed()
	{
		rb.AddForce(transform.right * -1f);
	}

	public override void RightPressed()
	{
		rb.AddForce(transform.right);
	}

	public override void UpPressed()
	{
		rb.AddForce(transform.up);
	}

    public override void SpacePressed()
    {
        Debug.Log("espacio");
        Shoot();
    }

    public void Shoot()
    {
        GameObject clone = Instantiate(prefab, transform.position, Quaternion.identity);
        Rigidbody2D clonerb = clone.GetComponent<Rigidbody2D>();
        clonerb.velocity = new Vector3(3, 0, 0);

        // Debug.Log(clone);
        // Debug.Log(clonerb);

        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Debug.DrawRay(ray.direction, ray.origin);
        // Debug.Log(ray);
        // if (Physics.Raycast(ray))
        // {
        //     Debug.Log("el rayo colisionó!!! bien!!!");
        // }
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = 0;

        Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        PressSpace();
    }

    private void FixedUpdate()
    {
    	PressRight();
    	PressLeft();
    	PressUp();
    	PressDown();
    }

    // Esta funcion es parecida a OnCollisionEnter2D, pero no genera reacciones fisicas,
    // solo detecta la colision, los objetos van a atravesarse entre sí
    // para poder usarla, el Collider contra el que se colisiona tiene que estar
    // marcado como Is Trigger en el inspector
    private void OnTriggerEnter2D(Collider2D collision)
    {
    	if (collision.gameObject.tag == "Item")
    	{
    		// Acá el item se destruye al contacto sin hacer nada mas
    		// si el item da puntos, municion, etc aca se puede poner que aumente 
    		// el valor de una variable o algo asi
    		score += 10;
    		scoreText.text = "Score: " + score.ToString();

    		Destroy(collision.gameObject);

    		Debug.Log(score);
    	}
    }

    // esta funcion la llama Unity directamente cuando hay una colision con el objeto con la "tag" asignada en el inspector
    // no se llama en start ni en update, solo se declara dentro del script y listo.
    private void OnCollisionEnter2D(Collision2D collision)
    {
    	Debug.Log("collision");
    }
}
