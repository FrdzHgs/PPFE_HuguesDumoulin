using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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

    public TMP_Text startText;

    private float DirectionAngle = 0f;

    public Image endImage;

    private bool isFail = false;

    void Start()
    {
        StartCoroutine(launchLvl());
        if(GI.isFailing == true)
        {
            GI.isFailing = false;
            StartCoroutine(startFail());
        }
    }

    void Update()
    {
        if(this.transform.position.y < 0.5f && isFail == false)
        {
            isFail = true;
            GI.isFailing = true;
            StartCoroutine(failLvl());
        }
    }

    IEnumerator failLvl()
    {
        float temps = 0;
        while(temps < 3)
        {
            temps = temps + Time.fixedDeltaTime;
            endImage.color = new Color(0,0,0,temps/3f);
            yield return 0;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator startFail()
    {
        float temps = 0;
        while(temps < 3)
        {
            temps = temps + Time.fixedDeltaTime;
            endImage.color = new Color(0,0,0,1-temps/3f);
            yield return 0;
        }
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

        movement = new Vector3(direction.x * speed, isGrounded ? 0 : -gravity, direction.y * speed);
        this.GetComponent<CharacterController>().Move(movement * Time.deltaTime);

        DirectionAngle = Mathf.Atan2(-zSpeed, -xSpeed) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, DirectionAngle, 0);
        xRotateBonhomme.localEulerAngles = new Vector3(speed*30, 0, 0);  
    }

    IEnumerator launchLvl()
    {
        yield return new WaitForSecondsRealtime(1f);
        float temps = 0f;
        while(temps < 10f)
        {
            startText.color = new Color(30f/255f, 233f/255f,0 ,1f - (0.1f * temps));
            yield return 0;
            temps = temps + Time.fixedDeltaTime;
        }
        startText.text = "";
    }
}
