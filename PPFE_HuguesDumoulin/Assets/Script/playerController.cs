using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    private float xSpeed;
    private float zSpeed;
    private Rigidbody rb;

    public Transform zRotateBonhomme;
    public Transform xRotateBonhomme;

    private float DirectionAngle = 0f;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(this.transform.position.y < 0.5f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            xSpeed += Input.GetAxis("Mouse Y");
            zSpeed += Input.GetAxis("Mouse X");      
            if(xSpeed >= 1)
            {
                xSpeed = 1;
            }
            if(xSpeed <= -1)
            {
                xSpeed = -1;
            }
            if(zSpeed >= 1)
            {
                zSpeed = 1;
            }
            if(zSpeed <= -1)
            {
                zSpeed = -1;
            }
        }
        else
        {
            xSpeed = 0;
            zSpeed = 0;
        }

        rb.velocity = new Vector3(xSpeed, rb.velocity.y, -zSpeed);
        DirectionAngle = Mathf.Atan2(-xSpeed, zSpeed) * Mathf.Rad2Deg;
        zRotateBonhomme.eulerAngles = new Vector3(0, DirectionAngle, 0);
        xRotateBonhomme.localEulerAngles = new Vector3(-rb.velocity.magnitude*30, 0, 0);  
    }
}
