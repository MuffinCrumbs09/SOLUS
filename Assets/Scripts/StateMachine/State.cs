using UnityEngine;
// Abstract class
public abstract class State
{
    // Enter state
    public abstract void Enter();
    // Per tick in state (frame)
    public abstract void Tick(float deltaTime);
    // Exit State
    public abstract void Exit();
}
