using UnityEngine;
using System.Collections;

public interface EnemyBehaviour : ObjectModel {

    int GetHealth();
    void SetHealth(int health);
    void GiveDamage(int damageValue);
    void Move(float speed);
    void Attack();
    void SetMovement(EnemyMovement movement);
    EnemyMovement GetMovement();
    void SetExplosionFX(GameObject explosion);
    GameObject GetExplosionFX();
}
