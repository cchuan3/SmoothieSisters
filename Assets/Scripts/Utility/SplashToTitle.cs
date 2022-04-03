using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashToTitle : MonoBehaviour
{
    [SerializeField] private string titleScreen = "TitleScreen";

    private float timer;
    private void Awake() {
        timer = 0.01f;
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 ) {
            SceneManager.LoadScene(titleScreen);
        }
    }
}
