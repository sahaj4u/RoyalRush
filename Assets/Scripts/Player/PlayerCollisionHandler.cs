using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float collisonCooldown = 1f;
    [SerializeField] float adjustChangeMoveSpeedMethod = -2f;

    const string hitString = "Hit";
    float cooldownTimer = 0f;

    LevelGenerator levelGenerator;

     void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;
    }
    void OnCollisionEnter(Collision other)
    {
        if(cooldownTimer > collisonCooldown)
        {
            levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedMethod);
            animator.SetTrigger(hitString);
            cooldownTimer = 0f;
        }
    }
}

