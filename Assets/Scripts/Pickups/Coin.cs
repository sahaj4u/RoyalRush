using TMPro;
using UnityEngine;

public class Coin : Pickup
{
    [SerializeField] float pointsToGive = 100f;

    ScoreManager scoreManager;

     public void Init(ScoreManager scoreManager)
    { 
      this.scoreManager = scoreManager;
    }

    protected override void OnPickup()
    {
        scoreManager.ChangeScore(pointsToGive);
    }
}
