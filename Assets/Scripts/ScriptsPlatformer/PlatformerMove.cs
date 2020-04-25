using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMove : AButtonPressed
{
    Rigidbody2D rb;

    private float impulse=0.3f;
    private float lateral=1.0f;
    public bool grounded;

    public override void DownPressed()
    {
        throw new System.NotImplementedException();
    }

    public override void LeftPressed()
    {
        rb.AddForce(transform.right * -lateral);
    }

    public override void RightPressed()
    {
        rb.AddForce(transform.right * lateral);
    }

    public override void UpPressed()
    {
        throw new System.NotImplementedException();
    }

    public override void SpacePressed()
    {
        if (grounded)
        {
            rb.AddForce(transform.up * impulse, ForceMode2D.Impulse);
            grounded = false;
        }     
    }

    // esta funcion la llama Unity directamente cuando hay una colision con el objeto con la "tag" asignada en el inspector
    // no se llama en start ni en update, solo se declara dentro del script y listo.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject.tag == "Terreno")
        {
            grounded = true;
            Debug.Log("grounded");
        }
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
        PressSpace();
    }

}
