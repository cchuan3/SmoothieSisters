using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlenderAnimation : MonoBehaviour
{
    private enum AnimationState {
        Idle,
        Shaking,
        Grow
    }
    private AnimationState state;
    private float timer;

    [SerializeField] Blending sceneController;

    private void Awake() {
        state = AnimationState.Idle;
    }

    private void Update() {
        switch(state) {
            case AnimationState.Shaking:
                Shake();
                break;
            case AnimationState.Grow:
                Grow();
                break;
        }
        CountdownTimer();
    }

    private void CountdownTimer() {
        timer -= Time.deltaTime;
    }

    public void StartAnimation() {
        state = AnimationState.Shaking;
        timer = 2f;
    }

    private void Shake() {
        if (timer <= 0) {
            state = AnimationState.Grow;
            timer = 0.5f;
            transform.rotation = Quaternion.identity;
            return;
        }

        transform.Rotate(new Vector3(0, 0, (timer % .08f < 0.04f) ? 40 : -40) * Time.deltaTime, Space.Self);
    }

    private void Grow() {
        if (timer <= 0) {
            state = AnimationState.Idle;
            sceneController.StartWaiting();
            return;
        }

        Vector3 newScale = transform.localScale;
        newScale.x += 2 * Time.deltaTime;
        newScale.y += 2 * Time.deltaTime;
        newScale.z += 2 * Time.deltaTime;
        transform.localScale = newScale;

        Vector3 newPosition = transform.position;
        newPosition.y += 2 * Time.deltaTime;
        transform.position = newPosition;
    }
}
