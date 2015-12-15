using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class DefaultPlayer : PlayerBehaviour, ObjectModel {

    private List<Weapon> weapons = new List<Weapon>();
    private GameObject shipModel;

    public int PlayerId {
        get {
            throw new NotImplementedException();
        }

        set {
            throw new NotImplementedException();
        }
    }

    public int GetHealth() {
        throw new NotImplementedException();
    }

    public Vector3 GetPosition() {
        return shipModel.transform.position;
    }

    public void Move(Vector3 movePos) {
        shipModel.transform.position = movePos;
    }

    public void SetHealth(int health) {
        throw new NotImplementedException();
    }

    public GameObject GetModel() {
        return shipModel;
    }

    public void SetModel(GameObject model) {
        shipModel = model;
    }

    public void Attack() {
        foreach (Weapon weapon in weapons) {
            weapon.Attack(shipModel.transform.up, shipModel.transform.position);
        }
        //Vector3 weaponSpawn = ship.transform.Find("WeaponSpawn").transform.position;
        //if (ship.GetComponent<Weapon>() != null) {
        //    ship.GetComponent<Weapon>().Attack(ship.transform.up, weaponSpawn);
        //}
    }

    public void AddWeapon(Weapon weapon) {
        weapons.Add(weapon);
    }

    public List<Weapon> GetWeapons() {
        return weapons;
    }
}
