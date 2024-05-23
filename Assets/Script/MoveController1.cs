using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveController : MonoBehaviour
{
    private InputActionControl controls;
    private Rigidbody2D rb;

    public float walkSpeed = 5f; // Velocidad de caminar
    public float runSpeed = 10f; // Velocidad de correr

    private float currentSpeed; // Velocidad actual (caminar o correr)
    private bool isRunning = false; // Estado de correr

    private void Awake()
    {
        controls = new InputActionControl();
        controls.Game.Move.performed += ctx => Movimiento(ctx.ReadValue<Vector2>());
        controls.Game.Move.canceled += ctx => Movimiento(Vector2.zero);
        controls.Game.Run.performed += _ => ToggleRun();
    }

    private void OnEnable()
    {
        controls.Game.Enable();
    }

    private void OnDisable()
    {
        controls.Game.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = walkSpeed; // Comenzamos caminando
    }

    void Movimiento(Vector2 direction)
    {
        // Calculamos la velocidad basada en la dirección y si estamos corriendo o caminando
        Vector2 movement = direction * currentSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    void ToggleRun()
    {
        // Cambiamos entre correr y caminar
        isRunning = !isRunning;
        currentSpeed = isRunning ? runSpeed : walkSpeed;
    }
}