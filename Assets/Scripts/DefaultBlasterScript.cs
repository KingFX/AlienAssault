using UnityEngine;
using System.Collections;

public class DefaultBlasterScript : MonoBehaviour {

    private int bulletDamage = 2;

    void OnBecameInvisible() {
        DestroyThis();
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag.Equals("Enemy")) {
            col.GetComponent<EnemyBehaviour>().GiveDamage(bulletDamage);
            DestroyThis();
        }
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag.Equals("Enemy")) {
            col.gameObject.GetComponent<EnemyScript>().GiveDamage(2);
            DestroyThis();
        }
    }

    private void DestroyThis() {
        //FindObjectOfType<PlayerController>().SetAttack(true);
        Destroy(gameObject);
    }
}
