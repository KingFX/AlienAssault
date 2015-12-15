using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class GarbageCollector {

    private static Dictionary<ObjectModel, bool> objects = new Dictionary<ObjectModel, bool>();

    public static void Clean() {
        List<ObjectModel> flaggedDestroy = new List<ObjectModel>();
        foreach (KeyValuePair<ObjectModel, bool> entry in objects) {
            if (entry.Key is ObjectModel) {
                if (Vector3.Distance(entry.Key.GetModel().transform.position, Vector3.zero) > 20 || entry.Value == true) {
                    flaggedDestroy.Add(entry.Key);
                }
                if (entry.Key is EnemyBehaviour) {
                    if (((EnemyBehaviour)entry.Key).GetHealth() <= 0) {
                        flaggedDestroy.Add(entry.Key);
                    }
                }
            }
        }
        foreach (ObjectModel g in flaggedDestroy) {
            objects.Remove(g);
            if (((EnemyBehaviour)g).GetExplosionFX() != null) {
                //GameEngine.SpawnExplosion(((EnemyBehaviour)g).GetExplosionFX(), g.GetModel().transform.position);
                SpawnItem.AddItem(((EnemyBehaviour)g).GetExplosionFX(), g.GetModel().transform.position);
            }
            GameObject.Destroy(g.GetModel());
        }
    }

    public static void Clean(ObjectModel gObject) {
        if (objects.ContainsKey(gObject)) {
            objects[gObject] = true;
        }
    }

    public static void AddGameObject(ObjectModel o) {
        objects.Add(o, false);
    }

    public static List<ObjectModel> GetObjects() {
        List<ObjectModel> om = new List<ObjectModel>(objects.Keys);
        return om;
    }
}
