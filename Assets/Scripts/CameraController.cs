using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static float CameraSpeed = 0.04f;
    public static int factor = 1;
    void Start()
    {
        factor = 1;
    }
   
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + (CameraSpeed * factor), transform.position.z);
        Debug.Log(factor + " : " + CameraSpeed);
    }
}