using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class pressCount : MonoBehaviour
{
    public TMP_Text inputCounts;
    void Start()
    {
        inputCounts.color = new Color32(0,114,32,255);
    }

    // Update is called once per frame
    void Update()
    {
        inputCounts.text = "= " + GI.inputList.Count.ToString() + "/3";

        if(GI.inputList.Count <= 2){inputCounts.color = new Color32(30,233,0,255);}
        if(GI.inputList.Count == 3){inputCounts.color = new Color32(255,128,0,255);}
        if(GI.inputList.Count >= 4){inputCounts.color = new Color32(255,0,0,255);}
    }
}
