using UnityEngine;
using System.Collections;

public class DefaultBlasterScript : MonoBehaviour {

    void OnBecameInvisible() {
        DestroyThis();
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag.Equals("Enemy")) {
            col.GetComponent<EnemyScript>().GiveDamage(2);
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
        FindObjectOfType<PlayerControl>().SetAttack(true);
        Destroy(gameObject);
    }
}
