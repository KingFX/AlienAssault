using UnityEngine;
using System.Collections;

public interface Weapon {

    void Attack(Vector3 direction, Vector3 pos);
    int GetDamage();
}
