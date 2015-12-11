using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class AeroWeapon : Weapon {

    private Bullet bullet;
    private int damage = 1;
    private float bulletVelocity = 40000;
    private int attackDelay = 5;
    private float delay = 0;

    private List<GameObject> bullets = new List<GameObject>();

    void Awake() {
        //bullet = ItemDatabase.GetItemByName("PlazmaBullet");
    }

    void Update() {
        //for (int i = 0; i < bullets.Count; i++) {
        //    if (bullets[i].gameObject == null) {
        //        bullets.Remove(bullets[i]);
        //        FindObjectOfType<PlayerController>().SetAttack(true);
        //    }
        //}
    }

    public void Attack(Vector3 direction, Vector3 pos) {
        GameObject spawnedBulletLeft = (GameObject)GameObject.Instantiate(bullet.GetModel(), new Vector3(pos.x - 0.25f, pos.y, pos.z), bullet.GetModel().transform.rotation);
        spawnedBulletLeft.GetComponent<Rigidbody>().AddForce(direction * bulletVelocity * Time.deltaTime);
        //spawnedBulletLeft.GetComponent<PlazmaBullet>().SetType(BulletType.PLAYER);
        //spawnedBulletLeft.GetComponent<PlazmaBullet>().SetDamage(damage);
        bullets.Add(spawnedBulletLeft);
        GameObject spawnedBulletRight = (GameObject)GameObject.Instantiate(bullet.GetModel(), new Vector3(pos.x + 0.25f, pos.y, pos.z), bullet.GetModel().transform.rotation);
        spawnedBulletRight.GetComponent<Rigidbody>().AddForce(direction * bulletVelocity * Time.deltaTime);
        //spawnedBulletRight.GetComponent<PlazmaBullet>().SetDamage(damage);
        //spawnedBulletRight.GetComponent<PlazmaBullet>().SetType(BulletType.PLAYER);
        bullets.Add(spawnedBulletRight);
        delay = attackDelay * Time.deltaTime;
    }

    public void SetWeaponBullet(Bullet bullet) {
        this.bullet = bullet;
        bullet.SetDamage(damage);
    }



    //public void DestroyBullet(GameObject bullet) {
    //    FindObjectOfType<PlayerControl>().SetAttack(true);
    //    Destroy(bullet);
    //}
}
