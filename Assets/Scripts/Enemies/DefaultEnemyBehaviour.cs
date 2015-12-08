using UnityEngine;
using System.Collections;
using System;

public abstract class DefaultEnemyBehaviour : MonoBehaviour, EnemyBehaviour {

    //private EnemyMovement movement;

    private int health;
    private int attackDelay = 25;
    private float delay = 0;

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

    public void Attack() {
        if (GetComponent<Weapon>() != null) {
            GetComponent<Weapon>().Attack(-transform.up, new Vector3(this.transform.position.x, this.transform.position.y - this.transform.lossyScale.y / 2, this.transform.position.z));
        }
    }

    //public void SetMovement(EnemyMovement movement) {
    //    this.movement = movement;
    //}

    public EnemyMovement GetMovement() {
        //return movement;
        return GetComponent<EnemyMovement>();
    }
}
