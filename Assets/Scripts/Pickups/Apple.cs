using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float adjustChangeMoveSpeedMethod =3f;

    LevelGenerator levelGenerator;

     public void Init(LevelGenerator LG)
    {
        this.levelGenerator = LG;
    }
    protected override void OnPickup()
    {
        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedMethod);
    }
}
