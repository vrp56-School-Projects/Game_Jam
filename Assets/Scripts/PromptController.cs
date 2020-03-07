using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PromptController : MonoBehaviour
{
    public GameObject player;
    public GameObject sword;
    public Text prompt;
    private float _distance;
    private bool _canGrab = false;

    // Update is called once per frame
    void Update()
    {
        _distance = Vector3.Distance(player.transform.position, sword.transform.position);

        if (_distance <= 1.3)
        {
            prompt.text = "Press F to grab sword";
            _canGrab = true;
        }
        else
        {
            prompt.text = "";
            _canGrab = false;
        }

        if (Input.GetKeyDown(KeyCode.F) && _canGrab)
        {
            //Debug.Log("You are cursed");
            SceneManager.LoadScene("Premise");
        }

    }
}
