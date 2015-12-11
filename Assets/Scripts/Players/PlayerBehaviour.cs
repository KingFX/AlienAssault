using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface PlayerBehaviour {

    int PlayerId {get; set;}
    int GetHealth();
    void SetHealth(int health);
    Vector3 GetPosition();
    void Move(Vector3 movePos);
    void SetModel(GameObject model);
    GameObject GetModel();
    void Attack();
    void AddWeapon(Weapon weapon);
    List<Weapon> GetWeapons();
}
