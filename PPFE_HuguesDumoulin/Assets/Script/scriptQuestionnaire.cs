using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scriptQuestionnaire : MonoBehaviour
{
    public string answer;
    public TMP_Text cible;
    public GameObject toMove;
    public AnimationCurve Curve;
    private bool win = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(cible.text == answer && win == false)
        {
            Victory();
            win = true;
        }
        else
        {
            StartCoroutine(Fail());
        }
    }

    public void Victory()
    {
        switch(cible.text)
        {
            case "CAMION" :
                StartCoroutine(moveVictoryCamion());
                break;

            case "CAILLOU" :
                StartCoroutine(moveVictoryCaillou());
                break;
            
            default :
                break;          
        }
    }
    IEnumerator Fail()
    {
        cible.color = new Color(1,0,0,1);
        yield return new WaitForSecondsRealtime(0.75f);
        cible.text = "";
        cible.color = new Color32(30,233,0,255);
    }

    IEnumerator moveVictoryCamion()
    {
        float temps = 0;
        while(temps < 50)
        {
            toMove.transform.position = new Vector3(8f - Curve.Evaluate(temps/50)*8, -2.525f, -9f);
            yield return 0;
            temps = temps + Time.fixedDeltaTime;
        }        
    }

    IEnumerator moveVictoryCaillou()
    {
        float temps = 0;
        while(temps < 50)
        {
            toMove.transform.position = new Vector3(1.64f, 8.1f - Curve.Evaluate(temps/50)*9, -6.59f);
            yield return 0;
            temps = temps + Time.fixedDeltaTime;
        }        
    }
}
