using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    float CamWidth = 0;
    float CamHeight = 0;
    
    void Start()
    {
        CamHeight = Camera.main.orthographicSize;
        CamWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        float XLeft = Camera.main.transform.position.x - CamWidth;
        float XRight = Camera.main.transform.position.x + CamWidth;
        float YUp = Camera.main.transform.position.y + CamHeight;
        float YDown = Camera.main.transform.position.y - CamHeight;

        if (transform.position.x >= XRight || transform.position.x <= XLeft || transform.position.y < YDown)
        {
            Destroy(gameObject);
        }
    }
}
