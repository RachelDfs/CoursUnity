using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadGameScene : MonoBehaviour
{
    public void ReloadScene () //pour le bouton "Retry"
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame() //Pour quitter
    {
        Application.Quit();
    }
  
}
