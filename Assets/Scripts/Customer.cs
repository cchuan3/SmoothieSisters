using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer
{
    private string customerName;

    private List<FoodType> likeFood;
    private List<FoodType> dislikeFood;
    private List<FoodType> hateFood;

    public List<FoodType> GetLikedFood() => likeFood;
    public List<FoodType> GetDislikedFood() => dislikeFood;
    public List<FoodType> GetHatedFood() => hateFood;

    public void AddLikedFood(FoodType food) {
        likeFood.Add(food);
    }
    public void AddDislikedFood(FoodType food) {
        dislikeFood.Add(food);
    }
    public void AddHatedFood(FoodType food) {
        hateFood.Add(food);
    }

    public Customer (string newName) {
        customerName = newName;
        likeFood = new List<FoodType>();
        dislikeFood = new List<FoodType>();
        hateFood = new List<FoodType>();
    }

    public string GetName() => customerName;
}
