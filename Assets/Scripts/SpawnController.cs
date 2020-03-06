using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour

{
    [SerializeField]
    private int _maxEnemies = 2;

    [SerializeField]
    private List<GameObject> spawns; 

    private GameObject _enemies;
    private List<GameObject> _spawnedEnemies = new List<GameObject>(); 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_spawnedEnemies.Count < 2)
        {

        }
    }
}
