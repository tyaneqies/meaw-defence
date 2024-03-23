using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour
{
    public bool canMove;

    public float panSpeed; //pan camera
    public float zoomSpeed;
    public float minY, maxY; //zoom area
    public float minX, maxX;

    public int screenEdge = 50; //50 pixle

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            canMove = !canMove;
        }

        if(canMove)
        {
            return;
        }

        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y > Screen.height - screenEdge) //mouse pan
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y < Screen.height - screenEdge) //mouse pan
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x > Screen.height - screenEdge) //mouse pan
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x < Screen.height - screenEdge) //mouse pan
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float wheel = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= wheel * zoomSpeed;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;
        
    }
}
