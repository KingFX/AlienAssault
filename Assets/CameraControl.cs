using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public Camera myCam;

    private const float scrollSpeed = 10;
    private const float scrollWheelSpeed = 50;

    // Update is called once per frame
    void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            if (hit.collider.name.Equals("TopBar")) {
                transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
            } else if (hit.collider.name.Equals("BottomBar") && transform.position.y > 0) {
                    transform.Translate(-Vector3.up * scrollSpeed * Time.deltaTime);
            }
        }

        float mouseScrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (mouseScrollWheel > 0f) {
            transform.Translate(Vector3.up * scrollWheelSpeed * Time.deltaTime);
        } else if (mouseScrollWheel < 0f && transform.position.y > 0) {
            transform.Translate(-Vector3.up * scrollWheelSpeed * Time.deltaTime);
        }
        if (transform.position.y < 0) {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
}
