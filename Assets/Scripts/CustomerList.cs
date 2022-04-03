using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerList
{
    private List<Customer> cl;

    public void InitList() {
        cl = new List<Customer>();
        // fill list
        Customer temp = new Customer("Cat");
        temp.AddLikedFood(FoodType.Fish);
        temp.AddDislikedFood(FoodType.Bug);
        cl.Add(temp);

        temp = new Customer("Frog");
        temp.AddLikedFood(FoodType.Bug);
        temp.AddHatedFood(FoodType.Fish);
        cl.Add(temp);

        temp = new Customer("Bird");
        temp.AddLikedFood(FoodType.Fruit);
        temp.AddLikedFood(FoodType.Fish);
        temp.AddHatedFood(FoodType.Bug);
        cl.Add(temp);
    }

    public Customer CustomerAt(int i) {
        if (i >= cl.Count) 
            return cl[0];
        return cl[i];
    }
}
