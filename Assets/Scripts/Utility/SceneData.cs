using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this);
        ResetCustomer();
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


}
