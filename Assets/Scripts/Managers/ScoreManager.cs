using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TMP_Text scoretext;
    [SerializeField] TMP_Text HighScoreTXT;
    int Score = 0;
     
    public void ChangeScore(int AmountToChange)
    {
        if (gameManager.gameOver) {return;}
        Score += AmountToChange;
        scoretext.text = Score.ToString();
        
    }

}
