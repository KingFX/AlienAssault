using UnityEngine;
using System.Collections;
using System;

public class MoveAroundSphere : EnemyMovement {

    private GameObject enemy;

    public void Move(float speed) {
        //enemy.transform.RotateAround();    
    }

    public void SetEnemy(GameObject enemy) {
        this.enemy = enemy;
    }
}
