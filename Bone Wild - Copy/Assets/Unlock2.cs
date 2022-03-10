using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock2 : MonoBehaviour
{
    public PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.canEnter2 == true)
        {
            Destroy(this.gameObject);
        }
    }
}
