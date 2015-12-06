using UnityEngine;
using System.Collections;

public interface EnemyBehaviour {

    int GetHealth();
    void SetHealth(int health);
    void GiveDamage(int damageValue);
    void Move(float speed);
    //void SetMovement(EnemyMovement movement);
    EnemyMovement GetMovement();
}
