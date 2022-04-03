using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{
    [SerializeField] private string newGame = "GameScene";
    public void NewGameButton()
    {
        SceneManager.LoadScene(newGame);
    }
}
