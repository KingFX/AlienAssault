using UnityEngine;
using System.Collections;
using System;

public class PlazmaBullet : Bullet, ObjectModel {

    private int damage = 1;
    private BulletType type;
    private GameObject model;

    void OnBecameInvisible() {
        //GameObject.Destroy(model);
    }

    public void SetDamage(int damage) {
        this.damage = damage;
    }

    public int GetDamage() {
        return damage;
    }

    public void SetType(BulletType type) {
        this.type = type;
    }

    public BulletType GetType() {
        return type;
    }

    public void SetModel(GameObject model) {
        this.model = model;
    }

    public GameObject GetModel() {
        return model;
    }
}
