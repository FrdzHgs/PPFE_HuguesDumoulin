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

    public TMP_Text textIfEnd;

    private bool isEndGame = false;

    void Start()
    {
        playerInput.DeactivateInputField();
        UIPause.SetActive(isEnd);
        levelName = SceneManager.GetActiveScene().name;
        Explication.text = Explication.text.Replace("?",levelName);
    }

    // Update is called once per frame
    void Update()
    {
        Result.text = playerInput.text + verticalString;

        if(Input.GetKeyDown(KeyCode.Return) && isEnd)
        {
            switch(playerInput.text)
            {
                case "Suivant" :
                    Time.timeScale = 1;
                    if(!isEndGame){GI.NextLvl();}
                    else{playerInput.text = "";}
                    break;

                case "Recommencer" :
                    Time.timeScale = 1;
                    levelName = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(levelName, LoadSceneMode.Single);
                    break;

                case "Quitter" :
                    Time.timeScale = 1;
                    isEnd = false;
                    SceneManager.LoadScene("N_MenuPrincipal", LoadSceneMode.Single);
                    break;

                case "Fermer" :
                    Time.timeScale = 1;
                    if(isEndGame){Application.Quit();}
                    else{playerInput.text = "";}
                    break;
                
                default :
                    playerInput.text = "";
                    break;          
            }
        }
    }

    public void endLvl(bool fin)
    {
        isEndGame = fin;
        if(fin)
        {
            Explication.text = textIfEnd.text;
            Explication.fontSize = 36;
        }
        StartCoroutine(setActive());
        Explication.text = Explication.text.Replace("!",GI.lvlText);
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
