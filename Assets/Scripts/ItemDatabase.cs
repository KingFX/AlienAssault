using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public static class ItemDatabase {

    private static List<DbItem> items = new List<DbItem>();

	static ItemDatabase() {
        Debug.Log("Initializing");
        DbItem blinky = new DbItem();
        blinky.id = 1;
        blinky.name = "Blinky";
        blinky.type = "enemy";
        blinky.health = 3;
        blinky.gameModel = (GameObject)Resources.Load("ImportAssets/Enemies/Blinky/Prefab/Blinky");
        blinky.icon = (GameObject)Resources.Load("ImportAssets/Enemies/Blinky/Prefab/Blinky");
        items.Add(blinky);

        DbItem scrull = new DbItem();
        scrull.id = 2;
        scrull.name = "Skrull";
        scrull.type = "enemy";
        scrull.health = 5;
        scrull.gameModel = (GameObject)Resources.Load("ImportAssets/Enemies/Skrull/Prefab/Skrull");
        scrull.icon = (GameObject)Resources.Load("ImportAssets/Enemies/Skrull/Prefab/Skrull");
        items.Add(scrull);

        DbItem redReaper = new DbItem();
        redReaper.id = 3;
        redReaper.name = "RedReaper";
        redReaper.type = "enemy";
        redReaper.health = 2;
        redReaper.gameModel = (GameObject)Resources.Load("ImportAssets/Enemies/RedReaper/GameObject/RedReaper");
        redReaper.icon = (GameObject)Resources.Load("ImportAssets/Enemies/RedReaper/GameObject/RedReaper");
        items.Add(redReaper);

        DbItem skrullWeapon = new DbItem();
        skrullWeapon.id = 4;
        skrullWeapon.name = "SkrullWeapon";
        skrullWeapon.type = "weapon";
        skrullWeapon.gameModel = (GameObject)Resources.Load("ImportAssets/Enemies/Skrull/Weapon/Blaster/Prefab/SkrullWeapon");
        skrullWeapon.icon = (GameObject)Resources.Load("ImportAssets/Enemies/Skrull/Weapon/Blaster/Prefab/SkrullWeapon");
        items.Add(skrullWeapon);
    }

    public static List<DbItem> GetItems() {
        Debug.Log("Get Items");
        return items;
    }

    public static DbItem GetItemByFileId(string id) {
        int intId = int.Parse(id);
        return items[intId];
    }

    public static DbItem GetItemByName(string name) {
        DbItem item = null;
        for (int i = 0; i < items.Count; i++) {
            if (items[i].name.Equals(name)) {
                item = items[i];
            }
        }
        return item;
    }
}
