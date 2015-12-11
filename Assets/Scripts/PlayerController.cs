using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    //public GameObject[] thrusters;
    //public GameObject weapon;

    private const bool keyboardControl = false;

    private const float movementSpeed = 10;
    private const float rotationSpeed = 2;
    private const float bulletSpeed = 40000;
    private const float fireRateDelay = 15;

    private const float smooth = 0.01f;
    private const float tiltAngle = 35;
    private float minRotation;
    private float maxRotation;

    private float rotate = 0;

    private bool setLeftOff = false;
    private bool setRightOff = false;
    private bool leftOffToggle = false;
    private bool rightOffToggle = false;

    private const float hPadding = 0.8f;
    private const float vPadding = 0.8f;
    private const float thrusterVSize = 0.5f;
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

    private Vector3 shipPos = Vector3.zero;
    private bool toggleW = false;
    private bool toggleH = false;

    private bool leftBarrel = false;
    private bool rightBarrel = false;
    private float barrelRotationAngle = 0;
    private const int barrelRotationSpeed = 1000;

    //private List<PlayerBehaviour> players = new List<PlayerBehaviour>();
    private Dictionary<PlayerBehaviour, bool> players = new Dictionary<PlayerBehaviour, bool>();
    private Vector3 playerSpawn = new Vector3(0, -3, 0);

    // Use this for initialization
    void Start() {
        //Cursor.visible = false;

        delay = fireRateDelay;
        //thrusters[0].SetActive(false);
        //thrusters[3].SetActive(false);

        //float distance = transform.position.z - UnityEngine.Camera.main.transform.position.z;
        //Vector3 leftMost = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        //Vector3 rightMost = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        //xMin = leftMost.x + hPadding;
        //xMax = rightMost.x - hPadding;

        //Vector3 bottomMost = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        //Vector3 topMost = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance));
        //yMin = bottomMost.y + vPadding + thrusterVSize;
        //yMax = topMost.y - vPadding;

        //minRotation = 90 - tiltAngle;
        //maxRotation = 90 + tiltAngle;
    }

    public void Run() {
        foreach (KeyValuePair<PlayerBehaviour, bool> player in players) {
            Movement(player.Key, player.Key.GetModel(), player.Value);
            Attack(player.Key);
        }
    }

    private void KeyBoardControl(PlayerBehaviour player) {
        if (Input.GetKey(KeyCode.W)) {
            player.Move(Vector3.up * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S)) {
            player.Move(Vector3.down * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)) {
            player.Move(-Vector3.right * movementSpeed * Time.deltaTime);
            //ship.transform.Translate(-Vector3.right * movementSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D)) {
            player.Move(Vector3.right * movementSpeed * Time.deltaTime);
            //ship.transform.Translate(Vector3.right * movementSpeed * Time.deltaTime, Space.World);
        }
    }

    private void MouseControl(PlayerBehaviour player) {
        float mousePosX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        float mousePosY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;

        float distance = Vector3.Distance(player.GetPosition(), new Vector3(mousePosX, mousePosY, player.GetPosition().z));
        //rotationSpeed = rotationSpeed * (distance / 0.8f) * Time.deltaTime;
        if (distance > maxMovementSpeed) {
            distance = maxMovementSpeed;
        }

        player.Move(Vector3.MoveTowards(player.GetPosition(), new Vector3(mousePosX, mousePosY, player.GetPosition().z), movementSpeed * (distance / smoothMotion) * Time.deltaTime));
        //ship.transform.position = Vector3.MoveTowards(ship.transform.position, new Vector3(mousePosX, mousePosY, ship.transform.position.z), movementSpeed * (distance / smoothMotion) * Time.deltaTime);
    }

    private void Movement(PlayerBehaviour player, GameObject ship, bool isKeyboard) {
        if (isKeyboard) {
            KeyBoardControl(player);
        } else {
            MouseControl(player);
        }

        //float newX = Mathf.Clamp(player.GetPosition().x, xMin, xMax);
        //float newY = Mathf.Clamp(player.GetPosition().y, yMin, yMax);
        //ship.transform.position = new Vector3(newX, newY, ship.transform.position.z);

        //if (FindObjectOfType<BackgroundScript>() != null) {
        //    FindObjectOfType<BackgroundScript>().PlayerPosY(ship.transform.position.y);
        //}
        ////Mathf.Clamp(90, minRotation, maxRotation);
        //rotate += Input.GetAxis("Mouse Y") * smooth;
        //rotate = Mathf.Clamp(rotate, minRotation, maxRotation);

        //float hSpacer = 0.0125f;
        //float vSpacer = 0;

        //if (ship.transform.position.y > shipPos.y + vSpacer) {
        //    toggleH = true;
        //    setLeftOff = false;
        //    setRightOff = false;
        //    //thrusters[3].SetActive(true);
        //    //thrusters[0].SetActive(true);
        //} else {
        //    if (toggleH) {
        //        setLeftOff = true;
        //        setRightOff = true;
        //        toggleH = false;
        //    }
        //}
        //if (rightBarrel) {
        //    leftBarrel = false;
        //    ship.transform.localEulerAngles = new Vector3(ship.transform.localEulerAngles.x, ship.transform.eulerAngles.y - barrelRotationSpeed * Time.deltaTime, ship.transform.eulerAngles.z);
        //    barrelRotationAngle += barrelRotationSpeed * Time.deltaTime;
        //    if (barrelRotationAngle >= 360) {
        //        rightBarrel = false;
        //        barrelRotationAngle = 0;
        //    }
        //} else if (leftBarrel) {
        //    rightBarrel = false;
        //    ship.transform.localEulerAngles = new Vector3(ship.transform.localEulerAngles.x, ship.transform.eulerAngles.y + barrelRotationSpeed * Time.deltaTime, ship.transform.eulerAngles.z);
        //    barrelRotationAngle += barrelRotationSpeed * Time.deltaTime;
        //    if (barrelRotationAngle >= 360) {
        //        leftBarrel = false;
        //        barrelRotationAngle = 0;
        //    }
        //} else {
        //    if (ship.transform.position.x > shipPos.x + hSpacer) {
        //        toggleW = true;
        //        setLeftOff = false;
        //        //thrusters[0].SetActive(true);
        //        if (Vector3.Distance(new Vector3(0, ship.transform.position.x, 0), new Vector3(0, shipPos.x, 0)) > 0.75f) {
        //            rightBarrel = true;
        //        } else {
        //            if (transform.localEulerAngles.y > rotate) {
        //                transform.localEulerAngles = new Vector3(ship.transform.localEulerAngles.x, ship.transform.eulerAngles.y - rotationSpeed, ship.transform.eulerAngles.z);
        //            }
        //        }
        //    } else if (ship.transform.position.x < shipPos.x - hSpacer) {
        //        toggleW = true;
        //        setRightOff = false;
        //        //thrusters[3].SetActive(true);
        //        if (Vector3.Distance(new Vector3(0, ship.transform.position.x, 0), new Vector3(0, shipPos.x, 0)) > 0.75f) {
        //            leftBarrel = true;
        //        } else {
        //            if (ship.transform.localEulerAngles.y < rotate + (maxRotation - minRotation)) {
        //                ship.transform.localEulerAngles = new Vector3(ship.transform.localEulerAngles.x, ship.transform.eulerAngles.y + rotationSpeed, ship.transform.eulerAngles.z);
        //            }
        //        }
        //    } else {
        //        if (toggleW) {
        //            setLeftOff = true;
        //            setRightOff = true;
        //            toggleW = false;
        //        }
        //        if (ship.transform.localEulerAngles.y < 90) {
        //            ship.transform.localEulerAngles = new Vector3(ship.transform.localEulerAngles.x, ship.transform.eulerAngles.y + rotationSpeed, ship.transform.eulerAngles.z);
        //        }
        //        if (ship.transform.localEulerAngles.y > 90) {
        //            ship.transform.localEulerAngles = new Vector3(ship.transform.localEulerAngles.x, ship.transform.eulerAngles.y + -rotationSpeed, ship.transform.eulerAngles.z);
        //        }
        //    }
        //}
        //if (setLeftOff) {
        //    //thrusters[0].SetActive(false);
        //}
        //if (setRightOff) {
        //    //thrusters[3].SetActive(false);
        //}
        //shipPos = ship.transform.position;
    }

    private void Attack(PlayerBehaviour player) {
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) && attackEnabled && delay <= 0) {
            player.Attack();
            //Vector3 weaponSpawn = ship.transform.Find("WeaponSpawn").transform.position;

            //if (ship.GetComponent<Weapon>() != null) {
            //    ship.GetComponent<Weapon>().Attack(ship.transform.up, weaponSpawn);
            //}
            //GameObject bullet = Instantiate(weapon, weaponSpawn, transform.rotation) as GameObject;
            //bullet.GetComponent<Rigidbody>().AddForce(Vector3.up * bulletSpeed * Time.deltaTime);
            attackEnabled = false;
            delay = fireRateDelay;
        } else if(delay > 0){
            delay--;
        }
    }

    public void SetAttack(bool b) {
        attackEnabled = true;
    }

    public void AddPlayer(PlayerBehaviour player, bool keyboardControl) {
        players.Add(player, keyboardControl);
        player.SetModel((GameObject)Instantiate(player.GetModel(), playerSpawn, player.GetModel().transform.rotation));
        //player.SetShipModel();
    }
}
