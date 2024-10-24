using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    // Constructor
    public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    private readonly int LocomotionSpeedHash = Animator.StringToHash("Locomotion Speed");
    private const float _animatorDampTime = 0.1f;

    public override void Enter() { }

    public override void Tick(float deltaTime)
    {
        if (InputReader.Instance.MovementValue.magnitude >= 0.1f)
            _stateMachine.SwitchState(new PlayerWalkState(_stateMachine));

        _stateMachine._anim.SetFloat(LocomotionSpeedHash, 0f, _animatorDampTime, Time.deltaTime);
    }

    public override void Exit() { }
}
