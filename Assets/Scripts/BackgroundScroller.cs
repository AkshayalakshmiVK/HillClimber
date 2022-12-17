using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 0.05f;
    public static float dy = 0.02f;
    private float offset = 0;
    private Material mat;
    // Start is called before the first frame update
    void Start()
    {
        dy = 0.02f;
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        //scrollSpeed = scrollSpeed * (CameraController.factor);       
        transform.position = new Vector3(transform.position.x, transform.position.y + ( dy * CameraController.factor ), transform.position.z);
        offset += (Time.deltaTime * scrollSpeed);
        mat.SetTextureOffset("_MainTex", new Vector2(0, offset));

    }
}
