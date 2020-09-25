using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    public GameObject Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Mameme");
            ShowText();
        }
        
    }
    public void ShowText(){
        Text.SetActive(true);
    }

    

    public void Open(){
        Debug.Log("Mameme");
    }
}
