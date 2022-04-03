using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutUsButtonScript : MonoBehaviour
{
    [SerializeField] private string aboutUs = "AboutUs";
    public void AboutUsButton()
    {
        SceneManager.LoadScene(aboutUs);
    }
}
