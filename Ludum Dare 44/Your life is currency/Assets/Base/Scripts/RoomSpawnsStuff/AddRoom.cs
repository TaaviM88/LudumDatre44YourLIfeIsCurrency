using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{

    private void Start()
    {
        
        RoomTemplates.Instance.AddToRoomList(this.gameObject);
    }
}
