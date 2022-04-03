using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this);
        ResetGame();
    }

    public void ResetGame() {
        ResetCustomer();
        ResetScores();
    }

    private void ResetCustomer() {
        currCustomer = 0;
    }

    // For ingame scene
    public int currCustomer;

    public void NextCustomer() {
        currCustomer++;
    }

    // For level score scene
    public List<FoodType> collectedFood;
    public Dictionary<FoodType, FoodOpinion> foodPreferences;

    // For final score scene
    public Dictionary<int, ScoreData> levelScores;

    private void ResetScores() {
        levelScores = new Dictionary<int, ScoreData>();
        
        ScoreData temp = new ScoreData();
        temp.score = 0;
        temp.percentScore = 0;
        levelScores.Add(0, temp);
        levelScores.Add(1, temp);
        levelScores.Add(2, temp);
    }


}

public struct ScoreData {
    public int score;
    public int percentScore;
}