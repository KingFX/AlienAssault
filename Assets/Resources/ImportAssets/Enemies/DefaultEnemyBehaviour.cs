using UnityEngine;
using System.Collections;
using System;

public abstract class DefaultEnemyBehaviour : MonoBehaviour, EnemyBehaviour {

    //private EnemyMovement movement;

    private int health;

    public void SetHealth(int health) {
        this.health = health;
    }

    public int GetHealth() {
        return health;
    }

    public void GiveDamage(int damageValue) {
        health -= damageValue;
    }

    public void Move(float speed) {
        //movement.Move(speed);
        GetComponent<EnemyMovement>().Move(speed);
        //transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(transform.position.x, transform.position.y - 5f), speed * Time.deltaTime);
    }

    //public void SetMovement(EnemyMovement movement) {
    //    this.movement = movement;
    //}

    public EnemyMovement GetMovement() {
        //return movement;
        return GetComponent<EnemyMovement>();
    }
}
