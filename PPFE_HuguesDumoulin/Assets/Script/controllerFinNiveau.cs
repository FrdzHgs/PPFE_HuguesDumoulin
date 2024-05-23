using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class controllerFinNiveau : MonoBehaviour
{
    public bool isEnd = false;
    public GameObject UIPause;
    public TMP_Text Result, Explication, Conseil;
    public InputField playerInput;
    public CanvasScaler[] canvasArray;
    private int buttonSelect;
    private string verticalString,levelName;
    public Camera cameralvl;

    public string[] listeConseil;

    void Start()
    {
        UIPause.SetActive(isEnd);
        levelName = SceneManager.GetActiveScene().name;
        Explication.text = Explication.text.Replace("?",levelName);
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnd)
        {
            playerInput.ActivateInputField();
        }
        else
        {
            playerInput.DeactivateInputField();
        }

        Result.text = playerInput.text + verticalString;

        if(Input.GetKeyDown(KeyCode.Return) && isEnd)
        {
            switch(playerInput.text)
            {
                case "Suivant" :
                    GI.NextLvl();
                    break;

                case "Recommencer" :
                    levelName = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(levelName, LoadSceneMode.Single);
                    break;

                case "Quitter" :
                    isEnd = false;
                    SceneManager.LoadScene("N_MenuPrincipal", LoadSceneMode.Single);
                    break;
                
                default :
                    playerInput.text = "";
                    break;          
            }
        }
    }

    public void endLvl()
    {
        StartCoroutine(setActive());
    }

    IEnumerator setActive()
    {
        isEnd = true;
        UIPause.SetActive(isEnd);
        playerInput.text = "";
        if(isEnd)
        {
            Time.timeScale = 0;
            cameralvl.rect = new Rect(0.5f,0.5f,0.5f,0.5f);

            int rnd = new System.Random().Next(0,listeConseil.Length);
            Conseil.text = Conseil.text.Replace("?",listeConseil[rnd]);
        }
        else
        {
            Time.timeScale = 1;
            cameralvl.rect = new Rect(0,0,1,1);
            Conseil.text = "Conseil :\n\t?";
        }

        yield return new WaitForSecondsRealtime(0.75f);

        playerInput.ActivateInputField();

        bool isVertical = true;
        while(isEnd)
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
