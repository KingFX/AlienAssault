using UnityEngine;
using System.Collections;

public class SlotScript : MonoBehaviour {

    private Color black;
    private Color32 white;
    private int slotNumber = 0;
    private static bool cursorOver = false;

	// Use this for initialization
	void Start () {
        black = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = black;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseEnter () {
        GetComponent<SpriteRenderer>().color = Color.white;
        cursorOver = true;
    }

    void OnMouseExit() {
        GetComponent<SpriteRenderer>().color = black;
        cursorOver = false;
    }

    void OnMouseOver() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            if (FindObjectOfType<ItemSelector>().GetSelectedItem() != null) {
                Instantiate(FindObjectOfType<ItemSelector>().GetSelectedItem(), transform.position, Quaternion.identity);
                slotNumber = FindObjectOfType<ItemSelector>().GetSelectedItem().GetComponent<CanvasIcon>().GetItemNumber();
            }
        }
    }

    public bool IsMouseOver() {
        return cursorOver;
    }
}
