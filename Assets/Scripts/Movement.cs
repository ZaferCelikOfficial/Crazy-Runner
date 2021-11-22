using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    CharacterController PlayerCharacterController;
    float Speed= 1.5f;
    InputController PlayerInputController;
    Vector2 ReadingValue;
    Vector3 MovementValue;
    [SerializeField] GameObject PlayerModel;
    Animator PlayerAnimator;
    float MinSpeed = 1.5f;
    float MaxSpeed = 3f;

    void Awake()
    {
        ReadingValue = Vector2.zero;
        PlayerCharacterController = this.GetComponent<CharacterController>();
        PlayerInputController = new InputController();
        
        /*PlayerInputController.CharacterControls.Move.started += MovementInput;
        PlayerInputController.CharacterControls.Move.performed += MovementInput;
        PlayerInputController.CharacterControls.Move.canceled += MovementInput;*/

        /*PlayerInputController.CharacterControls.MouseMove.started += MouseMovementInput;
        PlayerInputController.CharacterControls.MouseMove.performed += MouseMovementInput;
        PlayerInputController.CharacterControls.MouseMove.canceled += MouseMovementInput;*/

        PlayerAnimator = PlayerModel.GetComponent<Animator>();
        PlayerAnimator.SetBool("isFinishing", false);
    }
    void Update()
    {
        if (GameManager.isGameStarted && !GameManager.isGameEnded)
        {
            PlayerAnimator.SetBool("isWalking", true);
        }
        else
        {
            PlayerAnimator.SetBool("isWalking", false);
        }
        GravityControl();
        MovePlayerForward();
        if (PlayerAnimator.GetBool("isWalking"))
        {
            Speed = Mathf.Clamp(Speed+Time.deltaTime, MinSpeed, MaxSpeed);
            PlayerAnimator.SetFloat("Blend", (Speed - MinSpeed)/1.5f);
            /*if(!PlayerAnimator.GetBool("isRunning")&&Speed>(MinSpeed+1.5f))
            {
                PlayerAnimator.SetBool("isRunning", true);
            }*/
           
        }
    }
    void MovePlayerForward()
    {
        if (GameManager.isGameStarted&&!GameManager.isGameEnded)
        {
            //this.transform.GetComponent<CharacterController>().Move(this.transform.forward * Speed * Time.deltaTime);
            MovementValue.z = this.transform.forward.z;
            PlayerCharacterController.Move(MovementValue * Speed * Time.deltaTime);
        }
        
    }
    void MovementInput(InputAction.CallbackContext context)
    {
        //Debug.Log(context.ReadValue<Vector2>());
        //ReadingValue = context.ReadValue<Vector2>();
        //MovementValue.x = ReadingValue.x;
        
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
        MovementValue.x = ReadingValue.x/4f;
    }*/
    void GravityControl()
    {
        if(PlayerCharacterController.isGrounded)
        {
            float GravityRate = -0.1f;
            MovementValue.y = GravityRate;
        }
        else
        {
            float GravityRate = -9.8f;
            MovementValue.y = GravityRate;
        }
    }
    void OnEnable()
    {
        PlayerInputController.Enable();
    }
    void OnDisable()
    {
        PlayerInputController.Disable();  
    }
}
