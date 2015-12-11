using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class GameEngine : MonoBehaviour {

    private List<GameObject> objects = new List<GameObject>();

    private List<DbItem> dbItems;
    private const int spawnDelay = 125;
    private float delay;
    private List<EnemyBehaviour> spawnedObjects = new List<EnemyBehaviour>();
    private List<int> enemies = new List<int>();
    private string[] levelRows;
    private Vector3 playerSpawn;

    private Vector3 screenDimension;
    private float screenWidth;
    private float screenHeight;
    private const float padding = 2;

    private PlayerController playerController;
    private PlayerBehaviour playerBehaviour;

    void Start() {
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

        //UnityEngine.Cursor.visible = false;
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
                    EnemyBehaviour enemyObject = null;
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
                                DbItem enemyItem = ItemDatabase.GetItemByFileId("0");
                                //movement = new MoveDown();
                                EnemyBehaviour enemy = new Blinky();
                                enemy.SetModel(enemyItem.gameModel);
                                enemyObject = enemy;
                                //enemyObject = (GameObject)GameObject.Instantiate(enemy.GetModel(), new Vector3((screenWidth * (float)i) / 8f - screenWidth / 2f + screenWidth / 16f, screenHeight + 2f), enemy.GetModel().transform.rotation);
                                //enemyObject.GetComponent<EnemyBehaviour>().SetHealth(enemyItem.health);
                                Weapon weapon = new SkrullWeapon();
                                Bullet bullet = new PlazmaBullet();
                                bullet.SetModel(ItemDatabase.GetItemByName("FireBall").gameModel);
                                bullet.SetType(BulletType.ENEMY);
                                weapon.SetWeaponBullet(bullet);
                                //enemyObject.AddComponent<SkrullWeapon>();
                                //enemyObject.GetComponent<SkrullWeapon>().SetWeaponBullet(ItemDatabase.GetItemByName("FireBall").gameModel);
                                //enemyObject.GetComponent<EnemyBehaviour>().SetMovement(movement);
                                break;
                            }
                        case "2": {
                                DbItem enemyItem = ItemDatabase.GetItemByFileId("1");
                                //movement = new MoveDown();
                                EnemyBehaviour enemy = new Skrull();
                                enemy.SetModel(enemyItem.gameModel);
                                enemyObject = enemy;
                                //enemyObject = Instantiate(enemy.GetModel(), new Vector3((screenWidth * (float)i) / 8f - screenWidth / 2f + screenWidth / 16f, screenHeight + 2f), enemy.GetModel().transform.rotation) as GameObject;
                                //enemyObject.GetComponent<EnemyBehaviour>().SetHealth(enemyItem.health);
                                //enemyObject.AddComponent<SkrullWeapon>();
                                //enemyObject.GetComponent<EnemyBehaviour>().SetMovement();
                                break;
                            }
                        case "3": {
                                DbItem enemyItem = ItemDatabase.GetItemByFileId("2");
                                //movement = new MoveDown();
                                EnemyBehaviour enemy = new Skrull();
                                enemy.SetModel(enemyItem.gameModel);
                                enemyObject = enemy;
                                //enemyObject = Instantiate(enemy.GetModel(), new Vector3((screenWidth * (float)i) / 8f - screenWidth / 2f + screenWidth / 16f, screenHeight + 2f), enemy.GetModel().transform.rotation) as GameObject;
                                //enemyObject.GetComponent<EnemyBehaviour>().SetHealth(enemyItem.health);
                                //enemyObject.GetComponent<EnemyBehaviour>().SetMovement(movement);
                                break;
                            }
                        default:
                            Debug.Log("Unknown Item ID: " + enemyIds[i]);
                            break;
                    }
                    if (movementId != null) {
                        //switch (movementId) {
                        //    case "0":
                        //        break;
                        //    case "1":
                        //        enemyObject.AddComponent<MoveDown>();
                        //        break;
                        //    case "2":
                        //        enemyObject.AddComponent<MoveRightAngle>();
                        //        break;
                        //    case "3":
                        //        enemyObject.AddComponent<MoveLeftAngle>();
                        //        break;
                        //    default:
                        //        Debug.Log("Unkown Movement ID: " + movementId);
                        //        break;
                        //}
                    }
                    if (enemyObject != null) {
                        //GameObject enemyModel = enemyItem.gameModel;
                        //GameObject enemyObject = Instantiate(enemyModel, new Vector3((screenWidth * (float)i) / 8f - screenWidth / 2f + screenWidth / 16f, screenHeight + 2f), enemyModel.transform.rotation) as GameObject;

                        //enemyObject = Instantiate(enemyModel, new Vector3((screenWidth * (float)i) / 8f - screenWidth / 2f + screenWidth / 16f, screenHeight + 2f), enemyModel.transform.rotation) as GameObject;
                        //enemyObject.GetComponent<EnemyBehaviour>().SetHealth(enemyItem.health);
                        //enemyObject.GetComponent<EnemyBehaviour>().SetMovement(movement);
                        
                        //enemyObject.AddComponent<MoveDown>();
                        spawnedObjects.Add(enemyObject);
                    }
                }
            }
            delay = spawnDelay * Time.deltaTime;
        } else {
            delay -= Time.deltaTime;
        }

        List<GameObject> markedObjects = new List<GameObject>();

        for (int i = 0; i < spawnedObjects.Count; i++) {
            //if (spawnedObjects[i].transform.position.y <  -screenHeight / 2 - padding) {
            //    markedObjects.Add(spawnedObjects[i]);
            //} else if (spawnedObjects[i].GetComponent<EnemyBehaviour>().GetHealth() <= 0) {
            //    markedObjects.Add(spawnedObjects[i]);
            //}
            //spawnedObjects[i].GetComponent<EnemyBehaviour>().Move(2.5f);
            //if (spawnedObjects[i].transform.position.y < screenHeight / 2) {
            //    spawnedObjects[i].GetComponent<EnemyBehaviour>().Attack();
            //}
        }
        //foreach (GameObject g in markedObjects) {
        //    spawnedObjects.Remove(g);
        //    Destroy(g);
        //}
    }

    public float GetScreenWidth() {
        return screenWidth;
    }

    public float GetScreenHeight() {
        return screenHeight;
    }
}
