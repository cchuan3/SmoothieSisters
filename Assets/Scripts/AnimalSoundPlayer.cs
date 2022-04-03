using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] catSounds;
    [SerializeField] private AudioClip[] frogSounds;
    [SerializeField] private AudioClip[] birdSounds;

    [SerializeField] private AudioSource soundPlayer;

    private AudioClip[] currSounds;

    private float timer;

    private void Awake() {
        timer = 3f;
    }

    private void Update() {
        if (timer <= 0) {
            RandomTime();
            PlaySound(currSounds[Random.Range(0, currSounds.Length)]);
        }
        CountdownTimer();
    }
    
    private void RandomTime() {
        timer = Random.Range(3f, 5f);
    }

    private void CountdownTimer() {
        timer -= Time.deltaTime;
    }

    private void PlaySound(AudioClip sound) {
        soundPlayer.clip = sound;
        soundPlayer.Play();
    }

    public void SetSounds(int currCustomer) {
        switch(currCustomer) {
            case 0:
                currSounds = catSounds;
                break;
            case 1:
                currSounds = frogSounds;
                break;
            case 2:
                currSounds = birdSounds;
                break;
        }
        PlaySound(currSounds[0]);
    }
}
