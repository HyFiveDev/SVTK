using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputSystem_Actions inputSystemActions;
    private InputAction move;

    private Rigidbody2D rb;
    

    public float speed = 5f;


    [Range(-1f, 1f)] public float inputHorizontal;
    [Range(-1f, 1f)] public float inputVertical;

    void Awake()
    {
        inputSystemActions = new InputSystem_Actions();
        move = inputSystemActions.Player.Move;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() => move.Enable();

    private void OnDisable() => move.Disable();

    void FixedUpdate()
    {
        Vector2 input = move.ReadValue<Vector2>();
        inputHorizontal = input.x;
        inputVertical = input.y;

        // Movimentação
        rb.linearVelocity = new Vector2(inputHorizontal * speed, inputVertical * speed);
    }
}