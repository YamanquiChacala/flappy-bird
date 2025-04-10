using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpPower;
    [SerializeField] private float rotationFraction;
    private InputAction jumpAction;
    private bool jumpTriggered;
    new private Rigidbody2D rigidbody;
    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        jumpAction = InputSystem.actions.FindAction(Constants.InputActions.JUMP);
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, rigidbody.linearVelocityY * rotationFraction);
        if (jumpAction.WasPressedThisFrame())
        {
            jumpTriggered = true;
            transform.rotation = Quaternion.Euler(0, 0, jumpPower * rotationFraction);
            anim.SetTrigger(Constants.PlayerAnimator.FLAP);
        }
    }

    private void FixedUpdate()
    {
        if (jumpTriggered)
        {
            rigidbody.linearVelocityY = jumpPower;
            jumpTriggered = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameManager.instance.GameOver();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.AddScore();
    }
}
