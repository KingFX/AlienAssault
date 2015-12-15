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

        DbItem fireBall = new DbItem();
        fireBall.id = 4;
        fireBall.name = "FireBall";
        fireBall.type = "bullet";
        fireBall.gameModel = (GameObject)Resources.Load("ImportAssets/Enemies/Skrull/Weapon/Blaster/Prefab/FireBall");
        fireBall.icon = (GameObject)Resources.Load("ImportAssets/Enemies/Skrull/Weapon/Blaster/Prefab/FireBall");
        items.Add(fireBall);

        DbItem plazmaBullet = new DbItem();
        plazmaBullet.id = 5;
        plazmaBullet.name = "PlazmaBullet";
        plazmaBullet.type = "bullet";
        plazmaBullet.gameModel = (GameObject)Resources.Load("ImportAssets/Weapons/PlazmaBullet/Prefab/PlazmaBullet");
        plazmaBullet.icon = (GameObject)Resources.Load("ImportAssets/Weapons/PlazmaBullet/Prefab/PlazmaBullet");
        items.Add(plazmaBullet);

        DbItem aero = new DbItem();
        aero.id = 6;
        aero.name = "Aero";
        aero.type = "playerShip";
        aero.gameModel = (GameObject)Resources.Load("ImportAssets/PlayerShips/Aero/Prefab/Aero");
        aero.icon = (GameObject)Resources.Load("ImportAssets/PlayerShips/Aero/Prefab/Aero");
        items.Add(aero);

        DbItem striker = new DbItem();
        striker.id = 7;
        striker.name = "Striker";
        striker.type = "enemy";
        striker.gameModel = (GameObject)Resources.Load("ImportAssets/Enemies/Striker/GameObject/Striker");
        striker.icon = (GameObject)Resources.Load("ImportAssets/Enemies/Striker/GameObject/Striker");
        items.Add(striker);

        DbItem explosionOrange = new DbItem();
        explosionOrange.id = 8;
        explosionOrange.name = "explosionOrange";
        explosionOrange.type = "explosion";
        explosionOrange.gameModel = (GameObject)Resources.Load("ImportAssets/ExplosionFX/ExplosionOrange");
        explosionOrange.icon = (GameObject)Resources.Load("ImportAssets/ExplosionFX/ExplosionOrange");
        items.Add(explosionOrange);
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
            if (items[i].name.ToLower().Equals(name.ToLower())) {
                item = items[i];
            }
        }
        return item;
    }
}
