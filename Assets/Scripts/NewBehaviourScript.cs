using UnityEngine.InputSystem;
using UnityEngine;
public class JumpPlayerController : MonoBehaviour
{
    public float jumpForce;
    [SerializeField] private float jumpMultiplierLow;
    [SerializeField] private float jumpMultiplierHigh;
    private Rigidbody2D _compRigidbody2D;
    private bool jumped;
    private void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.duration >= 0.2)
        {
            jumpForce = context.ReadValue<float>();
            jumpForce = jumpForce + jumpMultiplierLow;
            _compRigidbody2D.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
        else if(context.duration <= 0.2 && context.phase == InputActionPhase.Performed)
        {
            jumpForce = context.ReadValue<float>();
            jumpForce = jumpForce + jumpMultiplierHigh;
            _compRigidbody2D.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }

    }
}
