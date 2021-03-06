﻿using UnityEngine;
using System.Collections;
using System;

public class MoveDown : EnemyMovement {

    private GameObject enemy;

    public void Move(float speed) {
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 2), speed * Time.deltaTime);
    }

    public void SetEnemy(GameObject enemy) {
        this.enemy = enemy;
    }
}
