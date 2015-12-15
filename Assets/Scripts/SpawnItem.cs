using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class SpawnItem {

    //private static List<GameObject> items = new List<GameObject>();
    private static Dictionary<GameObject, Vector3> items = new Dictionary<GameObject, Vector3>();

    public static void AddItem(GameObject item, Vector3 pos) {
        items.Add(item, pos);
    }

    public static Dictionary<GameObject, Vector3> GetItems() {
        return items;
    }

    public static void RemoveItem(GameObject item) {
        items.Remove(item);
    }
}
