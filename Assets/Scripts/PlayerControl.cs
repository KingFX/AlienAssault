using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public GameObject[] thrusters;
    public GameObject weapon;

    public float movementSpeed = 0;
    public float rotationSpeed = 0;
    public float bulletSpeed = 0;
    public float fireRateDelay;

    private float smooth = 0.01F;
    public float tiltAngle = 15.0F;
    private float minRotation;
    private float maxRotation;

    private float rotate = 0;

    private bool setLeftOff = false;
    private bool setRightOff = false;
    private bool leftOffToggle = false;
    private bool rightOffToggle = false;

    private float hPadding = 1f;
    private float vPadding = 1.5f;
    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    private bool attackEnabled = true;
    private float delay;

    private const float smoothMotion = 0.8f;
    private const float maxMovementSpeed = 7.5f;

    // Use this for initialization
    void Start() {
        //Cursor.visible = false;

        delay = fireRateDelay;
        thrusters[0].SetActive(false);
        thrusters[3].SetActive(false);

        float distance = transform.position.z - UnityEngine.Camera.main.transform.position.z;
        Vector3 leftMost = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xMin = leftMost.x + hPadding;
        xMax = rightMost.x - hPadding;

        Vector3 bottomMost = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 topMost = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(0, 1.45f, distance));
        yMin = bottomMost.y + vPadding;
        yMax = topMost.y + 0.50f;

        minRotation = 90 - tiltAngle;
        maxRotation = 90 + tiltAngle;
    }

    // Update is called once per frame
    void Update() {
        Movement();
        Attack();
    }

    private void Movement() {
        float mousePosX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        float mousePosY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;

        float distance = Vector3.Distance(transform.position, new Vector3(mousePosX, mousePosY, transform.position.z));
        if (distance > maxMovementSpeed) {
            distance = maxMovementSpeed;
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(mousePosX, mousePosY, transform.position.z), movementSpeed * (distance / smoothMotion) * Time.deltaTime);

        //if (mousePosX > newPos.x) {
        //    newPos = Vector3.MoveTowards(newPos, Vector3.right, movementSpeed);
        //    //newPos += Vector3.right * movementSpeed * Time.deltaTime;
        //    //newPos = new Vector3(newPos.x + movementSpeed, newPos.y, newPos.z);
        //}
        //if (mousePosX < newPos.x) {
        //    newPos += Vector3.right * -movementSpeed * Time.deltaTime;
        //    //newPos = new Vector3(newPos.x - movementSpeed, newPos.y, newPos.z);
        //}
        //if (mousePosY > newPos.y) {
        //    newPos += Vector3.up * movementSpeed * Time.deltaTime;
        //    //newPos = new Vector3(newPos.x, newPos.y + movementSpeed, newPos.z);
        //}
        //if (mousePosY < newPos.y) {
        //    newPos += Vector3.up * -movementSpeed * Time.deltaTime;
        //    //newPos = new Vector3(newPos.x, newPos.y - movementSpeed, newPos.z);
        //}
        //transform.position = newPos;

        //FindObjectOfType<BackgroundScript>().PlayerPosY(transform.position.y);
        //Mathf.Clamp(90, minRotation, maxRotation);
        //rotate += Input.GetAxis("Mouse Y") * smooth;
        //rotate = Mathf.Clamp(rotate, minRotation, maxRotation);

        //if (Input.GetKey(KeyCode.W)) {
        //    setLeftOff = false;
        //    setRightOff = false;
        //    if (thrusters[3].activeSelf == false) thrusters[3].SetActive(true);
        //    if (thrusters[0].activeSelf == false) thrusters[0].SetActive(true);
        //    transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
        //} else if (Input.GetKeyUp(KeyCode.W)) {
        //    setLeftOff = true;
        //    setRightOff = true;
        //}
        //if (Input.GetKey(KeyCode.S)) {
        //    transform.Translate(-Vector3.up * movementSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.A)) {
        //    setRightOff = false;
        //    rightOffToggle = true;
        //    if (thrusters[3].activeSelf == false) thrusters[3].SetActive(true);
        //    transform.Translate(-Vector3.right * movementSpeed * Time.deltaTime, Space.World);
        //    if (transform.localEulerAngles.y < rotate + (maxRotation - minRotation)) {
        //        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.eulerAngles.y + rotationSpeed, transform.eulerAngles.z);
        //    }
        //} else if (transform.localEulerAngles.y > 90) {
        //    if (rightOffToggle) {
        //        rightOffToggle = false;
        //        setRightOff = true;
        //    }
        //    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.eulerAngles.y + -rotationSpeed, transform.eulerAngles.z);
        //}
        //if (Input.GetKey(KeyCode.D)) {
        //    setLeftOff = false;
        //    leftOffToggle = true;
        //    if (thrusters[0].activeSelf == false) thrusters[0].SetActive(true);
        //    transform.Translate(Vector3.right * movementSpeed * Time.deltaTime, Space.World);
        //    if (transform.localEulerAngles.y > rotate) {
        //        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.eulerAngles.y + -rotationSpeed, transform.eulerAngles.z);
        //    }
        //} else if (transform.localEulerAngles.y < 90) {
        //    if (leftOffToggle) {
        //        leftOffToggle = false;
        //        setLeftOff = true;
        //    }
        //    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.eulerAngles.y + rotationSpeed, transform.eulerAngles.z);
        //}
        //if (setLeftOff) {
        //    thrusters[0].SetActive(false);
        //    setLeftOff = false;
        //}
        //if (setRightOff) {
        //    thrusters[3].SetActive(false);
        //    setRightOff = false;
        //}

        //float newX = Mathf.Clamp(transform.position.x, xMin, xMax);
        //float newY = Mathf.Clamp(transform.position.y, yMin, yMax - 6f);
        //transform.position = new Vector3(newX, newY, transform.position.z);
    }

    private void Attack() {
        if (Input.GetKey(KeyCode.Space) && attackEnabled && delay == 0) {
            Vector3 weaponSpawn = transform.Find("WeaponSpawn").transform.position;
            GameObject bullet = Instantiate(weapon, weaponSpawn, transform.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(Vector3.up * bulletSpeed * Time.deltaTime);
            attackEnabled = false;
            delay = fireRateDelay;
        } else if(delay > 0){
            delay--;
        }
    }

    public void SetAttack(bool b) {
        attackEnabled = true;
    }
}
