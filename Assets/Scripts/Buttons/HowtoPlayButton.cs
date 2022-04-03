using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowtoPlayButton : MonoBehaviour
{
    [SerializeField] private string howToPlay = "HowtoPlay";
    public void HowtoPlay()
    {
        SceneManager.LoadScene(howToPlay);
    }
}
