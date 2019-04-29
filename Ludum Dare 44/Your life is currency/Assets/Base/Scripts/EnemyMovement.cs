using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float rotateAmount = 10;
    public bool rotateAround = true;
    public float moveSpeed = 20;
    public float dmg = 1;
    EnemyStats ensts;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        ensts = GetComponent<EnemyStats>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rotateAround)
        {
         transform.Rotate(Vector3.forward, rotateAmount* Time.deltaTime);
        }
        
    }

    public void FixedUpdate()
    {
        rb2d.AddForce(transform.right * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerStats>())
        {
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(dmg);
        }
        else
            return; 
    }
}
