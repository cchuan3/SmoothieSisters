using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScoreSceneButton : MonoBehaviour
{
    [SerializeField] private string finalScoreScene = "FinalScoreScene";
    public void ToFinalScore()
    {
        SceneManager.LoadScene(finalScoreScene);
    } 
}
