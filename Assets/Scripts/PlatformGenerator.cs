using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    [SerializeField] public GameObject platform;
    [SerializeField] public GameObject cloud;
    [SerializeField] public GameObject thorn;
    [SerializeField] public GameObject slippery;
    [SerializeField] public GameObject[] powerups;
    [SerializeField] public GameObject[] traps;
    [SerializeField] public Transform reference;
    float dy = 1.74f;
    float dx = 7.66f;
    int count = 0;
    int count2 = 0;
    int l1 = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y - reference.position.y <= dy)
        {
            count++;
            count2++;
            int temp = l1;

            switch (l1)
            {
                case 1:
                    Instantiate(platform, transform.position, transform.rotation);
                    transform.position = new Vector2(transform.position.x, transform.position.y + dy);
                    l1 = 2;
                    break;
                case 3:
                    Instantiate(platform, transform.position, transform.rotation);
                    transform.position = new Vector2(transform.position.x, transform.position.y + dy);
                    l1 = 2;
                    break;
                case 2:
                    int i = Random.Range(0, 2);
                    if (i == 0)
                    {
                        transform.position = new Vector2(transform.position.x - dx, transform.position.y);
                        Instantiate(platform, transform.position, transform.rotation);
                        transform.position = new Vector2(transform.position.x + dx, transform.position.y + dy);
                        l1 = 1;
                    }
                    else
                    {
                        transform.position = new Vector2(transform.position.x + dx, transform.position.y);
                        Instantiate(platform, transform.position, transform.rotation);
                        transform.position = new Vector2(transform.position.x - dx, transform.position.y + dy);
                        l1 = 3;
                    }
                    break;
                default:
                    break;
            }

            int choice = Random.Range(1, 2);

            if (choice == 1 && count > 6)
            {
                int obs = 6 - temp - l1;
                int obsType = Random.Range(1, 3);
                CreateObstacle(obs, obsType);
                count = 0;
            }

            choice = Random.Range(1, 2);
            if(choice == 1 && count2 > 10)
            {
                CreatePowerup(l1);
                count2 = 0;
            }
        }
    }

    void CreateObstacle(int obs, int obsType)
    {
        switch (obs)
        {
            case 1:
                transform.position = new Vector2(transform.position.x - dx, transform.position.y - dy);
                break;
            case 2:
                transform.position = new Vector2(transform.position.x, transform.position.y - dy);
                break;
            case 3:
                transform.position = new Vector2(transform.position.x + dx, transform.position.y - dy);
                break;
        }

        int index = Random.Range(0, traps.Length);
        Instantiate(traps[index], transform.position, transform.rotation);

        /*switch (obsType)
        {
            case 1:
                Instantiate(cloud, transform.position, transform.rotation);
                break;
            case 2:
                Instantiate(slippery, transform.position, transform.rotation);
                break;
            case 3:
                Instantiate(thorn, transform.position, transform.rotation);
                break;
        }*/
        switch (obs)
        {
            case 1:
                transform.position = new Vector2(transform.position.x + dx, transform.position.y+dy);
                break;
            case 2:
                transform.position = new Vector2(transform.position.x, transform.position.y + dy);
                break;
            case 3:
                transform.position = new Vector2(transform.position.x - dx, transform.position.y+dy);
                break;
        }
    }

    void CreatePowerup(int l1)
    {
        switch (l1)
        {
            case 1:
                transform.position = new Vector2(transform.position.x - dx, transform.position.y - dy);
                break;
            case 2:
                transform.position = new Vector2(transform.position.x, transform.position.y - dy);
                break;
            case 3:
                transform.position = new Vector2(transform.position.x + dx, transform.position.y - dy);
                break;
        }
        
        int index = Random.Range(0, powerups.Length);
        Instantiate(powerups[index], transform.position, transform.rotation);

        switch (l1)
        {
            case 1:
                transform.position = new Vector2(transform.position.x + dx, transform.position.y + dy);
                break;
            case 2:
                transform.position = new Vector2(transform.position.x, transform.position.y + dy);
                break;
            case 3:
                transform.position = new Vector2(transform.position.x - dx, transform.position.y + dy);
                break;
        }
    }
}
