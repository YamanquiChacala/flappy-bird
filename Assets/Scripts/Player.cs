using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpPower;
    private InputAction jumpAction;
    private bool jumpTriggered;
    new private Rigidbody2D rigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start() {
        jumpAction = InputSystem.actions.FindAction("Jump");
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if(jumpAction.WasPressedThisFrame()){
            jumpTriggered = true;
        }
    }
    
    private void FixedUpdate() {
        if (jumpTriggered) {
            rigidbody.linearVelocityY = jumpPower;
            jumpTriggered = false;
        }
    }
}
