using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

[SerializeField] private GameObject canvas;
[SerializeField] private GameObject newgameButton;
[SerializeField] private GameObject creditsButton;
[SerializeField] private GameObject exitButton;



    public void LoadNewGame()
   {
        SceneManager.LoadScene("Scene_1");
   }

    public void LoadExit()
   {
        Application.Quit();
   }

   public void LoadCredits()
   {
        newgameButton.SetActive(false);
        creditsButton.SetActive(false);
        exitButton.SetActive(false);
        canvas.gameObject.SetActive(!canvas.gameObject.activeSelf);
   }

    public void DisableCredits()
   {
        newgameButton.SetActive(true);
        creditsButton.SetActive(true);
        exitButton.SetActive(true);
        canvas.gameObject.SetActive(false);
   }

    /*public void ToggleCanvasGroupActive()
   {
       canvas.gameObject.SetActive(!canvas.gameObject.activeSelf);
   }*/

   public void LoadMenuPrincipal()
   {
       SceneManager.LoadScene("Main_Menu");
   }

   public void BattleScene()
   {
        SceneManager.LoadScene("Battle Scene");
   }

    public void Afterbattle()
    {
        SceneManager.LoadScene("After_Battle");
    }
}
