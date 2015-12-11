using UnityEngine;
using System.Collections;

public interface EnemyMovement {

    void Move(float speed);
    void SetEnemy(GameObject enemy);
}
