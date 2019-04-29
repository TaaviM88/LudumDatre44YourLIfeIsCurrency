using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public static RoomTemplates Instance;

    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;
    private int m_Red, m_Blue, m_Green;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        m_Red = Random.Range(0, 255);
        m_Blue = Random.Range(0, 255);
        m_Green = Random.Range(0, 255);
    }

    public void Update()
    {
        if(waitTime <= 0 && spawnedBoss == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if(i == rooms.Count -1)
                {
                    Instantiate(boss, rooms[i].transform.position,Quaternion.identity);
                    spawnedBoss = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    public void AddToRoomList(GameObject room)
    {
        rooms.Add(room);
    }

    public Color RenturnColor()
    {
        Color clr = new Color(m_Red, m_Green, m_Blue);
        return clr;
    }
}
