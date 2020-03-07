using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public Text timer;
    public GameObject player;
    public GameObject overlay;

    private float _currentTime = 0.0f;
    private float _startTime = 180.0f;
    private string TTD = "Time Till Death: ";
    private Animator _playerAnimations;

    [SerializeField]
    private float _fadeTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        _currentTime = _startTime;
    }

    private IEnumerator FadeToBlack()
    {

        overlay.gameObject.SetActive(true);
        overlay.GetComponent<Image>().color = Color.clear;

        float rate = 1.0f / _fadeTime;
        float progress = 0.0f; 

        while (progress < 1.0f)
        {
            overlay.GetComponent<Image>().color = Color.Lerp(Color.clear, Color.black, progress);

            progress += rate * Time.deltaTime;

            yield return null;
        }

        overlay.GetComponent<Image>().color = Color.black;
        SceneManager.LoadScene("GameOver");
    }
    // Update is called once per frame
    void Update()
    {
        string minutes = ((int)_currentTime / 60).ToString();
        int seconds = ((int)_currentTime % 60);

        if (seconds < 10)
        {
            timer.text = TTD + minutes + ":0" + seconds.ToString();
        }
        else
        {
            timer.text = TTD + minutes + ":" + seconds.ToString();
        }
        

        _currentTime -= 1 * Time.deltaTime;

        if (_currentTime <= 0)
        {
            _currentTime = 0;
            _playerAnimations = player.GetComponent<Animator>();
            _playerAnimations.SetTrigger("Death");
            player.GetComponent<PlayerController>().enabled = false;
            StartCoroutine(FadeToBlack());
            Debug.Log("Game Over");

            

        }
    }
}
