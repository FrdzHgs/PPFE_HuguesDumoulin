using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GI.isSet == false)
        {
            GI.InitGame();
        }       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
