using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridGenerator : MonoBehaviour {

    public GameObject slot;
    private int rowsCount = 0;
    private int rowLength = 8;

    private const float startXPosValue = -8.75f;
    private float startXPos;
    private float startYPos;
    private float spacer = 2.5f;

    private List<GameObject> rowSlots = new List<GameObject>();

	// Use this for initialization
	void Start () {
        startXPos = startXPosValue;
        AddRow();
    }

    public void AddRow() {
        for (int i = 0; i < rowLength; i++) {
            GameObject rowSlot = Instantiate(slot, new Vector3(startXPos, startYPos, 0), Quaternion.identity) as GameObject;
            rowSlot.transform.SetParent(GameObject.Find("Slots").transform);
            rowSlot.name = "Row: " + (rowsCount + 1) + " Slot: " + (i + 1);
            rowSlots.Add(rowSlot);
            startXPos += spacer;
        }
        startXPos = startXPosValue;
        startYPos += spacer;
        rowsCount++;
    }

    public void RemoveRow() {
        if (rowsCount > 0) {
            for (int i = 0; i < rowLength; i++) {
                Destroy(rowSlots[rowSlots.Count - rowLength + i]);
                rowSlots.RemoveAt(rowSlots.Count - rowLength + i);
            }
            startYPos -= spacer;
            rowsCount--;
        }
    }
}
