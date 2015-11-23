using UnityEngine;
using System.Collections;

public class BackgroundScript : MonoBehaviour {

    public void PlayerPosY(float posY) {
        transform.position = new Vector3(transform.position.x, -posY * 0.2f, transform.position.z);
    }
}
