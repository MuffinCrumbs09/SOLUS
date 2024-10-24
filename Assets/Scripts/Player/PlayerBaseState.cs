using UnityEngine;
// Abstract class
public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine _stateMachine;

    // Constructor
    public PlayerBaseState(PlayerStateMachine stateMachie)
    {
        this._stateMachine = stateMachie;
    }

    // Moves the player
    protected void Move(Vector3 motion, float deltaTime)
    {
        _stateMachine._rb.AddForce(motion * deltaTime, ForceMode.Force);
    }

    // Calculates the players input
    protected Vector3 CalculateMovement()
    {
        Vector3 forward = _stateMachine._cam.transform.forward;
        Vector3 right = _stateMachine._cam.transform.right;

        forward.y = 0;
        right.y = 0;

        return (forward * InputReader.Instance.MovementValue.y + right * InputReader.Instance.MovementValue.x).normalized;
    }

    // Face the player the same way they are walking
    protected void FaceWalkDirection(Vector3 dir) => _stateMachine._pModel.rotation = 
        Quaternion.RotateTowards(_stateMachine._pModel.rotation, 
            Quaternion.LookRotation(CalculateMovement(), Vector3.up),
            _stateMachine.rotationSpeed * Time.deltaTime);
}
