using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptEndLevel : MonoBehaviour
{
    public controllerFinNiveau UIFin;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        UIFin.endLvl();
    }
}
