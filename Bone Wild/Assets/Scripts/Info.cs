using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Info : MonoBehaviour
{
    public Text infoText;
    public PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.canGrabKey == true)
        {
            infoText.text = "Press space to obtain key";
        }
        else if (player.canGrabKey == false)
        {
            infoText.text = "";
        }

        if (player.hasKey == true)
        {
            infoText.text = "You got the key";
        }

        if (player.cannotEnter == true)
        {
            infoText.text = "You need a key";    
        }

        if (player.canEnter == true)
        {
            infoText.text = "You unlocked the door";
        }
    }

    
}
