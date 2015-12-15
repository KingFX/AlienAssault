using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    private GameObject targetPlayer;

    void Start() {
        targetPlayer = PlayerController.GetPlayers().GetModel();
    }

    void Update() {
        //targetPlayer = PlayerController.GetPlayers().GetModel();
        if (targetPlayer) {
            UnityEngine.Camera.main.transform.rotation = Quaternion.Euler(
                -targetPlayer.transform.position.y, targetPlayer.transform.position.x / 2, UnityEngine.Camera.main.transform.rotation.z);
        }
    }
}
