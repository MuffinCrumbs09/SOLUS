using UnityEngine;
// Abstract class
public abstract class StateMachine : MonoBehaviour
{
    private State _curState;
    private bool _isSwitching;

    // If not switching state, tick current state
    private void Update() 
    {
        _curState.Tick(Time.deltaTime);
    }

    // Switch state to a new state
    public void SwitchState(State newState)
    {
        if (_isSwitching)
            return;

        _isSwitching = true;
        Debug.Log("Switching State");

        _curState?.Exit();
        _curState = newState;
        _curState?.Enter();

        _isSwitching = false;
    }
}
