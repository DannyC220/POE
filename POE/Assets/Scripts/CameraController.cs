using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float zoomSize = 52;
    public float panSpeed = 20f;
    public float panBorderThickness = 20f;
    public Vector2 panLimit;
    public float scrollSpeed = 20f;
    public float minY = 20f;
    public float maxY = 120f;







    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel")>0)
        {
            GetComponent<Camera>().orthographicSize = zoomSize - 1;
        }
        if(Input.GetAxis("Mouse ScrollWheel")<0)
        {
            GetComponent<Camera>().orthographicSize = zoomSize + 1;
        }

      
        Vector3 pos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.y += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.y -= panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("a") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("d") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        //float scroll = Input.GetAxis("Mouse ScrollWheel");
        //pos.y += scroll * scrollSpeed * 100f * Time.deltaTime;

        //pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        //pos.x = Mathf.Clamp(pos.x, minY, maxY);
        //pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);



        transform.position = pos;



    }
}
