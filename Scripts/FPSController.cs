using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [Header("Opciones de Personaje")]
    private CharacterController characterController;
    private Vector3 move = Vector3.zero;
    public float walkSpeed = 10.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    [Header("Opciones de Camara")]
    public Camera cam;
    public float cameraHorizontal = 3.0f;
    public float cameraVertical = 2.0f;
    public float minRotation = -65.0f;
    public float maxRotation = 60.0f;
   
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        transform.localEulerAngles = new Vector3(0, cam.transform.localEulerAngles.y, 0);
        if (characterController.isGrounded)
        {
            move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            move = transform.TransformDirection(move) * walkSpeed; // Para caminar

            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton0)) // Para saltar 
            {
                move.y = jumpSpeed;
            }
        }

        move.y -= gravity * Time.deltaTime; // Fuerza de la gravedad establecida
        characterController.Move(move * Time.deltaTime); // Movimiento de nuestro personaje
    }
}
