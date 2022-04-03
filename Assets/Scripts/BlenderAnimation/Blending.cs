using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blending : MonoBehaviour
{
    [SerializeField] BowlAnimation bowl;
    [SerializeField] string levelScoreScene = "Level_Complete";

    private SceneData sd;
    public List<FoodType> collectedFood;
    private bool waiting;
    
    private void Awake() {
        // sd = GameObject.FindObjectOfType<SceneData>();
        // collectedFood = sd.collectedFood;
        bowl.collectedFood = collectedFood;
        bowl.StartAnimation();
        waiting = false;
    }

    private void Update() {
        if (waiting) {
            if (Input.anyKey) {
                SceneManager.LoadScene(levelScoreScene);
            }
        }
    }

    public void StartWaiting() {
        waiting = true;
    }


}
