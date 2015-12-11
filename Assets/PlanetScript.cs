using UnityEngine;
using System.Collections;

public class PlanetScript : MonoBehaviour {

    private float rotateSpeed = 10;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
	}
}
