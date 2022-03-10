using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Info : MonoBehaviour
{
    public Text infoText;
    public PlayerMovement player;
    public Lever1 lever1;

    IEnumerator YouGotTheKey()
    {
        yield return new WaitForSeconds(2);
        infoText.text = "";
        player.canEnter = false;
        player.hasFirstKey = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.canGrabFirstKey == true)
        {
            infoText.text = "Press space to obtain key";
        }
        else if (player.canGrabFirstKey == false)
        {
            infoText.text = "";
        }

        if (player.hasFirstKey == true)
        {
            infoText.text = "You got the key";
        }

       

        if (player.canEnter == true)
        {
            infoText.text = "You unlocked the door";
            StartCoroutine(YouGotTheKey());
            
        }

        if (lever1.canBeSwitched == true && player.canEnter == false)
        {
            infoText.text = "Press space to pull lever";
        }
        
        if (lever1.canBeSwitched == true && player.canEnter == true)
        {
            infoText.text = "You unlocked the door";
            StartCoroutine(YouGotTheKey());
        }
    }

    
}
