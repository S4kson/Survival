using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCursor : MonoBehaviour
{
    Vector3 mousePosition;
    Camera cam;
    Rigidbody2D rd;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
    }
    void RotateCamera()
    {
        mousePosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                           Input.mousePosition.y,
                                                           Input.mousePosition.z-cam.transform.position.z));

        rd.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((mousePosition.y - transform.position.y), 
                                                                 (mousePosition.x - transform.position.x)) 
                                                                  * Mathf.Rad2Deg);
    }
}
