using UnityEngine;
using System.Collections;
using System;

public class SkrullWeapon : MonoBehaviour, Weapon {

    //private GameObject model;
    private int damage = 2;
    private float bulletVelocity = 20000;
    private int attackDelay = 50;
    private float delay = 0;
    private Bullet bullet;

    public void Attack(Vector3 direction, Vector3 pos) {
        if(delay <= 0) {
            GameObject spawnedBullet = (GameObject)Instantiate(bullet.GetModel(), new Vector3(pos.x, pos.y - this.transform.lossyScale.y, pos.z), bullet.GetModel().transform.rotation);
            spawnedBullet.GetComponent<Rigidbody>().AddForce(direction * bulletVelocity * Time.deltaTime);
            //spawnedBullet.GetComponent<PlazmaBullet>().SetType(B);
            //spawnedBullet.GetComponent<PlazmaBullet>().SetDamage(damage);
            delay = attackDelay * Time.deltaTime;
        } else {
            delay -= Time.deltaTime;
        }
    }

    public void SetWeaponBullet(Bullet bullet) {
        this.bullet = bullet;
    }
}
