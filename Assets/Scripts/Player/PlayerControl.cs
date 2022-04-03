using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float leftLockPos;
    [SerializeField] private float rightLockPos;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Center() {
        // Center player on screen
        transform.position = new Vector3(0f, 0f, -1.95f);
    }

    private void Movement() {
        // Smooth L/R movement, locked to certain area of screen
        float dir = Input.GetAxis("Horizontal");
        Vector3 pos = transform.position;
        pos.x += dir * moveSpeed * Time.deltaTime;
        if (pos.x > rightLockPos) pos.x = rightLockPos;
        else if (pos.x < leftLockPos) pos.x = leftLockPos;

        transform.position = pos;
    }
}
