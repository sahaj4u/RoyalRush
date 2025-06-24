using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TMP_Text scoretext;
    float Score = 0f;
    public void ChangeScore(float AmountToChange)
    {
        if (gameManager.gameOver) {return;}
        Score += AmountToChange;
        scoretext.text = Score.ToString();
    }
}
