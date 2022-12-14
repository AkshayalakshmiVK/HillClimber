using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    float XLeft = 0;
    float XRight = 0;
    float YUp = 0;
    float YDown = 0;
    float CamWidth = 0;
    float CamHeight = 0;
    bool shield = false;
    bool freeze = false;
    public static bool dead = false;
    private float timer = 0.0f;
    float timeLeft = 0.0f;
    [SerializeField] Image TimeBar;
    [SerializeField] AudioSource powerupSound;
    [SerializeField] AudioSource dieSound;
    // Start is called before the first frame update
    private void Start()
    {
        
        TimeBar.enabled = false;
        rb = GetComponent<Rigidbody2D>();
        CamHeight = Camera.main.orthographicSize;
        CamWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }
    void Update()
    {
        XLeft = Camera.main.transform.position.x - CamWidth;
        XRight = Camera.main.transform.position.x + CamWidth;
        YUp = Camera.main.transform.position.y + CamHeight;
        YDown = Camera.main.transform.position.y - CamHeight;

        //Debug.Log(CameraController.CameraSpeed);
        
        if ((transform.position.x >= XRight || transform.position.x <= XLeft || transform.position.y < YDown) && !dead)
        {
            Die();
        }

        if ((shield || freeze) && timer > 0)
        {
            timer -= Time.deltaTime;
            TimeBar.fillAmount = timer / 8;
        }
        else
        {
            if (freeze == true)
            {
                CameraController.CameraSpeed += 0.02f;
                BackgroundScroller.dy += 0.02f;
            }
            shield = false;
            freeze = false;
            //Debug.Log("Time up");
            timer = 8;
            TimeBar.enabled = false;
        }


    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Cloud") && !shield)
        {
            Destroy(coll.gameObject);
        }

        else if (coll.gameObject.CompareTag("Thorny") && !shield)
        {
            
            transform.position = new Vector3(transform.position.x, transform.position.y + 1f, 0);
            coll.collider.enabled = !coll.collider.enabled;
            Debug.Log("Dead");
            dead = true;
            dieSound.Play();
        }

        else if (coll.gameObject.CompareTag("Slippery") && !shield)
        {
            Destroy(coll.gameObject, 1);
        }

        else if (coll.gameObject.CompareTag("Shield"))
        {
            powerupSound.Play();
            coll.collider.enabled = !coll.collider.enabled;
            Destroy(coll.gameObject);
            shield = true;
            TimeBar.enabled = true;
            timer = 8;
        }

        else if (coll.gameObject.CompareTag("Freeze"))
        {
            powerupSound.Play();
            coll.collider.enabled = !coll.collider.enabled;
            Destroy(coll.gameObject);
            freeze = true;
            TimeBar.enabled = true;
            CameraController.CameraSpeed -= 0.01f;
            BackgroundScroller.dy -= 0.01f;
            timer = 8;
        }
    }
    private void Die()
    {

        dieSound.Play();
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
        Debug.Log("Dead");
        dead = true;
        
    }
}
