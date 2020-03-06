using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float _newTarget;

    [SerializeField]
    private float _speed;

    public float _timer;
    private NavMeshAgent _nav;
    private Vector3 _target;


    // Start is called before the first frame update
    void Start()
    {
        _nav = GetComponent<NavMeshAgent>();
    }

    private void NewTarget()
    {
        float currentX = gameObject.transform.position.x;
        float currentZ = gameObject.transform.position.z;

        float newX = currentX + Random.Range(currentX - 100, currentX + 100);
        float newZ = currentZ + Random.Range(currentZ - 100, currentZ + 100);

        _target = new Vector3(newX, gameObject.transform.position.y, newZ);

        _nav.SetDestination(_target);
    }
    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _newTarget)
        {
            NewTarget();
            _timer = 0;
        }
    }
}
