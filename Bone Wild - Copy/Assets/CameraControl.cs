using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Lets the camera follow PlayerShip's position
        transform.position = new Vector3(Player.position.x, Player.position.y, -10);
    }

}

