using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    #region Public Values
    public static InputReader Instance;
    public Vector2 MovementValue {  get; private set; }
    #endregion

    #region Private Variables
    private Controls _controls;
    #endregion

    private void Awake()
    {
        if(Instance != null)
            Destroy(this);

        Instance = this;
    }

    private void Start()
    {
        _controls = new Controls();
        _controls.Player.SetCallbacks(this);

        ToggleControls(true);
        ToggleCursor(false);
    }

    // Toggle controls On/Off
    public void ToggleControls(bool toggle)
    {
        if (toggle)
            _controls.Player.Enable();
        else
            _controls.Player.Disable();
    }

    // Toggle Cursor visible (true) or hidden (false)
    public void ToggleCursor(bool toggle)
    {
        Cursor.visible = toggle;

        if(toggle)
            Cursor.lockState = CursorLockMode.Confined;
        else
            Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }
}
