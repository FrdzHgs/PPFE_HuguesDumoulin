using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public static class GI
{
	public static int niveauActuel;
    public static List<string> Niveaux = new List<string>();

	public static void InitGame()
	{
		niveauActuel = 0;
        int nbrScene = SceneManager.sceneCountInBuildSettings - 1;

        for(int i = 1; i <= nbrScene; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);
            Niveaux.Add(sceneName);
            Debug.Log(Niveaux[i-1]);
        }
	}

    public static void NextLvl()
	{
        niveauActuel++;
        SceneManager.LoadScene(Niveaux[niveauActuel], LoadSceneMode.Single);
    }
}