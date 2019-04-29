using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private float moveAmount = 2;
    public int direction = 0;
    bool open = false;
    //1 -> Need bottom door
    //2 -> need top door
    //3 -> need left door
    //4 -> need right door

    BoxCollider2D col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor()
    {
        switch(direction)
        {
            case 0:
                Debug.Log($"Hey {gameObject.name} is {direction}");
                break;

            case 1:
                //Move door down
                if(open == false)
                {
                    //transform.position += Vector3.up * moveAmount;
                    transform.Translate(Vector3.up * moveAmount);
                    col.isTrigger = true;
                    
                    open = true;
                }
                
                break;

            case 2:
                //Move door up
                if (open == false)
                {
                    transform.Translate(Vector3.up * moveAmount);
                    col.isTrigger = true;
                    open = true;
                }
                
                break;

            case 3:
                //Move door left
                if (open == false)
                {
                    transform.Translate(Vector3.up * moveAmount);
                    col.isTrigger = true;
                    open = true;
                }
                
                break;

            case 4:
                //Move door right
                if (open == false)
                {
                    transform.Translate(Vector3.up * moveAmount);
                    col.isTrigger = true;
                    open = true;
                }
               
                break;

            default:
                Debug.Log($"Hey {gameObject.name} is {direction}");
                break;
        }
    }
   /* private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>().openDoor)
        {
            OpenDoor();
        }
    }*/
}
