using UnityEngine;
using System.Collections;


public interface Bullet {

    void SetDamage(int damage);
    int GetDamage();
    void SetType(BulletType type);
    BulletType GetType();
    void SetModel(GameObject model);
    GameObject GetModel();
}
