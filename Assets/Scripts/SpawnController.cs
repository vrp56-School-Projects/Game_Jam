using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour

{
    [SerializeField]
    private int _maxEnemies = 2;

    [SerializeField]
    private GameObject[] spawns; 

    
    private List<GameObject> _spawnedEnemies = new List<GameObject>();
    private int _spawnPoint = 0;
    public GameObject[] enemies;
    private int _enemyIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _spawnPoint = Random.Range(0, spawns.Length);
        _enemyIndex = Random.Range(0, enemies.Length);
        
        if(_spawnedEnemies.Count < _maxEnemies)
        {
            float xPos = spawns[_spawnPoint].transform.position.x + Random.Range(0, 15);
            float zPos = spawns[_spawnPoint].transform.position.z + Random.Range(0, 15);

            GameObject newEnemy = Instantiate(enemies[_enemyIndex], new Vector3(xPos, spawns[_spawnPoint].transform.position.y, zPos), spawns[_spawnPoint].transform.rotation);
            Debug.Log("Added new enemy");
            _spawnedEnemies.Add(newEnemy);
        }
    }
}
