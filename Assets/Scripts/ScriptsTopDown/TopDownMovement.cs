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

	public override void DownPressed()
	{
		tfm.Translate(new Vector3(0, -currentSpeed, 0) * Time.deltaTime);
	}

	public override void UpPressed()
	{
		tfm.Translate(new Vector3(0, currentSpeed, 0) * Time.deltaTime);
	}

	public override void LeftPressed()
	{
		tfm.Translate(new Vector3(-currentSpeed, 0, 0) * Time.deltaTime);
	}

	public override void RightPressed()
	{
		tfm.Translate(new Vector3(currentSpeed, 0, 0) * Time.deltaTime);
	}

	public override void SpacePressed()
	{
		// Al pulsar espacio cambiar la velocidad
		currentSpeed = focusSpeed;
	}

    // Start is called before the first frame update
    void Start()
    {
        tfm = GetComponent<Transform>();
        currentSpeed = speed;
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

    }
}
