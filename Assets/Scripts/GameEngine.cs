using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class GameEngine : MonoBehaviour {

    private List<GameObject> objects = new List<GameObject>();

    private List<DbItem> dbItems;
    private const int spawnDelay = 125;
    private float delay;
    //private List<EnemyBehaviour> spawnedObjects = new List<EnemyBehaviour>();
    private List<int> enemies = new List<int>();
    private string[] levelRows;
    private Vector3 playerSpawn;

    private Vector3 screenDimension;
    private float screenWidth;
    private float screenHeight;
    private const float padding = 2;

    private PlayerController playerController;
    private PlayerBehaviour playerBehaviour;

    //private List<ObjectModel> players = new List<ObjectModel>();

    void Awake() {
        this.gameObject.AddComponent<PlayerController>();
        playerController = GetComponent<PlayerController>();
        PlayerBehaviour player = new DefaultPlayer();
        player.SetModel(ItemDatabase.GetItemByName("Aero").gameModel);
        Weapon weaponDefault = new AeroWeapon();
        Bullet bullet = new PlazmaBullet();
        bullet.SetModel(ItemDatabase.GetItemByName("plazmabullet").gameModel);
        bullet.SetType(BulletType.PLAYER);
        weaponDefault.SetWeaponBullet(bullet);
        //weaponDefault.SetWeaponBullet(ItemDatabase.GetItemByName("plazmabullet").gameModel);
        player.AddWeapon(weaponDefault);
        playerController.AddPlayer(player, false);

        UnityEngine.Cursor.visible = false;
        //SpawnPlayer
        //playerSpawn = new Vector3(0, -3, 0);
        //GameObject player = (GameObject)Instantiate(ItemDatabase.GetItemByName("Aero").gameModel, playerSpawn, ItemDatabase.GetItemByName("Aero").gameModel.transform.rotation)
        //player.AddComponent<AeroWeapon>();
        
        //player.GetShipModel().AddComponent<AeroWeapon>();
        //player.GetShipModel().GetComponent<AeroWeapon>().SetWeaponBullet(ItemDatabase.GetItemByName("PlazmaBullet"));

        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
        screenWidth = topRight.x - bottomLeft.x;
        screenHeight = topRight.y - bottomLeft.y;

        levelRows = File.ReadAllLines("Assets/Resources/LevelTexts/Level1.txt");
        dbItems = ItemDatabase.GetItems();
        //delay = Random.Range(minDelay, maxDelay) * Time.deltaTime;
        delay = spawnDelay * Time.deltaTime;
    } 

    private int rowNum = 0;

    void Update() {
        playerController.Run();
        if (delay <= 0) {
            if (rowNum < levelRows.Length) {
                string levelRow = levelRows[rowNum];
                rowNum++;
                string[] enemyIds = levelRow.Split(',');
                for (int i = 0; i < enemyIds.Length; i++) {
                    DbItem enemyItem = null;
                    EnemyBehaviour enemy = null;
                    string enemyId = enemyIds[i];
                    string movementId = null;
                    if (enemyIds[i].Contains(":")) {
                        enemyId = enemyIds[i].Split(':')[0];
                        movementId = enemyIds[i].Split(':')[1];
                        //enemyId = enemyIds[i].Substring(0, enemyIds[i].IndexOf(':'));
                        //movementId = enemyIds[i].Substring(enemyIds[i].IndexOf(':') + 1);
                    }
                    switch (enemyId) {
                        case "0":
                            break;
                        case "1": {
                                enemyItem = ItemDatabase.GetItemByFileId("0");
                                enemy = new Blinky();
                                enemy.SetHealth(3);
                                break;
                            }
                        case "2": {
                                enemyItem = ItemDatabase.GetItemByFileId("1");
                                enemy = new Skrull();
                                enemy.SetHealth(5);
                                break;
                            }
                        case "3": {
                                enemyItem = ItemDatabase.GetItemByFileId("2");
                                enemy = new Skrull();
                                enemy.SetHealth(5);
                                break;
                            }
                        case "4": {
                                enemyItem = ItemDatabase.GetItemByFileId("6");
                                enemy = new Striker();
                                enemy.SetHealth(8);
                                enemy.SetExplosionFX(ItemDatabase.GetItemByName("ExplosionOrange").gameModel);
                                break;
                            }
                        default:
                            Debug.Log("Unknown Item ID: " + enemyIds[i]);
                            break;
                    }
                    if (enemy != null && enemyItem != null) {   
                        enemy.SetModel((GameObject)GameObject.Instantiate(enemyItem.gameModel, new Vector3((screenWidth * (float)i) / 8f - screenWidth / 2f + screenWidth / 16f, screenHeight + 2f), enemyItem.gameModel.transform.rotation));
                        enemy.GetModel().GetComponent<CollisionController>().SetObject(enemy);
                        //print("EnemyObject: " + enemy);
                        if (movementId != null) {
                            //print("MoveId: " + movementId);
                            EnemyMovement movement = null;
                            switch (movementId) {
                                case "0":
                                    break;
                                case "1":
                                    {
                                        movement = new MoveDown();
                                        movement.SetEnemy(enemy.GetModel());
                                        //enemy.SetMovement(movement);
                                        //enemyObject.AddComponent<MoveDown>();
                                        break;
                                    }
                                case "2":
                                    {
                                        //MoveRightAngle moveRightAngle = new MoveRightAngle();
                                        movement = new MoveRightAngle();
                                        movement.SetEnemy(enemy.GetModel());
                                        //moveRightAngle.SetScreenDimensions(GetScreenWidth(), GetScreenHeight());
                                        //movement = moveRightAngle;
                                        //enemy.SetMovement(movement);
                                        //enemyObject.AddComponent<MoveRightAngle>();
                                        break;
                                    }
                                case "3":
                                    {
                                        movement = new MoveLeftAngle();
                                        movement.SetEnemy(enemy.GetModel());
                                        
                                        //MoveLeftAngle moveLeftAngle = new MoveLeftAngle();
                                        //EnemyMovement movement = moveLeftAngle;
                                        //movement.SetEnemy(enemy.GetModel());
                                        //moveLeftAngle.SetScreenDimensions(GetScreenWidth(), GetScreenHeight());
                                        //movement = moveLeftAngle;
                                        //enemy.SetMovement(movement);

                                        //enemyObject.AddComponent<MoveLeftAngle>();
                                        break;
                                    }
                                default:
                                    Debug.Log("Unkown Movement ID: " + movementId);
                                    break;
                            }
                            if (movement is ScreenAware) {
                                ((ScreenAware)movement).SetScreenDimensions(GetScreenWidth(), GetScreenHeight());
                            }
                            enemy.SetMovement(movement);
                        }
                    }
                    if (enemy != null) {
                        //GameObject enemyModel = enemyItem.gameModel;
                        //GameObject enemyObject = Instantiate(enemyModel, new Vector3((screenWidth * (float)i) / 8f - screenWidth / 2f + screenWidth / 16f, screenHeight + 2f), enemyModel.transform.rotation) as GameObject;

                        //enemyObject = Instantiate(enemyModel, new Vector3((screenWidth * (float)i) / 8f - screenWidth / 2f + screenWidth / 16f, screenHeight + 2f), enemyModel.transform.rotation) as GameObject;
                        //enemyObject.GetComponent<EnemyBehaviour>().SetHealth(enemyItem.health);
                        //enemyObject.GetComponent<EnemyBehaviour>().SetMovement(movement);
                        
                        //enemyObject.AddComponent<MoveDown>();
                        
                        //spawnedObjects.Add(enemy);
                        GarbageCollector.AddGameObject(enemy);
                    }
                }
            }
            delay = spawnDelay * Time.deltaTime;
        } else {
            delay -= Time.deltaTime;
        }

        //List<EnemyBehaviour> markedObjects = new List<EnemyBehaviour>();
        List<ObjectModel> om = GarbageCollector.GetObjects();
        foreach (ObjectModel o in om) {
            if (o is EnemyBehaviour) {
                ((EnemyBehaviour)o).Move(2.5f);
            }
        }
        List<GameObject> markedItems = new List<GameObject>();
        foreach (KeyValuePair<GameObject, Vector3> item in SpawnItem.GetItems()) {
            GameObject spawnedItem = (GameObject)Instantiate(item.Key, item.Value, Quaternion.identity);
            markedItems.Add(item.Key);
        }
        foreach (GameObject g in markedItems) {
            SpawnItem.RemoveItem(g);
        }

        GarbageCollector.Clean();
    }

    public float GetScreenWidth() {
        return screenWidth;
    }

    public float GetScreenHeight() {
        return screenHeight;
    }
}
