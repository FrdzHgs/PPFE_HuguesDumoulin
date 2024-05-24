using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public static class GI
{
	public static int niveauActuel;
    public static int current;
    public static List<string> Niveaux = new List<string>();
    public static bool isSet = false;
    public static List<KeyCode> inputList = new List<KeyCode>();
    public static string lvlText = "";
    public static bool isFailing = false;
    
	public static void InitGame()
	{
		niveauActuel = 0;
        int nbrScene = SceneManager.sceneCountInBuildSettings - 1;

        for(int i = 1; i <= nbrScene; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);
            Niveaux.Add(sceneName);
        }
        isSet = true;
	}

    public static void NextLvl()
	{
        if(current - 1 == niveauActuel)
        {
            niveauActuel++;
        }
        current++;
        SceneManager.LoadScene(Niveaux[current - 1], LoadSceneMode.Single);
        inputList.Clear();
    }

    public static void pressCounterAdd(KeyCode press)
    {
        if(!inputList.Contains(press))
        {
            inputList.Add(press);
            Debug.Log(press);
        }
    }

    public static void pressCounterRemove(KeyCode press)
    {
        inputList.Remove(press);
    }
}