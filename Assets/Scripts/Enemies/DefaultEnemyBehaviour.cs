using UnityEngine;
using System.Collections;
using System;

public abstract class DefaultEnemyBehaviour : EnemyBehaviour, ObjectModel {

    //private EnemyMovement movement;

    private int health;
    private int attackDelay = 25;
    private float delay = 0;
    private GameObject model;
    private Weapon weapon;
    private EnemyMovement movement;
    private GameObject explosion;

    public void SetHealth(int health) {
        this.health = health;
    }

    public int GetHealth() {
        return health;
    }

    public void GiveDamage(int damageValue) {
        health -= damageValue;
    }

    private float hitDistance;
    public void Move(float speed) {
        //(EnemyBehaviour)model.transform
        //movement.Move(speed);
        //Move(speed);
        //RaycastHit hit;
        //if (Physics.SphereCast(model.transform.position, 0.5f,-model.transform.up, out hit, 0.5f)) {
        //    //if (hit.distance < 0.25f) {
        //        Debug.Log("Hit");
        //    //Debug.Log("HitType: " + hit.transform);
        //    //if (hit.transform is Bullet) {
        //            //if (((Bullet)hit.).GetType().Equals(BulletType.PLAYER)) {
        //            //    GiveDamage(((Bullet)hit.transform).GetDamage());
        //            //    GameObject.Destroy(((Bullet)hit.transform).GetModel());
        //            //}
        //        //}
        //    //}
        //}
        movement.Move(speed);
        //model.transform.position = Vector3.MoveTowards(model.transform.position, new Vector3(model.transform.position.x, model.transform.position.y - 5f), speed * Time.deltaTime);
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

    public void SetModel(GameObject model) {
        this.model = model;
        model.AddComponent<CollisionController>();
        //model.GetComponent<CollisionController>().SetColliderSize(0.25f, 0.25f, 0.25f);
        //model.GetComponent<Collider>().isTrigger = true;
        //col.SetGameObject(model);
        //col.SetColliderSize(0.25f, 0.25f, 0.25f);
    }

    public GameObject GetModel() {
        return model;
    }

    public void SetMovement(EnemyMovement movement) {
        this.movement = movement;
    }

    public void SetExplosionFX(GameObject explosion) {
        this.explosion = explosion;
    }

    public GameObject GetExplosionFX() {
        return this.explosion;
    }

    //void OnTriggerEnter(Collider col) {
    //    Debug.Log("Enemy Hit");
    //    if (col is Bullet) {
    //        if (((Bullet)col).GetType().Equals(BulletType.PLAYER)) {
    //            GiveDamage(((Bullet)col).GetDamage());
    //            GameObject.Destroy(((Bullet)col).GetModel());
    //        }
    //    }
    //}
}
