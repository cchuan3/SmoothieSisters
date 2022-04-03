using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    [SerializeField] private AudioClip[] ingame;
    private AudioSource musicPlayer;

    public void SetMusic(int currCustomer) {
        musicPlayer = gameObject.GetComponent<AudioSource>();
        Debug.Log(currCustomer);
        musicPlayer.clip = ingame[currCustomer];
        musicPlayer.Play();
    }

}
