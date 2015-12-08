using UnityEngine;
using System.Collections;
using System;

public class plazmaBullet : MonoBehaviour, Weapon {

    private GameObject model;
    private int damage = 1;
    private float bulletVelocity = 20000;
    private int attackDelay = 50;
    private float delay = 0;

    void Awake() {
        model = ItemDatabase.GetItemByName("PlazmaBullet").gameModel;
    }

    public void Attack(Vector3 direction, Vector3 pos) {
        if (delay <= 0) {
            GameObject bullet = (GameObject)Instantiate(model, new Vector3(pos.x, pos.y + this.transform.lossyScale.y, pos.z), model.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(direction * bulletVelocity * Time.deltaTime);
            delay = attackDelay * Time.deltaTime;
        } else {
            delay -= Time.deltaTime;
        }
    }

    public int GetDamage() {
        return damage;
    }
}
