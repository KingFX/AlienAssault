using UnityEngine;
using System.Collections;   

public class Blinky : MonoBehaviour, EnemyBehaviour {

    public void Move(float speed) {
        transform.Translate(Vector3.down * speed);
    }
}
