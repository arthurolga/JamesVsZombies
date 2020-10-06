using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{   
    public GameObject player;
    public float moveSpeed;
    public int maxHealth=5;
    int health;
    Rigidbody2D rb;
    bool isFacingRight;
    SpriteRenderer sRender;

    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = true;
        rb = gameObject.GetComponent<Rigidbody2D>();
        health = maxHealth;
        sRender = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player){
            Vector3 direction = player.transform.position - transform.position;
            direction.Normalize();
            if(direction.x > 0 & !isFacingRight){
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                isFacingRight = true;
            }
            if(direction.x < 0 & isFacingRight){
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                isFacingRight = false;
            }


            rb.MovePosition(transform.position + (direction * moveSpeed * Time.deltaTime));
        }
    }
    public void TakeDamage(int a){
        health -= a;
        StartCoroutine(BlinkRed());
        if (health <= 0){
            SFCController.PlaySound("zombieDeath");
            Destroy(gameObject);
        }
    }

    IEnumerator BlinkRed(){
        sRender.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sRender.color = Color.white;
        

    }
    
}
