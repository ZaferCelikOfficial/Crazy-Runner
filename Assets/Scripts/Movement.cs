using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    CharacterController PlayerCharacterController;
    float Speed= 1f;
    InputController PlayerInputController;
    Vector2 ReadingValue;
    Vector3 MovementValue;
    [SerializeField] GameObject PlayerModel;
    Animator PlayerAnimator;
    float MinSpeed = 1f;
    float MaxSpeed = 2f;

    void Awake()
    {
        ReadingValue = Vector2.zero;
        PlayerCharacterController = this.GetComponent<CharacterController>();
        PlayerInputController = new InputController();

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
            PlayerAnimator.SetFloat("Blend", (Speed - MinSpeed));

        }
    }
    void MovePlayerForward()
    {
        if (GameManager.isGameStarted&&!GameManager.isGameEnded)
        {
            MovementValue.z = this.transform.forward.z;
            PlayerCharacterController.Move(MovementValue * Speed * Time.deltaTime);
        }
        
    }
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
