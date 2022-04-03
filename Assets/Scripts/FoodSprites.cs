using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSprites : MonoBehaviour
{
    public Sprite[] fruitSprites = new Sprite[3];
    public Sprite[] fishSprites = new Sprite[3];
    public Sprite[] bugSprites = new Sprite[3];

    public Sprite GetSpriteOfType(FoodType type) {
        Sprite rSprite;
        switch(type) {
            case FoodType.Fish:
                rSprite = fishSprites[Random.Range(0,fishSprites.Length)];
                break;
            case FoodType.Fruit:
                rSprite = fruitSprites[Random.Range(0,fruitSprites.Length)];
                break;
            case FoodType.Bug:
                rSprite = bugSprites[Random.Range(0,bugSprites.Length)];
                break;
            default:
                rSprite = fishSprites[0];
                break;
        }
        return rSprite;
    }
}

