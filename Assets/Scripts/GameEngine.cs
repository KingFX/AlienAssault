﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
public class GameEngine : MonoBehaviour {

    private List<GameObject> objects = new List<GameObject>();

    private List<DbItem> dbItems;
    private const int spawnDelay = 125;
    private float delay;
    private List<GameObject> spawnedObjects = new List<GameObject>();
    private List<int> enemies = new List<int>();
    private string[] levelRows;

    private Vector3 screenDimension;
    private float screenWidth;
    private float screenHeight;
    private const float padding = 2;


    void Start() {


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
        if (delay <= 0) {
            if (rowNum < levelRows.Length) {
                string levelRow = levelRows[rowNum];
                rowNum++;
                string[] enemyIds = levelRow.Split(',');
                for (int i = 0; i < enemyIds.Length; i++) {
                    GameObject enemyObject = null;
                    string enemyId = enemyIds[i];
                    string movementId = null;
                    if (enemyIds[i].Contains(":")) {
                        enemyId = enemyIds[i].Substring(0, enemyIds[i].IndexOf(':'));
                        movementId = enemyIds[i].Substring(enemyIds[i].IndexOf(':') + 1, enemyIds[i].Length - 2);
                    }
                    switch (enemyId) {
                        case "0":
                            break;
                        case "1": {
                                DbItem enemyItem = ItemDatabase.GetItemByFileId("0");
                                //movement = new MoveDown();
                                enemyObject = Instantiate(enemyItem.gameModel, new Vector3((screenWidth * (float)i) / 8f - screenWidth / 2f + screenWidth / 16f, screenHeight + 2f), enemyItem.gameModel.transform.rotation) as GameObject;
                                enemyObject.GetComponent<EnemyBehaviour>().SetHealth(enemyItem.health);
                                enemyObject.AddComponent<SkrullWeapon>();
                                //enemyObject.GetComponent<EnemyBehaviour>().SetMovement(movement);
                                break;
                            }
                        case "2": {
                                DbItem enemyItem = ItemDatabase.GetItemByFileId("1");
                                //movement = new MoveDown();
                                enemyObject = Instantiate(enemyItem.gameModel, new Vector3((screenWidth * (float)i) / 8f - screenWidth / 2f + screenWidth / 16f, screenHeight + 2f), enemyItem.gameModel.transform.rotation) as GameObject;
                                enemyObject.GetComponent<EnemyBehaviour>().SetHealth(enemyItem.health);
                                enemyObject.AddComponent<SkrullWeapon>();
                                //enemyObject.GetComponent<EnemyBehaviour>().SetMovement();
                                break;
                            }
                        case "3": {
                                DbItem enemyItem = ItemDatabase.GetItemByFileId("2");
                                //movement = new MoveDown();
                                enemyObject = Instantiate(enemyItem.gameModel, new Vector3((screenWidth * (float)i) / 8f - screenWidth / 2f + screenWidth / 16f, screenHeight + 2f), enemyItem.gameModel.transform.rotation) as GameObject;
                                enemyObject.GetComponent<EnemyBehaviour>().SetHealth(enemyItem.health);
                                //enemyObject.GetComponent<EnemyBehaviour>().SetMovement(movement);
                                break;
                            }
                        default:
                            Debug.Log("Unknown Item ID: " + enemyIds[i]);
                            break;
                    }
                    if (movementId != null) {
                        switch (movementId) {
                            case "0":
                                break;
                            case "1":
                                enemyObject.AddComponent<MoveDown>();
                                break;
                            case "2":
                                enemyObject.AddComponent<MoveRightAngle>();
                                break;
                            case "3":
                                enemyObject.AddComponent<MoveLeftAngle>();
                                break;
                            default:
                                Debug.Log("Unkown Movement ID: " + movementId);
                                break;
                        }
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
            if (spawnedObjects[i].transform.position.y <  -screenHeight / 2 - padding) {
                markedObjects.Add(spawnedObjects[i]);
            } else if (spawnedObjects[i].GetComponent<EnemyBehaviour>().GetHealth() <= 0) {
                markedObjects.Add(spawnedObjects[i]);
            }
            spawnedObjects[i].GetComponent<EnemyBehaviour>().Move(2.5f);
            if (spawnedObjects[i].transform.position.y < screenHeight / 2) {
                spawnedObjects[i].GetComponent<EnemyBehaviour>().Attack();
            }
        }
        foreach (GameObject g in markedObjects) {
            spawnedObjects.Remove(g);
            Destroy(g);
        }
    }

    public float GetScreenWidth() {
        return screenWidth;
    }

    public float GetScreenHeight() {
        return screenHeight;
    }
}
