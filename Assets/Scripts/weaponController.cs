using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WeaponController : MonoBehaviour
{
    public GameObject scoreBox; 
    private bool _attackFlag = false;
    private ScoreContoller _scoreController; 
    
    // Start is called before the first frame update
    void Start()
    {
        _scoreController = scoreBox.GetComponent<ScoreContoller>();
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
                if (other.GetComponent<NavMeshAgent>().enabled == true)
                {
                    _scoreController.AddScore();
                }
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
