using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private List<FoodType> collectedFood;
    [SerializeField] private int totalFoodRequired;

    [SerializeField] private float completionPercent;
    [SerializeField] private FillBar completionSlider;

    [SerializeField] private PreferenceManager pm;
    [SerializeField] private FoodSprites fs;

    [SerializeField] private GameObject scorePanel;
    [SerializeField] private Text scoreText;
    // [SerializeField] private FillBar likedSlider;
    // [SerializeField] private FillBar neutralSlider;
    // [SerializeField] private FillBar dislikedSlider;
    // [SerializeField] private FillBar hatedSlider;

    private Dictionary<FoodType, FoodOpinion> foodPreferences;
    private Dictionary<FoodOpinion, int> opinionValues = new Dictionary<FoodOpinion, int>() {
        {FoodOpinion.Like, 3},
        {FoodOpinion.Neutral, 1},
        {FoodOpinion.Dislike, -1},
        {FoodOpinion.Hate, -3}
    };

    private Customer currCustomer;
    private Customer CurrCustomer { 
        get {
            return currCustomer;
        }
        set {
            currCustomer = value;
            foreach (FoodType f in currCustomer.GetLikedFood()) {
                foodPreferences[f] = FoodOpinion.Like;
                pm.setPreference(fs.GetSpriteOfType(f), FoodOpinion.Like);
                // Debug.Log("Like " + f);
            }
            foreach (FoodType f in currCustomer.GetDislikedFood()) {
                foodPreferences[f] = FoodOpinion.Dislike;
                pm.setPreference(fs.GetSpriteOfType(f), FoodOpinion.Dislike);
                // Debug.Log("Dislike" + f);
            }
            foreach (FoodType f in currCustomer.GetHatedFood()) {
                foodPreferences[f] = FoodOpinion.Hate;
                pm.setPreference(fs.GetSpriteOfType(f), FoodOpinion.Hate);
                // Debug.Log("Hate" + f);
            }
        }
    }
    private CustomerList cl;

    [SerializeField] private FoodSpawnManager fsm;

    private enum GameState {
        WaitForStart,
        InGame,
        Score,
        EndGame
    }
    private GameState state;

    private SceneData sd;

    private void Awake() {
        sd = GameObject.FindObjectOfType<SceneData>();
        collectedFood = new List<FoodType>();
        cl = new CustomerList();
        cl.InitList();
        ResetLevel();
    }

    private void ResetLevel() {
        collectedFood.Clear();
        CalcCompletion();
        NeutralScores();
        pm.ResetPreferences();
        Customer temp = cl.CustomerAt(sd.currCustomer);
        CurrCustomer = temp;
        scorePanel.SetActive(false);
        state = GameState.WaitForStart;
    }

    private void StartLevel() {
        fsm.StartSpawning();
        state = GameState.InGame;
    }

    private void EndLevel() {
        fsm.StopSpawning();
        CalcScore();
        state = GameState.Score;
    }

    private void CalcCompletion() {
        completionPercent = (float) collectedFood.Count / (float) totalFoodRequired;
    }

    private void CalcScore() {
        scorePanel.SetActive(true);

        Dictionary<FoodOpinion, float> scoreCounts = new Dictionary<FoodOpinion, float>() {
            {FoodOpinion.Like, 0f},
            {FoodOpinion.Neutral, 0f},
            {FoodOpinion.Dislike, 0f},
            {FoodOpinion.Hate, 0f}
        };
        int totalScore = 0;
        foreach (FoodType f in collectedFood) {
            FoodOpinion temp = foodPreferences[f];
            scoreCounts[temp]++;
            totalScore += opinionValues[temp];
        }
        // scoreCounts[FoodOpinion.Like] = scoreCounts[FoodOpinion.Like] / (float) totalFoodRequired;
        // float sliderVal = scoreCounts[FoodOpinion.Like];
        // likedSlider.CurrentValue = sliderVal;
        // scoreCounts[FoodOpinion.Neutral] = scoreCounts[FoodOpinion.Neutral] / (float) totalFoodRequired;
        // sliderVal += scoreCounts[FoodOpinion.Neutral];
        // neutralSlider.CurrentValue = sliderVal;
        // scoreCounts[FoodOpinion.Dislike] = scoreCounts[FoodOpinion.Dislike] / (float) totalFoodRequired;
        // sliderVal += scoreCounts[FoodOpinion.Dislike];
        // neutralSlider.CurrentValue = sliderVal;
        // scoreCounts[FoodOpinion.Hate] = scoreCounts[FoodOpinion.Hate] / (float) totalFoodRequired;
        // sliderVal += scoreCounts[FoodOpinion.Hate];
        // neutralSlider.CurrentValue = sliderVal;

        scoreText.text = totalScore.ToString();
    }

    private void NeutralScores() {
        foodPreferences = new Dictionary<FoodType, FoodOpinion>();
        foreach (FoodType i in Enum.GetValues(typeof(FoodType))) {
            foodPreferences.Add(i, FoodOpinion.Neutral);
        }
    }

    public void AddFood(FoodType food) {
        collectedFood.Add(food);
        CalcCompletion();
        completionSlider.CurrentValue = completionPercent;
        if (completionPercent == 1) {
            EndLevel();
        }
    }

    private void Update() {
        if (state == GameState.WaitForStart) {
            if (Input.anyKey) {
                StartLevel();
            }
        }
    }
}
