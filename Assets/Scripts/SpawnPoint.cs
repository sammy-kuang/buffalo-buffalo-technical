using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    private float spawnRate;

    public EnemyType enemyType;
    public GameObject enemyPrefab;

    public TimeCycle prohibitedSpawns; // Represents when this enemy cannot spawn;
    public int spawnRadius = 15;

    void Awake()
    {
        if (enemyType == null)
        {
            Debug.LogWarning("Spawn point assigned without an Enemy Type!");
            return;
        }

        spawnRate = enemyType.baseSpawnRate;
    }

    void Start() {
        StartCoroutine("LateStart", 0.5f);
    }

    // To ensure that all Modifiers are applied first before spawning, we will add a slight delay.
    IEnumerator LateStart(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        SpawnWithProbability();
    }

    private void Spawn()
    {
        GameObject g = Instantiate(enemyPrefab);
        Enemy c = g.GetComponent<Enemy>();
        c.SetEnemyType(enemyType);
        g.transform.position = new Vector3(transform.position.x + Random.Range(-spawnRadius, spawnRadius), transform.position.y + 5, transform.position.z + Random.Range(-spawnRadius, spawnRadius)); 
    }

    public void SpawnWithProbability()
    {
        float prob = Random.Range(0.0f, 1.0f);
        TimeCycle t = GameController.GetGameController().GetTimeOfDay();

        // We cannot spawn right now as the current time is prohibited
        if ((prohibitedSpawns & t) != 0) {
            Debug.Log("Prevented spawning of: " + enemyType.name + " due to " + t.ToString(), gameObject);
            return;
        }

        if (prob <= spawnRate)
        {
            Spawn();
        } else {
            Debug.Log("Did not spawn " + enemyType.name + " due to probability: " + prob.ToString() + " > " + spawnRate.ToString(), gameObject);
        }
    }

    private void adjustByDelta(ref float value, float delta) { value += delta; }
    public void adjustSpawnRate(float delta) { adjustByDelta(ref spawnRate, delta); }

}
