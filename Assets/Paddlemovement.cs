using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleMovement : MonoBehaviour
{
    public float speed = 5f;
    public float minX = -8f; // World bounds
    public float maxX = 8f;
    private Vector2 mousePosition;

    private PlayerControls controls;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.Move.performed += ctx => mousePosition = ctx.ReadValue<Vector2>();
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    void Update()
    {
        // Convert mouse screen position to world position
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));
        float targetX = Mathf.Clamp(worldPos.x, minX, maxX);
        Vector3 paddlePos = transform.position;
        paddlePos.x = targetX;
        transform.position = paddlePos;
        Debug.Log($"Paddle X: {paddlePos.x}");
    }
}