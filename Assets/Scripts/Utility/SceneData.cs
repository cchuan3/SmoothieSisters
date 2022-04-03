using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour
{
    public int currCustomer;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        currCustomer = 0;
    }

    public void NextCustomer() {
        currCustomer++;
    }
}
