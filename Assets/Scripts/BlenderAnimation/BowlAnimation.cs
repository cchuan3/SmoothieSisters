using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlAnimation : MonoBehaviour
{
    [SerializeField] private BlenderAnimation blender;
    [SerializeField] private Transform foodSpawn;
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private FoodSprites fs;
    public List<FoodType> collectedFood;
    private int currFood;

    private enum AnimationState {
        Turn,
        Shake,
        Remove,
        Idle
    }
    private AnimationState state;

    private float timer;

    private void Awake() {
        state = AnimationState.Idle;
        currFood = 0;
    }

    private void Update() {
        Movement();
    }

    public void StartAnimation() {
        state = AnimationState.Turn;
        timer = 1f;
    }

    private void CountdownTimer() {
        timer -= Time.deltaTime;
    }

    private void Movement() {
        switch(state) {
            case AnimationState.Turn:
                Turn();
                break;
            case AnimationState.Shake:
                Shake();
                break;
            case AnimationState.Remove:
                Remove();
                break;
        }
        CountdownTimer();
    }

    private void Turn() {
        if (timer <= 0) {
            state = AnimationState.Shake;
            timer = 1.5f;
            return;
        }

        Vector3 newPosition = transform.position;
        newPosition.x += 0.5f * Time.deltaTime;
        newPosition.y -= 1.5f * Time.deltaTime;
        transform.position = newPosition;

        transform.Rotate(new Vector3(0, 0, -60) * Time.deltaTime, Space.Self);
    }

    private void Shake() {
        if (timer <= 0) {
            state = AnimationState.Remove;
            timer = 2f;
            return;
        }

        
        Vector3 newPosition = transform.position;
        newPosition.y += (timer % .25f < 0.12) ? 1f * Time.deltaTime : -1f * Time.deltaTime;
        transform.position = newPosition;

        if (timer % .15f < 0.01) {
            GameObject food = Instantiate(foodPrefab, foodSpawn.position, Quaternion.identity);
            DroppingFood df = food.GetComponent<DroppingFood>();
            df.SetType(collectedFood[currFood]);
            df.SetFS(fs);
            currFood++;
        }
    }

    private void Remove() {
        if (timer <=0) {
            state = AnimationState.Idle;
            blender.StartAnimation();
            return;
        }
        
        Vector3 newPosition = transform.position;
        newPosition.x -= 0.5f * Time.deltaTime;
        newPosition.y += 1.5f * Time.deltaTime;

        if (transform.rotation.eulerAngles.z > 90)
            transform.Rotate(new Vector3(0, 0, 60) * Time.deltaTime, Space.Self);
        else {
            newPosition.x -= 3f * Time.deltaTime;
        }
        transform.position = newPosition;
    }
}
