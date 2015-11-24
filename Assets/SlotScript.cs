using UnityEngine;
using System.Collections;

public class SlotScript : MonoBehaviour {

    private Color black;
    private Color32 white;

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
    }

    void OnMouseExit() {
        GetComponent<SpriteRenderer>().color = black;
    }
}
