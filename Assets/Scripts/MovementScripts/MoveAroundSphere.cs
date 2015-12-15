using UnityEngine;
using System.Collections;
using System;

public class MoveAroundSphere : EnemyMovement {

    private GameObject enemy;
    private Vector3 point;

    public void Move(float speed) {
        enemy.transform.RotateAround(point, -Vector3.right, speed * Time.deltaTime);    
    }

    public void SetEnemy(GameObject enemy) {
        this.enemy = enemy;
    }

    public void SetPoint(Vector3 point) {
        this.point = point;
    }
}
