using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptTuto : MonoBehaviour
{
    public float tempsTuto;
    private float tempsRestantManette, tempsRestantClavier;

    public Image UIManette, UIClavier;

    public Sprite imageManette1, imageManette2, imageClavier1, imageClavier2;

    private bool statusManette = true, statusClavier = true;
    private bool showTutoManette = true, showTutoClavier = true;

    void Start()
    {
        StartCoroutine(tutoManette());
        StartCoroutine(tutoClavier());
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2 || Mathf.Abs(Input.GetAxis("Vertical")) > 0.2)
        {
            if(showTutoManette)
            {
                showTutoManette = false;
                StartCoroutine(removeTuto(UIManette));

                StartCoroutine(resetTuto(true, UIManette, "tutoManette"));
            }
            else
            {
                tempsRestantManette = tempsTuto;
            }
        }
    }

    
    public void stopClavier()
    {
        if(showTutoClavier)
        {
            showTutoClavier = false;
            StartCoroutine(removeTuto(UIClavier));
            StartCoroutine(resetTuto(false, UIClavier, "tutoClavier"));
        }
        else
        {
            tempsRestantClavier = tempsTuto;
        }
    }

    IEnumerator removeTuto(Image toRemove)
    {   
        byte colorValue = 255;

        while(colorValue != 0)
        {
            colorValue -= 5;
            toRemove.color = new Color32(255,255,255,colorValue);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator resetTuto(bool manetteClavier, Image UITuto, string coroutine)
    {
        if(manetteClavier)                
        {
            tempsRestantManette = tempsTuto;
            while(tempsRestantManette > 0)
            {
                yield return new WaitForSeconds(0f);
                tempsRestantManette -= Time.deltaTime;
            }
        }
        else
        {
            tempsRestantClavier = tempsTuto;
            while(tempsRestantClavier > 0)
            {
                yield return new WaitForSeconds(0f);
                tempsRestantClavier -= Time.deltaTime;
            }
        }

        UITuto.color = Color.white;

        switch(coroutine)
        {
            case "tutoManette" :
                StartCoroutine(tutoManette());
                break;

            case "tutoClavier" :
                StartCoroutine(tutoClavier());
                break;
            
            default :
                break;
        }
    }

    IEnumerator tutoManette()
    {
        showTutoManette = true;
        while(showTutoManette)
        {
            UIManette.sprite = (statusManette ? imageManette2 : imageManette1);
            statusManette = !statusManette;
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator tutoClavier()
    {
        showTutoClavier = true;
        while(showTutoClavier)
        {
            UIClavier.sprite = (statusClavier ? imageClavier2 : imageClavier1);
            statusClavier = !statusClavier;
            yield return new WaitForSeconds(1f);
        }
    }
}
