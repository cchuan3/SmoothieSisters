using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this);
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

    public void ResetScores() {
        levelScores = new Dictionary<int, ScoreData>();
    }


}

public struct ScoreData {
    public int score;
    public int maxScore;
}