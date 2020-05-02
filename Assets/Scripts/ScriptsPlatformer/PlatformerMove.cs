using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformerMove : AButtonPressed
{
    [SerializeField] private LayerMask platformsLayerMask;
    Rigidbody2D rb;
    public Camera camera1;
    private Vector3 posCameraZ;
    private Transform cameraTf;
    private CapsuleCollider2D capsuleCollider2d;
    private float runVelocity = 5f;

    private Animator anim;

    private float impulse=0.3f;
    private float lateral=1.0f;
    public bool grounded;

    public override void DownPressed()
    {
        anim.SetBool("isRunning", false);
    }

    public override void LeftPressed()
    {
        rb.velocity = new Vector2(-runVelocity, rb.velocity.y);
    }

    public override void RightPressed()
    {
        rb.velocity = new Vector2(+runVelocity, rb.velocity.y);
    }

    public override void UpPressed()
    {
        anim.SetBool("isRunning", true);
    }

    public override void SpacePressed()
    {
        if (IsGrounded())
        {
            rb.velocity = Vector2.up * 5f;
            
        }     
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.CapsuleCast(capsuleCollider2d.bounds.center, capsuleCollider2d.bounds.size,capsuleCollider2d.direction, 0f, Vector2.down, .03f, platformsLayerMask);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
      
    }

    // Start is called before the first frame update
    void Start()
    {
        capsuleCollider2d = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        cameraTf = camera1.GetComponent<Transform>();
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", false);
    }

    // Update is called once per frame
    void Update()
    {
        posCameraZ.x = this.transform.position.x;
        posCameraZ.z = -10f;
        posCameraZ.y = 1.5f;
        cameraTf.transform.position = posCameraZ;
    }

    private void FixedUpdate()
    {
        PressRight();
        PressLeft();
        PressSpace();
        PressUp();
        PressDown();
    }

}
