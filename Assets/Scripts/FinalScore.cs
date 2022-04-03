using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    // [SerializeField] private Text congratsText;
    [SerializeField] private ProgressBar[] stars;
    [SerializeField] private Image[] customers;

    [SerializeField] private Sprite[] satisfiedSprites;
    [SerializeField] private Sprite[] unsatisfiedSprites;

    private SceneData sd;
    private bool satisfiedCustomers;
    public Dictionary<int, ScoreData> levelScores;

    private void Awake() {
        sd = GameObject.FindObjectOfType<SceneData>();
        levelScores = sd.levelScores;
        CalcSatisfied();
        // if (!satisfiedCustomers) congratsText.text = "Try again!";
    }

    private void CalcSatisfied() {
        satisfiedCustomers = true;
        int totalScore = 0;
        foreach (KeyValuePair<int, ScoreData> level in levelScores) {
            int i = level.Key;
            int percentScore = level.Value.percentScore;
            stars[i].currentFillBar = percentScore;
            if (percentScore >= 60) {
                customers[i].sprite = satisfiedSprites[i];
            }
            else {
                satisfiedCustomers = false;
                customers[i].sprite= unsatisfiedSprites[i];
            }
            totalScore += level.Value.score;
        }
        scoreText.text = totalScore.ToString();
    }
}
