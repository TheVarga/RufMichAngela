using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public AudioSource footsteps;
    public AudioSource damageTaken;
    private Rigidbody2D rb2D;
    public int Points;
    public float Health;
    public float MaxHealth;
    public float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;
    bool facingRight = true;
   // public HealthBar healthBar;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Points = 0;
        //moveSpeed = 2.7f;
        jumpForce = 50f;
        isJumping = false;
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(transform.root.gameObject);
        
        // healthBar.setMaxHealth(MaxHealth);
        //DontDestroyOnLoad(GameObject.FindWithTag("MainCamera"));
    }

    // Update is called once per frame
    void Update()
    {

        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        if (Health <= 0) { 
            Destroy(gameObject);
            SceneManager.LoadScene(1);
            
        }

        animator.SetFloat("Run", Mathf.Abs(moveHorizontal));
        animator.SetFloat("Jump", moveVertical);

       // healthBar.setHealth(Health);
    }

    void FixedUpdate()
    {
        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f) {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
            // if(!footsteps.isPlaying) footsteps.Play();
         
                FindObjectOfType<AudioManager>().Play("footsteps");           

        }
        if (!isJumping && moveVertical > 0.1f) {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce),ForceMode2D.Impulse);
        }
        if(moveHorizontal > 0 && !facingRight){
            FlipCharacter();
        }
        if (moveHorizontal < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform")) {
            isJumping = false;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isJumping = true;
        }
    }
    void FlipCharacter() {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }
    private void OnLevelWasLoaded(int level)
    {
        if(level !=0) FindStartPosition();
    }
    
    private void FindStartPosition()
    {
       transform.position = GameObject.FindWithTag("StartPosition").transform.position;
        
    }
    public void TakeDamage(float damageValue)
    {
        Health -= damageValue;

        //healthBar.setHealth(Health);
    }
    public void Heal(float healthValue)
    {
        Health += healthValue;

      //  healthBar.setHealth(Health);
    }
}
