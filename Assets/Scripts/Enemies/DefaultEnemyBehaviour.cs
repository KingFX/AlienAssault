using UnityEngine;
using System.Collections;
using System;

public abstract class DefaultEnemyBehaviour :  EnemyBehaviour {

    //private EnemyMovement movement;

    private int health;
    private int attackDelay = 25;
    private float delay = 0;
    private GameObject model;
    private Weapon weapon;
    private EnemyMovement movement;

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
        //Move(speed);
        //GetComponent<EnemyMovement>().Move(speed);
        model.transform.position = Vector3.MoveTowards(model.transform.position, new Vector3(model.transform.position.x, model.transform.position.y - 5f), speed * Time.deltaTime);
    }

    public abstract void Attack();

    //public void Attack() {
    //    //weapon.Attack(Vector3.down, model.transform.position);
    //    //if (GetComponent<Weapon>() != null) {
    //    //    GetComponent<Weapon>().Attack(-transform.up, new Vector3(this.transform.position.x, this.transform.position.y - this.transform.lossyScale.y / 2, this.transform.position.z));
    //    //}
    //}

    //public void SetMovement(EnemyMovement movement) {
    //    this.movement = movement;
    //}

    public EnemyMovement GetMovement() {
        //return movement;
        return movement;
    }

    void OnTriggerEnter(Collider col) {
        if (col.GetComponent<Bullet>() != null) {
            if (col.GetComponent<Bullet>().GetType().Equals(BulletType.PLAYER)) {
                GiveDamage(col.GetComponent<Bullet>().GetDamage());
                GameObject.Destroy(col.gameObject);
            }
        }
    }

    public void SetModel(GameObject model) {
        this.model = model;
    }

    public GameObject GetModel() {
        return model;
    }
}
