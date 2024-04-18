using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controllerPause : MonoBehaviour
{
    private bool isPause = false;
    public GameObject UIPause;
    public TMP_Text Result, Explication;
    public InputField playerInput;
    public CanvasScaler[] canvasArray;
    private int buttonSelect;
    private string verticalString,levelName;
    public Camera cameralvl;

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
            Debug.Log("caca");
            switch(playerInput.text)
            {
                case "Reprendre" :
                    isPause = false;
                    UIPause.SetActive(isPause);
                    break;

                case "Recommencer" :
                    isPause = false;
                    levelName = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(levelName, LoadSceneMode.Single);
                    break;

                case "Quitter" :
                    isPause = false;
                    SceneManager.LoadScene("N_MenuPrincipal", LoadSceneMode.Single);
                    break;
                
                default :
                    Debug.Log(playerInput.text);
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
        Time.timeScale = 0;
        if(isPause)
        {
            cameralvl.rect = new Rect(0.5f,0.5f,0.5f,0.5f);
        }
        else
        {
            cameralvl.rect = new Rect(0,0,1,1);
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

            yield return new WaitForSeconds(0.75f);
        }
    }
}
