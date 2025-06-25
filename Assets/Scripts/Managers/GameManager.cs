using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameoverTXT;
    [SerializeField] float startTime = 5f;

    float timeleft;
    bool GameOver = false;

    public bool gameOver => GameOver;

     void Start()
    {
        timeleft = startTime;
    }
 
     void Update()
    {
        DecreaseTime();
    }

    

    void DecreaseTime()
    {
        if(GameOver) {return;}
        timeleft -= Time.deltaTime;
        timeText.text = timeleft.ToString("F1");
        if(timeleft <= 0)
        {
            PlayerGameOver();
        }
    }

    void PlayerGameOver()
    {
        GameOver = true;
        playerController.enabled = false;
        gameoverTXT.SetActive(true);
        Time.timeScale = 0.1f;
    }

    public void AddTime(float time)
    {
        timeleft += time;
    }
}
