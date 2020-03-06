using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class weaponController : MonoBehaviour
{
    private bool _attackFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
    }

    public void IsAttacked(bool attacked)
    {
        _attackFlag = attacked;
    }

    void OnTriggerEnter(Collider other)
    {
        if (_attackFlag)
        {
            if (other.tag == "Enemy")
            {
                var anim = other.GetComponent<Animator>();
                other.GetComponent<NavMeshAgent>().enabled = false;
                anim.SetTrigger("Death");
                Debug.Log("collision detected with " + other.name);
                _attackFlag = false;
            }
            
        }

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
