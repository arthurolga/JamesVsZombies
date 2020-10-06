using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{   
    private Rigidbody2D rb;
    Animator anim;

    public GameObject inventory;
    public GameObject sword;
    public GameObject lifeCounter;


    public float attackSpeed = 0.5f;
    public float moveSpeed = 1.0f;
    public float shootSpeed = 1f;
    public int maxHealth = 3;

    private int health;
    bool isFacingRight;
    Vector3 shootDirection;
    bool isInventory;
    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = true;
        isInventory = false;
        health = maxHealth;
        rb = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        FlipCharacter();
        //Attack();
        Shoot();

        if (Input.GetKeyDown (KeyCode.I)){
            if (!isInventory){
                inventory.SetActive(true);
                isInventory = true;
            }else {
                inventory.SetActive(false);
                isInventory = false;
            }
        }
        
        
    }

    void Move(){
        rb.velocity = new Vector2 (0,0);
        anim.SetBool("isWalking",false);
        if (Input.GetKey (KeyCode.D) | Input.GetKey ("right")) {
            anim.SetBool("isWalking",true);
		    // Right
		    rb.velocity = new Vector2 (rb.velocity.x+moveSpeed, rb.velocity.y);
	
	    }
	
        if (Input.GetKey (KeyCode.A) | Input.GetKey ("left")) {
            anim.SetBool("isWalking",true);
            // Left
            rb.velocity = new Vector2 (rb.velocity.x-moveSpeed, rb.velocity.y);
            
        }

        if (Input.GetKey (KeyCode.S) | Input.GetKey ("down")) {
            anim.SetBool("isWalking",true);
            // Left
            rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y-moveSpeed);
            
        }

        if (Input.GetKey (KeyCode.W) | Input.GetKey ("up")) {
            anim.SetBool("isWalking",true);
            // Left
            rb.velocity = new Vector2 (rb.velocity.x,rb.velocity.y+ moveSpeed);
            
        }





    }

    void FlipCharacter(){
        if(rb.velocity.x < 0.0f & isFacingRight){
            isFacingRight = false;
            //transform.localRotation = Quaternion.Euler(0, 180, 0);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            
            
        }
        if(rb.velocity.x > 0.0f & !isFacingRight){
            isFacingRight = true;
            //transform.localRotation = Quaternion.Euler(0, 180, 0);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void Shoot(){
        shootDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //lookAngle = Mathf.Atan2(shootDirection.y, shootDirection.x)*Mathf.Rad2Deg;
        //shootDirection.Normalize();
        Vector2 direction = shootDirection;
        direction.Normalize();
        //Debug.Log(direction);
        if (Input.GetMouseButtonDown(0)){
            SFCController.PlaySound("attack");
            GameObject fireBullet = Instantiate(sword,transform.position,transform.rotation);
            fireBullet.GetComponent<Rigidbody2D>().velocity = direction*shootSpeed; 
        }
    }

    IEnumerator DrawSword(){
        sword.GetComponent<SpriteRenderer>().enabled = true;
        sword.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(attackSpeed);
        sword.GetComponent<SpriteRenderer>().enabled = false;
        sword.GetComponent<BoxCollider2D>().enabled = false;

    }

    void Attack(){
        if (Input.GetKeyDown (KeyCode.J)){
            StartCoroutine("DrawSword");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(1);
        }
        if (collision.gameObject.tag == "Chest")
        {
            Debug.Log("Escontei no chest");
            //collision.gameObject.GetComponent<ChestScript>().ShowText();
        }
        if (collision.gameObject.tag == "Sensei")
        {
            SceneManager.LoadScene("WinGame");
        }
        if (collision.gameObject.tag == "Cook")
        {
            SceneManager.LoadScene("WinGame2");
        }
        
    }

    

    public void TakeDamage(int damage){
        // Debug.Log("Ouch! ");
        SFCController.PlaySound("zombieBite");
        SFCController.PlaySound("hit");
        health -= damage;
        lifeCounter.GetComponent<UnityEngine.UI.Text>().text = string.Format("{0}/{1} Lives", health, maxHealth);
        if(health <= 0){
            //Destroy(gameObject);
            StartCoroutine(Die());
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<PlayerController>().enabled = false;
            rb.isKinematic = true;
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            
        }
    }
    IEnumerator Die(){
        SFCController.PlaySound("playerDeath");
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("LoseGame");
    }

    
}
