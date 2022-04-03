using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScore : MonoBehaviour
{       
    [SerializeField] private Text scoreText;
    [SerializeField] private ProgressBar stars;

    private SceneData sd;

    public List<FoodType> collectedFood;
    public Dictionary<FoodType, FoodOpinion> foodPreferences;
    private Dictionary<FoodOpinion, int> opinionValues = new Dictionary<FoodOpinion, int>() {
        {FoodOpinion.Like, 3},
        {FoodOpinion.Neutral, 1},
        {FoodOpinion.Dislike, -1},
        {FoodOpinion.Hate, -3}
    };

    private void Awake() {
        sd = GameObject.FindObjectOfType<SceneData>();
        collectedFood = sd.collectedFood;
        foodPreferences = sd.foodPreferences;
        CalcScore();
    }

    private void CalcScore() {
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
        int maxScore = opinionValues[FoodOpinion.Like] * collectedFood.Count;
        stars.currentFillBar = (int) (((float) totalScore/ (float) maxScore) * 100);
    }

}
