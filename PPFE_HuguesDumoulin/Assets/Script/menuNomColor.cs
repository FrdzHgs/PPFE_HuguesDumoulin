using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class menuNomColor : MonoBehaviour

{
    public KeyCode lettreTitre;
    public Color32 couleurLettre;
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(lettreTitre))
        {
            text.color = couleurLettre;
        }
            
    }
}
