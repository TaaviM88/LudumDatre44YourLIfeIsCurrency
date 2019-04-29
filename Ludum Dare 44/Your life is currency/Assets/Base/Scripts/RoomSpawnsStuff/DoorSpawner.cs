using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSpawner : MonoBehaviour
{
    public int doorDirection;
    //1 -> Need bottom door
    //2 -> need top door
    //3 -> need left door
    //4 -> need right door
    private int rng;
    public bool spawned = false;

    public float waitTime = 4;

    public GameObject door;

    private void Start()
    {
        Destroy(gameObject,waitTime);
        Invoke("Spawn", 0.1f);
    }

    private void Spawn()
    {
        if(!spawned)
        {
            switch (doorDirection)
            {
                case 0:
                    
                    break;
                case 1:
                    //Bottom
                    Instantiate(door, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180));
                    door.GetComponent<Door>().direction = doorDirection;

                    break;
                case 2:
                    Instantiate(door, transform.position, Quaternion.identity);
                    door.GetComponent<Door>().direction = doorDirection;
                    //spawn room top door
                    break;

                case 3:
                    Instantiate(door, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90));
                    door.GetComponent<Door>().direction = doorDirection;
                    // spawn room left door
                    break;

                case 4:
                    Instantiate(door, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y,-90));
                    door.GetComponent<Door>().direction = doorDirection;
                    // spawn room right door
                    break;

                default:
                    Debug.Log($"Error in {doorDirection}");
                    break;
            }
            spawned = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SpawnPoint"))
        {
            if(collision.GetComponent<DoorSpawner>().spawned == false && spawned == false)
            {
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
