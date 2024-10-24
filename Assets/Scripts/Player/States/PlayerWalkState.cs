using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    // Constructor
    public PlayerWalkState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    private readonly int LocomotionSpeedHash = Animator.StringToHash("Locomotion Speed");
    private const float _animatorDampTime = 0.1f;

    private float _speedMultipler = 100f;

    public override void Enter() { }

    public override void Tick(float deltaTime)
    {
        if (InputReader.Instance.MovementValue.magnitude <= 0.1f)
            _stateMachine.SwitchState(new PlayerIdleState(_stateMachine));

        ApplyMovement(deltaTime);
        FaceWalkDirection(CalculateMovement());

        _stateMachine._anim.SetFloat(LocomotionSpeedHash, 0.5f, _animatorDampTime, Time.deltaTime);
    }

    public override void Exit() { }

    private void ApplyMovement(float deltaTime)
    {
        Vector3 movement = CalculateMovement();
        Move(movement * _stateMachine.walkSpeed * _speedMultipler, deltaTime);
    }
}
