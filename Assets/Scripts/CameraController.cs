using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static float CameraSpeed = 0.02f;
    public static float factor = 1f;
    void Start()
    {
        factor = 1;
        CameraSpeed = 0.02f;
    }
   
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + (CameraSpeed * factor), transform.position.z);
        Debug.Log("Factor " + factor + " : " + "Speed " + CameraSpeed);
    }
}