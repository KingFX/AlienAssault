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
    private bool attackEnabled = true;

    private List<Bullet> bullets = new List<Bullet>();

    public void Attack(Vector3 direction, Vector3 pos) {
        for (int i = 0; i < bullets.Count; i++) {
            if (bullets[i].GetModel() != null) {
                if (Vector3.Distance(pos, bullets[i].GetModel().transform.position) > 8) {
                    GameObject.Destroy(bullets[i].GetModel());
                    bullets.Remove(bullets[i]);
                }
            } else {
                bullets.Remove(bullets[i]);
            }
        }
        //Debug.Log("Bullet Count: " + bullets.Count);
        if (delay <= 0 && bullets.Count == 0) {
            Bullet leftBullet = new PlazmaBullet();
            leftBullet.SetModel((GameObject)GameObject.Instantiate(bullet.GetModel(), new Vector3(pos.x - 0.25f, pos.y, pos.z), bullet.GetModel().transform.rotation));
            leftBullet.GetModel().GetComponent<Rigidbody>().AddForce(direction * bulletVelocity * Time.deltaTime);
            leftBullet.SetType(BulletType.PLAYER);
            bullets.Add(leftBullet);
            leftBullet.GetModel().AddComponent<CollisionController>();
            leftBullet.GetModel().GetComponent<CollisionController>().SetObject(leftBullet);
            //GarbageCollector.AddGameObject(leftBullet);

            Bullet rightBullet = new PlazmaBullet();
            rightBullet.SetModel((GameObject)GameObject.Instantiate(bullet.GetModel(), new Vector3(pos.x + 0.25f, pos.y, pos.z), bullet.GetModel().transform.rotation));
            rightBullet.GetModel().GetComponent<Rigidbody>().AddForce(direction * bulletVelocity * Time.deltaTime);
            rightBullet.SetType(BulletType.PLAYER);
            bullets.Add(rightBullet);
            rightBullet.GetModel().AddComponent<CollisionController>();
            rightBullet.GetModel().GetComponent<CollisionController>().SetObject(rightBullet);
            //GarbageCollector.AddGameObject(rightBullet);

            attackEnabled = false;
            delay = attackDelay;
        } else if (delay > 0) {
            delay--;
        }
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
