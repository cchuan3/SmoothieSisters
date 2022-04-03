using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingFood : MonoBehaviour
{
    public FoodType thisFood { get; private set; }
    public FoodSprites fs;
    // [SerializeField] private Sprite[] fruitSprites = new Sprite[3];
    // [SerializeField] private Sprite[] fishSprites = new Sprite[3];
    // [SerializeField] private Sprite[] bugSprites = new Sprite[3];

    private void Awake() {
        var f = System.Enum.GetValues(typeof(FoodType));
        thisFood = (FoodType) f.GetValue(UnityEngine.Random.Range(0, f.Length));
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            other.gameObject.GetComponent<PlayerContactFood>().AddFood(thisFood);
            Destroy(gameObject);
        }
        else if (other.tag == "DestroyPlane") {
            Destroy(gameObject);
        }
    }

    public void SetFS(FoodSprites newfs) {
        fs = newfs;
        SetSprite(thisFood);
    }

    public void SetType(FoodType type) {
        thisFood = type;
    }

    private void SetSprite(FoodType type) {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = fs.GetSpriteOfType(type);
        // switch(type) {
        //     case FoodType.Fish:
        //         sr.sprite = FoodSprites.fishSprites[Random.Range(0,FoodSprites.fishSprites.Length)];
        //         break;
        //     case FoodType.Fruit:
        //         sr.sprite = FoodSprites.fruitSprites[Random.Range(0,FoodSprites.fruitSprites.Length)];
        //         break;
        //     case FoodType.Bug:
        //         sr.sprite = FoodSprites.bugSprites[Random.Range(0,FoodSprites.bugSprites.Length)];
        //         break;
        // }
    }
    
}
