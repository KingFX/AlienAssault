using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyGeneratorScript : MonoBehaviour {
    public Vector2 spawnArea;
    public float circleSize;

    public GameObject[] enemies;
    private int minDelay = 75;
    private int maxDelay = 125;
    private float delay;

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    void Start() {
        delay = Random.Range(minDelay, maxDelay) * Time.deltaTime;
    }

    void OnDrawGizmos() {
        Gizmos.DrawSphere(new Vector3(transform.position.x + spawnArea.x, transform.position.y + -spawnArea.y, transform.position.z), circleSize);
        Gizmos.DrawSphere(new Vector3(transform.position.x + spawnArea.x, transform.position.y + spawnArea.y, transform.position.z), circleSize);
        Gizmos.DrawSphere(new Vector3(transform.position.x + -spawnArea.x, transform.position.y + spawnArea.y, transform.position.z), circleSize);
        Gizmos.DrawSphere(new Vector3(transform.position.x + -spawnArea.x, transform.position.y + -spawnArea.y, transform.position.z), circleSize);
    }

    void Update() {
        if (delay <= 0) {
            GameObject enemy = Instantiate(enemies[0], new Vector3(Random.Range(transform.position.x + -spawnArea.x + (enemies[0].GetComponent<Renderer>().bounds.size.x / 2), transform.position.x + spawnArea.x - (enemies[0].GetComponent<Renderer>().bounds.size.x / 2)), //x
                                                Random.Range(transform.position.y + -spawnArea.y, transform.position.y + spawnArea.y), //y
                                                0), //z
                                                Quaternion.identity)//rotation
                                                as GameObject; //cast
            spawnedEnemies.Add(enemy);
            delay = Random.Range(minDelay, maxDelay) * Time.deltaTime;
        } else {
            delay -= Time.deltaTime;
        }
    }
}
