using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPhysicsMovement : AButtonPressed
{
	Rigidbody2D rb;

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


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    		Debug.Log("activaste el trigger de un item");

    		// Acá el item se destruye al contacto sin hacer nada mas
    		// si el item da puntos, municion, etc aca se puede poner que aumente 
    		// el valor de una variable o algo asi
    		Destroy(collision.gameObject);
    	}
    }

    // esta funcion la llama Unity directamente cuando hay una colision con el objeto con la "tag" asignada en el inspector
    // no se llama en start ni en update, solo se declara dentro del script y listo.
    private void OnCollisionEnter2D(Collision2D collision)
    {
    	Debug.Log("collision");
    }
}
