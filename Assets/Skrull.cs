using UnityEngine;
using System.Collections;

public class Skrull : MonoBehaviour, EnemyBehaviour {

    public bool isVisible = true;

    public void Move(float speed) {
        transform.Translate(Vector3.down * speed);
    }

    void OnBecameInvisible() {
        isVisible = false;
    }
}