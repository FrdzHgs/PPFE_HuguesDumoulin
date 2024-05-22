using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class moveBlock : MonoBehaviour
{
    public float VitesseMonte;
    public float VitesseDescente;
    public bool isText = false;
    public TMP_Text self,cible;

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
            if(GI.inputList.Count < 3 || GI.inputList.Contains(keyBlock) && GI.inputList.Count < 4)
            {
                goUp = true;
                StartCoroutine(moveUp());
                if(isText == true)
                {
                    if(cible.text.Length < 8){cible.text = cible.text + self.text;}
                }
            }
            GI.pressCounterAdd(keyBlock);
        }

        if(Input.GetKey(keyBlock))
        {
            if(GameObject.Find("Tuto") != null)
            {
                GameObject.Find("Tuto").GetComponent<scriptTuto>().stopClavier();
            }
        }

        if(Input.GetKeyUp(keyBlock))
        {
            goUp = false;
            StartCoroutine(moveDown());
            StopCoroutine(moveUp());
            GI.pressCounterRemove(keyBlock);
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
