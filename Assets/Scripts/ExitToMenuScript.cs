using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMenuScript : MonoBehaviour
{
    [SerializeField] private string ToMainMenu = "TitleScreen";
    public void ExitToMenu()
    {
        SceneManager.LoadScene(ToMainMenu);
    }
}
