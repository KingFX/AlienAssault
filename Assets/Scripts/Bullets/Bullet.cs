using UnityEngine;
using System.Collections;


public interface Bullet : ObjectModel {

    void SetDamage(int damage);
    int GetDamage();
    void SetType(BulletType type);
    BulletType GetType();
}
