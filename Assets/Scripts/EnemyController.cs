using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float _newTarget = 3.0f;

    [SerializeField]
    private float _speed = 5.0f;

    public float _timer = 0;
    private NavMeshAgent _nav;
    private Vector3 _target;
    private bool _walking = false;
    private Animator _anim; 


    // Start is called before the first frame update
    void Start()
    {
        _nav = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();

        NewTarget();
        
    }

    private void NewTarget()
    {
        float currentX = gameObject.transform.position.x;
        float currentZ = gameObject.transform.position.z;

        float newX = currentX + Random.Range(currentX - 100, currentX + 100);
        float newZ = currentZ + Random.Range(currentZ - 100, currentZ + 100);

        _target = new Vector3(newX, gameObject.transform.position.y, newZ);

        if (_nav.enabled == true)
        {
            _nav.SetDestination(_target);
        }
    }


    // Update is called once per frame
    void Update()
    {
        _nav.speed = _speed;
        _timer += Time.deltaTime;

        if (_timer >= _newTarget)
        {
            NewTarget();
            _timer = 0;
        }
        if (_nav.enabled == true)
        {
            if (_nav.remainingDistance > 0)
            {
                _walking = true;
            }
            else
            {
                _walking = false;
            }
        }
       
        if (_walking)
        {
            _anim.SetBool("Walking", true);
        }
        else
        {
            _anim.SetBool("Walking", false);
        }
    }
}
