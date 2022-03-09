using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Information : MonoBehaviour
{
    public PlayerMovement player;

    public Text text;

    bool playerJustGotTheKey = false;

    IEnumerator PlayerHasKey()
    {
        text.text = "You got the key";
        yield return new WaitForSeconds(2);
        text.text = "";
        playerJustGotTheKey = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.haveKey == true)
        {
            playerJustGotTheKey = true;
        }

        if (playerJustGotTheKey == true)
        {
            StartCoroutine(PlayerHasKey());
        }
    }
}
