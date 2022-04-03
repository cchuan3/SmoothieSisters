using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDCard : MonoBehaviour
{
    private enum AnimationState {
        Idle,
        WaitForClick,
        Shrink
    }
    private AnimationState state;
    private float timer;

    [SerializeField] LevelManager lm;

    // private void Awake() {
    //     state = AnimationState.Idle;
    // }

    private void Update() {
        if (state == AnimationState.WaitForClick) {
            if (Input.anyKey) {
                timer = 0.8f;
                state = AnimationState.Shrink;
            }
        }
        else if (state == AnimationState.Shrink) {
            Shrink();
            CountdownTimer();
        }
    }

    private void CountdownTimer() {
        timer -= Time.deltaTime;
    }

    public void StartAnimation() {
        state = AnimationState.WaitForClick;
    }

    private void Shrink() {
        if (timer <= 0) {
            state = AnimationState.Idle;
            lm.EndAnimation();
            gameObject.SetActive(false);
            return;
        }

        Vector3 newPosition = transform.position;
        newPosition.x -= 6f * Time.deltaTime;
        newPosition.y -= 2f * Time.deltaTime;
        transform.position = newPosition;

        Vector3 newScale = transform.localScale;
        newScale.x -= .5f * Time.deltaTime;
        newScale.y -= .5f * Time.deltaTime;
        newScale.z -= .5f * Time.deltaTime;
        transform.localScale = newScale;
    }
}
