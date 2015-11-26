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
        blinky.gameModel = (GameObject)Resources.Load("ImportAssets/Enemies/Blinky/Prefab/Blinky");
        blinky.icon = (GameObject)Resources.Load("ImportAssets/Enemies/Blinky/Prefab/Blinky");
        items.Add(blinky);

        DbItem scrull = new DbItem();
        scrull.id = 2;
        scrull.name = "Skrull";
        scrull.type = "enemy";
        scrull.gameModel = (GameObject)Resources.Load("ImportAssets/Enemies/Skrull/Prefab/Skrull");
        scrull.icon = (GameObject)Resources.Load("ImportAssets/Enemies/Skrull/Prefab/Skrull");
        items.Add(scrull);
    }

    public static List<DbItem> GetItems() {
        Debug.Log("Get Items");
        return items;
    }
}
