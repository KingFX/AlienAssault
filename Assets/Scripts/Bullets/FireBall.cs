using UnityEngine;
using System.Collections;
using System;

public class FireBall : Bullet {

    private GameObject model;
    private int damage = 1;
    private BulletType type;

    public int GetDamage() {
        return damage;
    }

    public GameObject GetModel() {
        return model;
    }

    public void SetDamage(int damage) {
        this.damage = damage;
    }

    public void SetModel(GameObject model) {
        this.model = model;
    }

    public void SetType(BulletType type) {
        this.type = type;
    }

    BulletType Bullet.GetType() {
        return type;
    }
}
