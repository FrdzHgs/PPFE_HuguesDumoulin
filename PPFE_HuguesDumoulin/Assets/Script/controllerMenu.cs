using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class controllerMenu : MonoBehaviour
{
    public GameObject UIMenu;
    public TMP_Text Result, Explication, Conseil;
    public InputField playerInput;
    private int buttonSelect;
    private string verticalString,levelName;
    public Camera cameralvl;
    public GameObject canvaListe;
    private bool redoMaintenance = true;

    public string[] listeConseil;

    void Start()
    {
        levelName = SceneManager.GetActiveScene().name;
        playerInput.ActivateInputField();
        StartCoroutine(maintenance());
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
                    playerInput.DeactivateInputField();
                    playerInput.text = "";
                    canvaListe.SetActive(true);
                    redoMaintenance = true;
                    this.gameObject.SetActive(false);
                    break;
                    
                case "Quitter" :
                    Application.Quit();
                    SceneManager.LoadScene("N_MenuPrincipal", LoadSceneMode.Single);
                    break;
                
                default :
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
