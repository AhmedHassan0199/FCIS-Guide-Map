using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowMouse : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y <= 3.8)
        {
            transform.position = new Vector3(transform.position.x, (transform.position.y + (5*Time.deltaTime)) , transform.position.z);
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y >= -6)
        {
            transform.position = new Vector3(transform.position.x, (transform.position.y - (5 * Time.deltaTime)), transform.position.z);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -11.3)
        {
            transform.position = new Vector3((transform.position.x - (5 * Time.deltaTime)), transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= 11.3)
        {
            transform.position = new Vector3((transform.position.x + (5 * Time.deltaTime)), transform.position.y , transform.position.z);
        }


    }
}
