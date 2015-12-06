using UnityEngine;
using System.Collections;

public class CanvasIcon : MonoBehaviour {

    private Vector3 iconPos;
    private int itemNumber;
    private bool followCursor = false;
    private bool docked = true;

    void Start() {
        iconPos = transform.position;
        print(iconPos);
        print(transform.position);
    }

    void Update() {
        if (followCursor) {
            var mousePos = Input.mousePosition;
            mousePos.z = 15;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = mousePos;
        }
    }


    public void SetItemNumber(int number) {
        itemNumber = number;
    }

    public int GetItemNumber() {
        return itemNumber;
    }

    void OnMouseOver() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            if (!followCursor) {
                followCursor = true;
                FindObjectOfType<ItemSelector>().SetSelectedItem(gameObject);
            } else if (followCursor && !FindObjectOfType<SlotScript>().IsMouseOver()) {
                followCursor = false;
                transform.position = new Vector3(iconPos.x, iconPos.y + Camera.main.transform.position.y, iconPos.z);
                FindObjectOfType<ItemSelector>().SetSelectedItem(null);
            }
        }
    }
}
