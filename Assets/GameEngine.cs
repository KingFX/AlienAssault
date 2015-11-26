using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameEngine : MonoBehaviour {

    private List<GameObject> objects = new List<GameObject>();

    public Vector2 spawnArea;
    public float circleSize;

    private List<DbItem> dbItems;
    private int minDelay = 75;
    private int maxDelay = 125;
    private float delay;

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    void Start() {
        dbItems = ItemDatabase.GetItems();
        delay = Random.Range(minDelay, maxDelay) * Time.deltaTime;
    }

    void OnDrawGizmos() {
        Gizmos.DrawSphere(new Vector3(transform.position.x + spawnArea.x, transform.position.y + -spawnArea.y, transform.position.z), circleSize);
        Gizmos.DrawSphere(new Vector3(transform.position.x + spawnArea.x, transform.position.y + spawnArea.y, transform.position.z), circleSize);
        Gizmos.DrawSphere(new Vector3(transform.position.x + -spawnArea.x, transform.position.y + spawnArea.y, transform.position.z), circleSize);
        Gizmos.DrawSphere(new Vector3(transform.position.x + -spawnArea.x, transform.position.y + -spawnArea.y, transform.position.z), circleSize);
    }

    //private int newDelay = 5;
    //private int nDelay 

    void Update() {
        if (delay <= 0) {
            GameObject g = dbItems[(int)Random.Range(0, 2)].gameModel;
            GameObject enemy = (GameObject)Instantiate(g, new Vector3(Random.Range(transform.position.x + -spawnArea.x + (g.GetComponent<Renderer>().bounds.size.x / 2), 
                transform.position.x + spawnArea.x - (g.GetComponent<Renderer>().bounds.size.x / 2)),
                Random.Range(transform.position.y + -spawnArea.y, transform.position.y + spawnArea.y)), Quaternion.identity);
            //Debug.Log("Adding Enemy " + enemy.transform.position.x);
            //Debug.Log("Adding Enemy " + enemy.transform.position.y);
            spawnedEnemies.Add(enemy);
            delay = Random.Range(minDelay, maxDelay) * Time.deltaTime;
        } else {
            delay -= Time.deltaTime;
        }

        for (int i = 0; i < spawnedEnemies.Count; i++) {
            Debug.Log("Moving: " + i + " - " + spawnedEnemies[i]);
            spawnedEnemies[i].GetComponent<EnemyBehaviour>().Move(0.05f);
        }
    }
}
