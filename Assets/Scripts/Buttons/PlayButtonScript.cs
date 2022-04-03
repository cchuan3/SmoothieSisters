using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{
    private GameObject musicPlayer;

    private void Awake() {
        musicPlayer = GameObject.FindGameObjectWithTag("MusicPlayer");
    }

    [SerializeField] private string newGame = "GameScene";
    public void NewGameButton()
    {
        Destroy(musicPlayer);
        SceneManager.LoadScene(newGame);
    }
}
