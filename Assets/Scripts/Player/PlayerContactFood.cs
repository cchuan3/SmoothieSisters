using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContactFood : MonoBehaviour
{
    [SerializeField] private LevelManager lm;

    public void AddFood(FoodType food) {
        lm.AddFood(food);
    }
}
