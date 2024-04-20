using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class controllerPause : MonoBehaviour
{
    public bool isPause = false;
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
        UIPause.SetActive(isPause);
        levelName = SceneManager.GetActiveScene().name;
        Explication.text = Explication.text.Replace("?",levelName);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            StartCoroutine(setActive());
        }

        if(isPause)
        {
            playerInput.ActivateInputField();
        }
        else
        {
            playerInput.DeactivateInputField();
        }

        Result.text = playerInput.text + verticalString;

        if(Input.GetKeyDown(KeyCode.Return) && isPause)
        {
            switch(playerInput.text)
            {
                case "Reprendre" :
                    Time.timeScale = 1;
                    StartCoroutine(setActive());
                    break;

                case "Recommencer" :
                    levelName = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(levelName, LoadSceneMode.Single);
                    break;

                case "Quitter" :
                    isPause = false;
                    SceneManager.LoadScene("N_MenuPrincipal", LoadSceneMode.Single);
                    break;
                
                default :
                    playerInput.text = "";
                    break;          
            }
        }
    }

    IEnumerator setActive()
    {
        isPause = !isPause;
        UIPause.SetActive(isPause);
        playerInput.ActivateInputField();
        playerInput.text = "";
        if(isPause)
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
        foreach(CanvasScaler i in canvasArray)
        {
            if(isPause)
            {
                i.scaleFactor = 0.5f;
            }
            else
            {
                i.scaleFactor = 1f;
            }
        }

        bool isVertical = true;
        while(isPause)
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
