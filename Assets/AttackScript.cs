using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{   
    public int attackPower;
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
        Debug.Log(collision,gameObject);
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        
    }


}
