using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region References

    MyInputActions  _myInputActions;
    Rigidbody _rb;

    #endregion

    #region Serialized Fields
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    #endregion

    #region Private Fields
    Vector2 _moveInput;
    Vector3 _movement;
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
        _rb.AddForce(_movement * moveSpeed, ForceMode.Force);
    }
    
    private void OnMovePerformed(InputAction.CallbackContext ctx)
    {
        _moveInput = ctx.ReadValue<Vector2>();
        _movement = new Vector3(_moveInput.x, 0f, _moveInput.y);
    }
    
    private void OnMoveCanceled(InputAction.CallbackContext ctx)
    {
        _moveInput = Vector2.zero;
        _movement = Vector3.zero;
    }
    
}
