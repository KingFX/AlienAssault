using UnityEngine;
using System.Collections;
using System;

public class MoveRightAngle : MonoBehaviour, EnemyMovement {

    private float spacer = 0.5f;
    private float rightDistance = 16;
    private float leftDistance = 16;
    private bool angleRight = true;


    void Start() {
        rightDistance = this.transform.position.x + rightDistance;
        leftDistance = this.transform.position.x - leftDistance;
    }

    public void Move(float speed) {
        speed = speed * 1.5f;
        if (this.transform.position.y < FindObjectOfType<GameEngine>().GetScreenHeight() / 2) {
            if (angleRight) {
                this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x + 1, this.transform.position.y - 1), speed * Time.deltaTime);
                if (this.transform.position.x > FindObjectOfType<GameEngine>().GetScreenWidth() / 2 - spacer ||
                this.transform.position.x > rightDistance) {
                    angleRight = false;
                }
            } else {
                this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x - 1, this.transform.position.y - 1), speed * Time.deltaTime);

                if (this.transform.position.x < -FindObjectOfType<GameEngine>().GetScreenWidth() / 2 + spacer ||
                    this.transform.position.x < leftDistance) {
                    angleRight = true;
                }
            }
        } else {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x, this.transform.position.y - 1), speed * Time.deltaTime);
        }
    }
}
