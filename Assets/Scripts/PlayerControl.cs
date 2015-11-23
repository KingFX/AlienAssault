using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public GameObject[] thrusters;
    public GameObject weapon;

    public bool keyboardControl = false;

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

    private float hPadding = 0.8f;
    private float vPadding = 0.8f;
    private float thrusterVSize = 0.5f;
    //private float hPadding = 1f;
    //private float vPadding = 1.5f;
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
        Vector3 topMost = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance));
        yMin = bottomMost.y + vPadding + thrusterVSize;
        yMax = topMost.y - vPadding;

        minRotation = 90 - tiltAngle;
        maxRotation = 90 + tiltAngle;
    }

    // Update is called once per frame
    void Update() {
        Movement();
        Attack();
    }

    private void KeyBoardControl() {
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(-Vector3.up * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(-Vector3.right * movementSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime, Space.World);
        }
    }

    private void MouseControl() {
        float mousePosX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        float mousePosY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;

        float distance = Vector3.Distance(transform.position, new Vector3(mousePosX, mousePosY, transform.position.z));
        //rotationSpeed = rotationSpeed * (distance / 0.8f) * Time.deltaTime;
        if (distance > maxMovementSpeed) {
            distance = maxMovementSpeed;
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(mousePosX, mousePosY, transform.position.z), movementSpeed * (distance / smoothMotion) * Time.deltaTime);
    }


    private Vector3 shipPos = Vector3.zero;
    private bool toggleW = false;
    private bool toggleH = false;


    private void Movement() {
        if (keyboardControl) {
            KeyBoardControl();
        } else {
            MouseControl();
        }

        float newX = Mathf.Clamp(transform.position.x, xMin, xMax);
        float newY = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = new Vector3(newX, newY, transform.position.z);

        FindObjectOfType<BackgroundScript>().PlayerPosY(transform.position.y);
        //Mathf.Clamp(90, minRotation, maxRotation);
        rotate += Input.GetAxis("Mouse Y") * smooth;
        rotate = Mathf.Clamp(rotate, minRotation, maxRotation);

        float hSpacer = 0.025f;
        float vSpacer = 0.025f;

        if (transform.position.y > shipPos.y + vSpacer) {
            toggleH = true;
            setLeftOff = false;
            setRightOff = false;
            thrusters[3].SetActive(true);
            thrusters[0].SetActive(true);
        } else {
            if (toggleH) {
                setLeftOff = true;
                setRightOff = true;
                toggleH = false;
            }
        }
        if (transform.position.x > shipPos.x + hSpacer) {
            toggleW = true;
            setLeftOff = false;
            thrusters[0].SetActive(true);
            if (transform.localEulerAngles.y > rotate) {
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.eulerAngles.y - rotationSpeed, transform.eulerAngles.z);
            }
        } else if (transform.position.x < shipPos.x - hSpacer) {
            toggleW = true;
            setRightOff = false;
            thrusters[3].SetActive(true);
            if (transform.localEulerAngles.y < rotate + (maxRotation - minRotation)) {
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.eulerAngles.y + rotationSpeed, transform.eulerAngles.z);
            }
        } else {
            if (toggleW) {
                setLeftOff = true;
                setRightOff = true;
                toggleW = false;
            }
            if (transform.localEulerAngles.y < 90) {
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.eulerAngles.y + rotationSpeed, transform.eulerAngles.z);
            }
            if (transform.localEulerAngles.y > 90) {
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.eulerAngles.y + -rotationSpeed, transform.eulerAngles.z);
            }
        }
        if (setLeftOff) {
            thrusters[0].SetActive(false);
        }
        if (setRightOff) {
            thrusters[3].SetActive(false);
        }
        shipPos = transform.position;
    }

    private void Attack() {
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) && attackEnabled && delay == 0) {
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
