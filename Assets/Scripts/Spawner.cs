using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float SpawnInterval = 5f;
    public List<Enemy> SpawnableEnemies = new();
    private float _spawnInterval = 3;
    private GameObject _player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _spawnInterval = SpawnInterval;
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        _spawnInterval -= Time.deltaTime;

        if (_spawnInterval <= 0)
        {
            SpawnRandomEnemy();
            _spawnInterval = SpawnInterval;
        }
    }


    void SpawnRandomEnemy()
    {
        int randomIndex = Random.Range(0, SpawnableEnemies.Count);

        Enemy enemyToSpawn = SpawnableEnemies[randomIndex];
        Enemy spanwedEnemy = Instantiate(enemyToSpawn, transform.position, Quaternion.Euler(Vector3.zero));
        spanwedEnemy.Target = _player;

    }


}
