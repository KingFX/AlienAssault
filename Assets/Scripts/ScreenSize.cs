using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ScreenSize : MonoBehaviour {

    public bool none = false;
    public bool smallScreenSpace = true;

    public GameObject bigBorder;
    public GameObject smallBorder;
	
	// Update is called once per frame
	void Update () {
        if (none) {
            bigBorder.SetActive(false);
            smallBorder.SetActive(false);
        } else if (smallScreenSpace) {
            bigBorder.SetActive(true);
            smallBorder.SetActive(false);
        } else {
            smallBorder.SetActive(true);
            bigBorder.SetActive(false);
        }
	}
}
