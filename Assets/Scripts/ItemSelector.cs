using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemSelector : MonoBehaviour {

    public List<GameObject> items = new List<GameObject>();
    public GameObject slot;
    private List<GameObject> spawnedItems = new List<GameObject>();
    private List<GameObject> spawnedSlotsBackgrounds = new List<GameObject>();
    public Transform itemParent;

    private GameObject selectedItem;

    private float yPos = 0;

	// Use this for initialization
	void Start () {
	    for(int i = 0; i < items.Count; i++){
            GameObject slotParent = new GameObject();
            //slot = Instantiate(slot, new Vector3(transform.position.x, yPos, transform.position.z), Quaternion.identity) as GameObject;
            slotParent.transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
            slotParent.transform.name = "Item Slot: " + (i + 1);
            slotParent.transform.SetParent(transform);

            GameObject itemSlotBackground = Instantiate(slot, new Vector3(transform.position.x, yPos, transform.position.z), Quaternion.identity) as GameObject;
            itemSlotBackground.transform.SetParent(slotParent.transform);
            spawnedSlotsBackgrounds.Add(itemSlotBackground);

            GameObject item = Instantiate(items[i], new Vector3(transform.position.x * 30, yPos * 30, transform.position.z), Quaternion.identity) as GameObject;
            item.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            item.transform.SetParent(itemParent);
            spawnedItems.Add(item);
            item.GetComponent<CanvasIcon>().SetItemNumber(i + 1);

            yPos += 0.055f;
        }
        for (int i = 0; i < items.Count - 1; i++) {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.0275f, transform.position.z);
            itemParent.position = new Vector3(itemParent.transform.position.x, itemParent.transform.position.y - (0.0275f * 30), itemParent.transform.position.z);
        }
	}

    public void SetSelectedItem(GameObject item) {
        selectedItem = item;
    }

    public GameObject GetSelectedItem() {
        return selectedItem;
    }
}
