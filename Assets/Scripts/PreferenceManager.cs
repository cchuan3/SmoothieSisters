using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreferenceManager : MonoBehaviour
{
    [SerializeField] private GameObject[] preferenceIcons;
    private int currPref;

    [SerializeField] private Color orange;

    public void ResetPreferences() {
        foreach (GameObject o in preferenceIcons) {
            o.SetActive(false);
        }
        currPref = 0;
        // Debug.Log("Reset");
    }

    public void setPreference(Sprite prefSprite, FoodOpinion opinion) {
        if (currPref >= preferenceIcons.Length) return;
        // Debug.Log(currPref);

        GameObject temp = preferenceIcons[currPref];
        temp.SetActive(true);
        switch(opinion) {
            case FoodOpinion.Like:
                temp.GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case FoodOpinion.Neutral:
                temp.GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
            case FoodOpinion.Dislike:
                temp.GetComponent<SpriteRenderer>().color = orange;
                break;
            case FoodOpinion.Hate:
                temp.GetComponent<SpriteRenderer>().color = Color.red;
                break;
        }
        SpriteRenderer foodSprite = temp.transform.GetChild(0).GetComponent<SpriteRenderer>();
        foodSprite.sprite = prefSprite;

        currPref++;
    }
}
