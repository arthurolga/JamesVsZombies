using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameController : MonoBehaviour
{
    public GameObject Player;
    public GameObject gameTitle;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickStartGame(){
        
        Player.GetComponent<PlayerController>().enabled = true;
        Player.GetComponent<SpriteRenderer>().enabled = true;
        Destroy(gameTitle);
        Destroy(gameObject);
        
        
    }
}
