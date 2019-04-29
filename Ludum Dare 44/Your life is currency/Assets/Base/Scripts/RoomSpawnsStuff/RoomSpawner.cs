using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    //1 -> Need bottom door
    //2 -> need top door
    //3 -> need left door
    //4 -> need right door
    private int rng;
    public bool spawned = false;

    public float waitTime = 4;

    private void Start()
    {
        Destroy(gameObject,waitTime);
        Invoke("Spawn", 0.1f);
    }

    private void Spawn()
    {
        if(!spawned)
        {
            switch (openingDirection)
            {
                case 0:
                    
                    break;
                case 1:
                    //Bottom
                    rng = Random.Range(0, RoomTemplates.Instance.bottomRooms.Length);
                    Instantiate(RoomTemplates.Instance.bottomRooms[rng], transform.position, RoomTemplates.Instance.bottomRooms[rng].transform.rotation);
                    break;
                case 2:
                    rng = Random.Range(0, RoomTemplates.Instance.topRooms.Length);
                    Instantiate(RoomTemplates.Instance.topRooms[rng], transform.position, RoomTemplates.Instance.topRooms[rng].transform.rotation);
                    //spawn room top door
                    break;

                case 3:
                    rng = Random.Range(0, RoomTemplates.Instance.leftRooms.Length);
                    Instantiate(RoomTemplates.Instance.leftRooms[rng], transform.position, RoomTemplates.Instance.leftRooms[rng].transform.rotation);
                    // spawn room left door
                    break;

                case 4:
                    rng = Random.Range(0, RoomTemplates.Instance.rightRooms.Length);
                    Instantiate(RoomTemplates.Instance.rightRooms[rng], transform.position, RoomTemplates.Instance.rightRooms[rng].transform.rotation);
                    // spawn room right door
                    break;

                default:
                    Debug.Log($"Error in {openingDirection}");
                    break;
            }
            spawned = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SpawnPoint"))
        {
            if(collision.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(RoomTemplates.Instance.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
