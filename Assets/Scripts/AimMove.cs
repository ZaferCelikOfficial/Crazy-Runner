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

        /*PlayerInputController.CharacterControls.MouseMove.started += MouseMovementInput;
        PlayerInputController.CharacterControls.MouseMove.performed += MouseMovementInput;
        PlayerInputController.CharacterControls.MouseMove.canceled += MouseMovementInput;*/

       
    }
    void Update()
    {

        MoveAim();
        
    }
    void MoveAim()
    {
        if (GameManager.isGameStarted && !GameManager.isGameEnded)
        {
            
            AimCharacterController.Move(MovementValue * Speed * Time.deltaTime);
        }

    }
    void MovementInput(InputAction.CallbackContext context)
    {
        //Debug.Log(context.ReadValue<Vector2>());
        ReadingValue = context.ReadValue<Vector2>();
        MovementValue.x = ReadingValue.x;
        MovementValue.y = ReadingValue.y;
        /*if(ReadingValue.x!=0|| ReadingValue.y!=0)
        {
            PlayerAnimator.SetBool("isWalking", true);
        }
        if(GameManager.isGameStarted)
        {
            PlayerAnimator.SetBool("isWalking", true);
        } 
        
        else
        {
            Speed = MinSpeed;
            PlayerAnimator.SetBool("isWalking", false);
            PlayerAnimator.SetBool("isRunning", false);
        }*/
    }
    /*void MouseMovementInput(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());
        ReadingValue = context.ReadValue<Vector2>();
        MovementValue.x = ReadingValue.x / 4f;
    }*/
    
    void OnEnable()
    {
        AimInputController.Enable();
    }
    void OnDisable()
    {
        AimInputController.Disable();
    }
}
