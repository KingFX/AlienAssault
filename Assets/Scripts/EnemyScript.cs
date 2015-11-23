using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    public float health;
    public float fireRateDelay;
    public float bulletSpeed;
    public float shotChance;
    public float movementSpeed;

    public GameObject[] aniParts;

    private float delay;
    private float switchDelay = 10;
    private bool aniEnabled = false;

    void Start() {
        //GetComponent<Rigidbody>().AddForce(Vector3.down * movementSpeed * Time.deltaTime);
        delay = fireRateDelay;
    }
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().AddForce(Vector3.down * movementSpeed * Time.deltaTime);
        if (aniEnabled) {
            if (switchDelay == 0) {
                aniParts[1].SetActive(!aniParts[1].activeSelf);
                aniParts[0].SetActive(!aniParts[0].activeSelf);
                switchDelay = 10;
                aniEnabled = false;
            } else {
                switchDelay--;
            }
        }
        if (delay == 0) {
            float rng = Random.Range(0f, 1f);
            if (rng > (1 - shotChance)) {
                Attack();
            }
            delay = fireRateDelay;
        } else {
            delay--;
        }
	}
    
    public void Attack() {
        //print("Attacking");
    }

    public void GiveDamage(float damage) {
        health -= damage;
        aniParts[1].SetActive(!aniParts[1].activeSelf);
        aniParts[0].SetActive(!aniParts[0].activeSelf);
        if (health <= 0) {
            health = 0;
            Destroy(gameObject);
        } else {
            aniEnabled = true;
        }
        print("Health- " + health);
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
