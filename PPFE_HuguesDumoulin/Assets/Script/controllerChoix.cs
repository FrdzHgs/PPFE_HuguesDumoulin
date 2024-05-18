using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class controllerChoix : MonoBehaviour
{
    public GameObject UIMenu;
    public TMP_Text Result, Explication, Conseil;
    public InputField playerInput;
    private int buttonSelect;
    private string verticalString,levelName;
    public Camera cameralvl;
    public GameObject canvaMenu;
    private bool redoMaintenance = true;

    public string[] listeConseil;

    void Start()
    {
        levelName = SceneManager.GetActiveScene().name;
        playerInput.ActivateInputField();
        if(GI.niveauActuel == 0)
        {
            Explication.text = Explication.text.Replace("?","\"1\" disponible");
            Explication.text = Explication.text.Replace("nbr","1 niveau");
        }
        else
        {
            int valeurText = GI.niveauActuel + 1;
            Explication.text = Explication.text.Replace("?","\"1\" à \"" + valeurText + "\" disponible" );
            Explication.text = Explication.text.Replace("nbr",valeurText + " niveaux");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Result.text = playerInput.text + verticalString;
        playerInput.ActivateInputField();

        if(redoMaintenance)
        {
            StartCoroutine(maintenance());
            redoMaintenance = false;
            int rnd = new System.Random().Next(0,listeConseil.Length);
            Conseil.text = Conseil.text.Replace("?",listeConseil[rnd]);
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            switch(playerInput.text)
            {
                case "Liste" :
                    break;
                    
                case "Retour" :
                    playerInput.DeactivateInputField();
                    playerInput.text = "";
                    redoMaintenance = true;
                    this.gameObject.SetActive(false);
                    canvaMenu.SetActive(true);
                    break;
                
                default :
                    int niveau;
                    if(int.TryParse(playerInput.text, out niveau))
                    {
                        if(niveau > 0 && niveau <= GI.niveauActuel + 1)
                        {
                            GI.current = niveau;
                            SceneManager.LoadScene(GI.Niveaux[niveau - 1], LoadSceneMode.Single);
                        }                       
                    }
                    playerInput.text = "";
                    break;          
            }
        }
    }

    IEnumerator maintenance()
    {
        bool isVertical = true;
        while(true)
        {
            if(isVertical)
            {
                verticalString = "|";
            }
            else
            {
                verticalString = "";
            }

            isVertical = !isVertical;

            yield return new WaitForSecondsRealtime(0.75f);
        }
    }
}
