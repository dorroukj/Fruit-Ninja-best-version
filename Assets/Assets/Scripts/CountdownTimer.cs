using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    float currentTime= 0f;
    float startingTime= 10f;
    public bool gameEnd = false;
    public Text countdownText;

    private void Start()
    {
        currentTime = startingTime;
    }


    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString();

        if (currentTime <= 0)
        {
            gameEnd = true;
        }
        if (gameEnd == true)
        {
            GameOver();
        }
    }
}
