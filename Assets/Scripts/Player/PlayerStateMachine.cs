using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    #region Components
    [field: SerializeField] public Rigidbody _rb {  get; private set; }
    [field: SerializeField] public Camera _cam {  get; private set; }
    [field: SerializeField] public Animator _anim {  get; private set; }
    [field: SerializeField] public Transform _pModel {  get; private set; }
    #endregion

    #region Movement
    [field: SerializeField] public float walkSpeed { get; private set; }
    [field: SerializeField] public float runSpeed { get; private set; }
    [field: SerializeField] public float rotationSpeed { get; private set; }

    private bool isGrounded;
    #endregion

    private void Start()
    {
        SwitchState(new PlayerIdleState(this));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
            isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
            isGrounded = false;
    }
}
