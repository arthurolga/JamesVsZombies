using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("BulletDestroy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        if (collision.gameObject.tag == "Enemy")
        {
            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<ZombieScript>().TakeDamage(1);
            Destroy(gameObject);
        }
        
    }

    IEnumerator BulletDestroy(){
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);

    }
}
