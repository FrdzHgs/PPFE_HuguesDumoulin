using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class sliderSelect : MonoBehaviour
{
    public AnimationCurve sliderAnim;
    public KeyCode keySlider;
    public int menuNum;
    public TMP_Text inputClavier;
    public Image inputController;
    private bool go = false;
    private float tempsInput = 0f;
    private float sliderDuree = 2f;

    void Update()
    {
        if(Input.GetKeyDown(keySlider))
        {
            go = true;
            StartCoroutine(sliderPress());
            StopCoroutine(sliderRelease());

            inputClavier.color = new Color32(200, 0, 0, 255);
            inputClavier.fontSize = 55;
        }

        if(Input.GetKeyUp(keySlider))
        {
            go = false;
            StartCoroutine(sliderRelease());
            StopCoroutine(sliderPress());

            

            inputClavier.color = new Color32(0, 0, 0, 255);
            inputClavier.fontSize = 50;
        }

        if(this.GetComponent<Slider>().value == 1 && Input.GetKeyDown("joystick button 1"))
        {
            switch (menuNum)
            {
                case 0:
                    pressJouer();
                    break;
                case 1:
                    pressQuitter();
                    break;
                default:
                    break;
            }
        }

        if(this.GetComponent<Slider>().value == 1)
        {
            inputController.color = new Color32(255, 255, 255, 255);
        }
        else
        {
            inputController.color = new Color32(50, 50, 50, 255);
        }
    }

    IEnumerator sliderPress()
    {
        while(this.GetComponent<Slider>().value < 1 && go == true)
        {
            tempsInput += Time.fixedDeltaTime/sliderDuree;
            this.GetComponent<Slider>().value = sliderAnim.Evaluate(tempsInput);
            yield return null;
        }
    }

    IEnumerator sliderRelease()
    {
        while(this.GetComponent<Slider>().value > 0 && go == false)
        {
            tempsInput -= Time.fixedDeltaTime/sliderDuree*1.5f;
            this.GetComponent<Slider>().value = sliderAnim.Evaluate(tempsInput);
            yield return null;
        } 
    }  

    private void pressJouer()
    {
        SceneManager.LoadScene("N_Tuto", LoadSceneMode.Single);
    }

    private void pressQuitter()
    {
        Application.Quit();
    }
}
