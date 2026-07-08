using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region References

    MyInputActions  _myInputActions;
    Rigidbody _rb;

    #endregion

    #region Serialized Fields

    [SerializeField] private float moveSpeed = 5f;

    #endregion

    #region Private Fields
    [Header("Movement Settings")]
    private Vector2 _moveInput;
    private Vector3 _movement;

    #endregion
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _myInputActions = new MyInputActions();
    }
    private void OnEnable()
    {
        _myInputActions.Enable();
        _myInputActions.Player.Move.performed += OnMovePerformed;
        _myInputActions.Player.Move.canceled += OnMoveCanceled;
    }
    private void OnDisable()
    {
        _myInputActions.Disable();
        _myInputActions.Player.Move.performed -= OnMovePerformed;
        _myInputActions.Player.Move.canceled -= OnMoveCanceled;
    }

    private void FixedUpdate()
    {
        _movement = new Vector3(_moveInput.x, _rb.linearVelocity.y, _moveInput.y);
        _rb.AddForce(_movement * moveSpeed, ForceMode.Force);
    }

    private void OnMovePerformed(InputAction.CallbackContext ctx)
    {
        _moveInput = ctx.ReadValue<Vector2>();
    }
    private void OnMoveCanceled(InputAction.CallbackContext obj)
    {
        _moveInput = Vector2.zero;
    }
    
}
