using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blending : MonoBehaviour
{
    [SerializeField] BowlAnimation bowl;
    [SerializeField] string levelScoreScene = "Level_Complete";
    [SerializeField] GameObject musicPlayer;

    private SceneData sd;
    public List<FoodType> collectedFood;
    private bool waiting;
    
    private void Awake() {
        sd = GameObject.FindObjectOfType<SceneData>();
        musicPlayer = GameObject.FindGameObjectWithTag("MusicPlayer");
        collectedFood = sd.collectedFood;
        bowl.collectedFood = collectedFood;
        bowl.StartAnimation();
        waiting = false;
    }

    private void Update() {
        if (waiting) {
            if (Input.anyKey) {
                Destroy(musicPlayer);
                SceneManager.LoadScene(levelScoreScene);
            }
        }
    }

    public void StartWaiting() {
        Destroy(musicPlayer);
        SceneManager.LoadScene(levelScoreScene);
        waiting = true;
    }


}
