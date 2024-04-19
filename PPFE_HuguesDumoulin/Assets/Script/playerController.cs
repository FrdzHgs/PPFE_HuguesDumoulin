using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    private float xSpeed;
    private float zSpeed;
    private float speed;
    private Vector2 direction;
    private Vector3 movement;
    
    private bool isGrounded = false;

    public Transform zRotateBonhomme;
    public Transform xRotateBonhomme;
    public float gravity;

    private float DirectionAngle = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        if(this.transform.position.y < 0.5f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        Debug.Log("test");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Block")
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Block")
        {
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2 || Mathf.Abs(Input.GetAxis("Vertical")) > 0.2)
        {
            xSpeed = Input.GetAxis("Horizontal");
            zSpeed = Input.GetAxis("Vertical");    
            direction = new Vector2(-zSpeed, -xSpeed).normalized;  
            speed = Vector2.ClampMagnitude(new Vector2(-zSpeed, -xSpeed), 1).magnitude;                 
        }
        else
        {
            xSpeed = 0;
            zSpeed = 0;
            direction = new Vector2(0,0); 
            speed = 0;
        }

        movement = new Vector3(direction.x, isGrounded ? 0 : -gravity, direction.y) * speed;
        this.GetComponent<CharacterController>().Move(movement * Time.deltaTime);

        Debug.Log(direction);
        DirectionAngle = Mathf.Atan2(-zSpeed, -xSpeed) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, DirectionAngle, 0);
        xRotateBonhomme.localEulerAngles = new Vector3(speed*30, 0, 0);  
    }
}
