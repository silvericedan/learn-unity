using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : AButtonPressed
{
    private Transform tfm;

    public override void DownPressed()
    {
        tfm.Translate(new Vector3(0,-1, 0) * Time.deltaTime);
    }

    public override void LeftPressed()
    {
        tfm.Translate(new Vector3(-1, 0, 0)* Time.deltaTime);
        Debug.Log("izq");
    }

    public override void RightPressed()
    {
        tfm.Translate(new Vector3(1,0,0)* Time.deltaTime);
        Debug.Log("der");
    }

    public override void UpPressed()
    {
        tfm.Translate(new Vector3(0, 1, 0) * Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        tfm = GetComponent<Transform>();
        Debug.Log("inicio");
    }

    // Update is called once per frame
    void Update()
    {
        PressRight();
        PressLeft();
        PressDown();
        PressUp();
       
    }
}
