using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bx;
    public static int score = 0;
    private float dirX = 0f;
    private Vector2 lastPosition;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask jumpable;
    [SerializeField] Text scoreText;
    [SerializeField] Text endScore;
    [SerializeField] AudioSource jumpSound;
    private SpriteRenderer sprite;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        bx = GetComponent<BoxCollider2D>();
        lastPosition = transform.position;
        Time.timeScale = 1f;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Horizontal") && IsGrounded())
        {
            jumpSound.Play();
            rb.velocity = new Vector2(dirX * moveSpeed, jumpForce); //velocity above;add force here
        }

        score = (int)(Mathf.Max(score, (transform.position.y * 1.04f)));
        if (score > 25) { 
            CameraController.factor = 1 + ((score / 25) * 0.1f);
        }

        //update multiplicative factor of screen moving speed

        scoreText.text = "Score : " + score;
        endScore.text = "Score : " + score;
        //Debug.Log(score); 
    }
    private bool IsGrounded()
    {
        //lastPosition = transform.position; //later change to only when func returns true
        return Physics2D.BoxCast(bx.bounds.center, bx.bounds.size, 0f, Vector2.down, 0.5f, jumpable);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        
        rb.velocity = Vector3.zero;
        
    }
}
