using UnityEngine;
using System.Collections;
using System;

public class MoveDown : MonoBehaviour, EnemyMovement {

    public void Move(float speed) {
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x, this.transform.position.y - 2), speed * Time.deltaTime);
    }
}
