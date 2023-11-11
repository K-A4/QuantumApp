using Quantum;
using UnityEngine;

public unsafe class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private EntityView entityView;

    private EntityRef entityRef;
    private QuantumGame quantumGame;

    private const string FLOAT_MOVEMENT_SPEED = "YMove";
    private const string FLOAT_MOVEMENT_VERTICAL = "XMove";

    public void Initialize()
    {
        this.entityRef = entityView.EntityRef;
        quantumGame = QuantumRunner.Default.Game;
    }

    private void Update()
    {
        MovementAnimation();
        AttackAnimation();
    }

    private void MovementAnimation()
    {
        var kcc = quantumGame.Frames.Verified.Unsafe.GetPointer<CharacterController3D>(entityRef);
        bool isMoving = kcc->Velocity.Magnitude.AsFloat > 0.2f;
        Debug.Log(isMoving);
        //animator.SetBool(BOOL_IS_MOVING, isMoving);

        if (isMoving)
        {
            animator.SetFloat(FLOAT_MOVEMENT_SPEED, kcc->Velocity.Magnitude.AsFloat);
            var forward = kcc->Velocity.Normalized.ToUnityVector3();
            forward.y = 0.0f;
            transform.forward = forward;
            //animator.SetFloat(FLOAT_MOVEMENT_VERTICAL, kcc->Velocity.Z.AsFloat);
        }
        else
        {
            animator.SetFloat(FLOAT_MOVEMENT_SPEED, 0.0f);
            animator.SetFloat(FLOAT_MOVEMENT_VERTICAL, 0.0f);
        }
    }

    private void AttackAnimation()
    {
        if (UnityEngine.Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack01");
        }
    }
}
