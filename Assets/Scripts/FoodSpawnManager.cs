using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawnManager : MonoBehaviour
{
    public GameObject FoodPrefab;
    [SerializeField] private float startDelay;
    [SerializeField] private float repeatRate;
    [SerializeField] private float spawnRange;
    [SerializeField] private float spawnHeight;

    [SerializeField] private FoodSprites fs;

    public void StartSpawning()
    {
        InvokeRepeating("SpawnFood", startDelay, repeatRate);
    }

    public void StopSpawning() {
        CancelInvoke();
    }

    // Update is called once per frame
    private void SpawnFood()
    { 
        var position = new Vector3(Random.Range(-spawnRange, spawnRange), spawnHeight, 0);
        DroppingFood newFood = Instantiate(FoodPrefab, position, FoodPrefab.transform.rotation).GetComponent<DroppingFood>();
        newFood.SetFS(fs);
    }
}
