using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBlock : MonoBehaviour
{
    public float VitesseMonte;
    public float VitesseDescente;

    public KeyCode keyBlock;
    
    private bool goUp = true;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyBlock))
        {
            goUp = true;
            StartCoroutine(moveUp());
        }

        if(Input.GetKeyUp(keyBlock))
        {
            goUp = false;
            StartCoroutine(moveDown());
            StopCoroutine(moveUp());
        }

    }

    IEnumerator moveUp()
    {
        float distance = 0f;
        while (this.transform.position.y < -0.03f && goUp == true) 
        {
            distance += Time.fixedDeltaTime/VitesseMonte;
            this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y + distance,this.transform.position.z);
            yield return null;
        }

        if(this.transform.position.y > -0.03f && goUp == true)
        {
            this.transform.position = new Vector3(this.transform.position.x,0,this.transform.position.z);
        }
    }

    IEnumerator moveDown()
    {
        float distance = 0f;
        while (this.transform.position.y > -0.97f && goUp == false)
        {
            distance += Time.fixedDeltaTime/VitesseDescente;
            this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y - distance,this.transform.position.z);
            yield return null;
        }
        
        if(this.transform.position.y < -0.97f && goUp == false)
        {
            this.transform.position = new Vector3(this.transform.position.x,-1,this.transform.position.z);
        }
    }
}
