using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMenuScript : MonoBehaviour
{
    private SceneData sd;

    private void Awake() {
        sd = GameObject.FindObjectOfType<SceneData>();
    }

    [SerializeField] private string ToMainMenu = "TitleScreen";
    public void ExitToMenu()
    {
        sd.ResetGame();
        SceneManager.LoadScene(ToMainMenu);
    }
}
