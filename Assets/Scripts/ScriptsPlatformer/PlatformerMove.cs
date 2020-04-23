using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMove : AButtonPressed
{
    Rigidbody2D rb;

    public override void DownPressed()
    {
        throw new System.NotImplementedException();
    }

    public override void LeftPressed()
    {
        rb.AddForce(transform.right * -1);
    }

    public override void RightPressed()
    {
        rb.AddForce(transform.right * 1);
    }

    public override void UpPressed()
    {
        throw new System.NotImplementedException();
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
    }

}
