using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExittoMenu2 : MonoBehaviour
{
    [SerializeField] private string mainMenu = "TitleScreen";
    public void exitToMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
