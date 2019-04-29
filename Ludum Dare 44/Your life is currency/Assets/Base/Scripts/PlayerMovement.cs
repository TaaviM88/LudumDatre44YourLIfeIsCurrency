using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;

    [SerializeField]
    private float moveSpeed = 4;
    [SerializeField]
    private float rotateSpeed = 4;
    [SerializeField]
    private float maxVelocity = 10;

    private float currentSpeed;

    private float moveInput;
    private float rotateInput;
    private Vector2 moveVelocity;

    public bool openDoor = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    public void Update()
    {
        Vector2 moveVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        moveVelocity = moveVector.normalized * moveSpeed;

        transform.Rotate(Vector3.forward, rotateSpeed * -moveVector.x);

/*       if(moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        }
       else if(moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, transform.eulerAngles.z);
        }
        */
        //transform.eulerAngles += Vector3.forward * moveVector.y * rotateSpeed;
         }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.AddForce(transform.right * moveSpeed * moveVelocity.y);

        if (rb2d.velocity.magnitude > maxVelocity)
        {
            rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxVelocity);
        }

        if(moveVelocity.y == 0)
        {
            rb2d.velocity = Vector2.zero;
        }

        //rb2d.MovePosition(rb2d.position + moveVelocity * Time.fixedDeltaTime);

        /*  //rb2d.velocity = Vector2.right * (moveInput * moveSpeed);  // new Vector2(moveInput * moveSpeed, rb2d.velocity.y);
          rb2d.AddForce(Vector2.up * (moveInput * moveSpeed));
          if (rb2d.velocity.magnitude > maxVelocity)
          {
              rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxVelocity);
          }
          */
        //transform.Rotate(Vector3.forward * rotateInput * rotateSpeed);
        //rb2d.MoveRotation(rb2d.rotation * (rotateInput * rotateSpeed));
        //rb2d.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * moveSpeed, 0.8f), Mathf.Lerp(0, Input.GetAxis("Vertical") * currentSpeed, 0.8f));

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Door>() && Input.GetButtonDown("Fire2"))
        {
            collision.gameObject.GetComponent<Door>().OpenDoor();
        }
    }

        private void OnCollisionEnter2D(Collision2D collision)
    {
       /* if(collision.gameObject.GetComponent<Door>())
        {
            Debug.Log(collision.gameObject.name);
  
            collision.gameObject.GetComponent<Door>().OpenDoor();
            
        }*/
    }
}
