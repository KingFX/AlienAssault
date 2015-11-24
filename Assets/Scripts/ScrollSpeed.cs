using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrollSpeed : MonoBehaviour {

    public GameObject buttonLeft;
    public GameObject buttonRight;

    private float slowSpeed = 10;
    private float fastSpeed = 30;

    private bool slow = true;

    void Start() {
        buttonLeft.GetComponent<Button>().interactable = !slow;
        buttonRight.GetComponent<Button>().interactable = slow;
    }

    public float GetScrollSpeed() {
        if (slow) {
            return slowSpeed;
        } else {
            return fastSpeed;
        }
    }

    public void SetSpeedSlow(bool b) {

        buttonLeft.GetComponent<Button>().interactable = !b;
        buttonRight.GetComponent<Button>().interactable = b;
        slow = b;
    }
}
