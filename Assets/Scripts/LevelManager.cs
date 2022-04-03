using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private List<FoodType> collectedFood;
    [SerializeField] private int totalFoodRequired;

    [SerializeField] private float completionPercent;
    [SerializeField] private FillBar completionSlider;

    [SerializeField] private PreferenceManager pm;
    [SerializeField] private FoodSprites fs;

    private Dictionary<FoodType, FoodOpinion> foodPreferences;

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
        EndGame,
        WaitForEnd
    }
    private GameState state;

    private SceneData sd;

    [SerializeField] private string blendingScene = "BlendingScene";

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
        state = GameState.WaitForStart;
    }

    private void StartLevel() {
        fsm.StartSpawning();
        state = GameState.InGame;
    }

    private void EndLevel() {
        fsm.StopSpawning();
        state = GameState.Score;
        sd.collectedFood = collectedFood;
        sd.foodPreferences = foodPreferences;
        state = GameState.WaitForEnd;
    }

    private void CalcCompletion() {
        completionPercent = (float) collectedFood.Count / (float) totalFoodRequired;
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
        else if (state == GameState.WaitForEnd) {
            if (Input.anyKey) {
                SceneManager.LoadScene(blendingScene);
            }
        }
    }
}
