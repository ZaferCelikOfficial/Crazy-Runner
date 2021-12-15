using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimMove : MonoBehaviour
{
    CharacterController AimCharacterController;
    [SerializeField] float Speed = 4f;
    InputController AimInputController;
    Vector2 ReadingValue;
    Vector3 MovementValue;

    void Awake()
    {
        ReadingValue = Vector2.zero;
        AimCharacterController = this.GetComponent<CharacterController>();
        AimInputController = new InputController();

        AimInputController.CharacterControls.Move.started += MovementInput;
        AimInputController.CharacterControls.Move.performed += MovementInput;
        AimInputController.CharacterControls.Move.canceled += MovementInput;
    }
    void Update()
    {
        MoveAim();
    }
    void MoveAim()
    {
        if (GameManager.isGameStarted && !GameManager.isGameEnded)
        {
            this.transform.position += MovementValue * Speed * Time.deltaTime;
        }

    }
    void MovementInput(InputAction.CallbackContext context)
    {
        ReadingValue = context.ReadValue<Vector2>();
        MovementValue.x = ReadingValue.x*1.5f;
        MovementValue.y = ReadingValue.y;
    }
    void OnEnable()
    {
        AimInputController.Enable();
    }
    void OnDisable()
    {
        AimInputController.Disable();
    }
}
