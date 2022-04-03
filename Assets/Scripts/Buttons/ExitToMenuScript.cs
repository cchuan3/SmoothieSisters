using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject musicPlayerPrefab;
    [SerializeField] private bool makeNewMusic = false;
    private SceneData sd;

    private void Awake() {
        sd = GameObject.FindObjectOfType<SceneData>();
    }

    [SerializeField] private string ToMainMenu = "TitleScreen";
    public void ExitToMenu()
    {
        if (makeNewMusic) {
            GameObject musicPlayer = Instantiate(musicPlayerPrefab, Vector3.zero, Quaternion.identity);
            DontDestroyOnLoad(musicPlayer);
        }
        sd.ResetGame();
        SceneManager.LoadScene(ToMainMenu);
    }
}
