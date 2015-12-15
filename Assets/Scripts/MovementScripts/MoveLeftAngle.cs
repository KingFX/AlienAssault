using UnityEngine;
using System.Collections;
using System;

public class MoveLeftAngle : EnemyMovement, ScreenAware {

	private float spacer = 0.5f;
    private float rightDistance = 16;
    private float leftDistance = 16;
    private bool angleRight = false;
    private GameObject enemy;
    private float screenX;
    private float screenY;

    public void SetEnemy(GameObject enemy) {
        this.enemy = enemy;
    }

    public void Move(float speed) {
        speed = speed * 1.5f;
        //Debug.Log("Enemy: " + enemy);
        if (enemy.transform.position.y < screenY / 2) {
            if (angleRight) {
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, new Vector3(enemy.transform.position.x + 1, enemy.transform.position.y - 1), speed * Time.deltaTime);
                if (enemy.transform.position.x > screenX / 2 - spacer ||
                enemy.transform.position.x > rightDistance) {
                    angleRight = false;
                }
            } else {
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, new Vector3(enemy.transform.position.x - 1, enemy.transform.position.y - 1), speed * Time.deltaTime);

                if (enemy.transform.position.x < -screenX / 2 + spacer ||
                    enemy.transform.position.x < leftDistance) {
                    angleRight = true;
                }
            }
        } else {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 1), speed * Time.deltaTime);
        }
    }

    public void SetScreenDimensions(float x, float y) {
        screenX = x;
        screenY = y;
        rightDistance = enemy.transform.position.x + rightDistance;
        leftDistance = enemy.transform.position.x - leftDistance;
    }
}
