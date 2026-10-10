using UnityEngine;
using UnityEngine.InputSystem;


namespace Theerapat_Boongrom.Code672110100
{
    public class PlayerMovement : MonoBehaviour
    {
        InputAction moveAction;
        InputAction jumpAction;

        void Awake()
        {
            moveAction = InputSystem.actions.FindAction("Player/Move");
            jumpAction = InputSystem.actions.FindAction("Player/Jump");
        }

        void OnEnable()
        {
            moveAction?.Enable();
            jumpAction?.Enable();
        }

        void OnDisable()
        {
            moveAction?.Disable();
            jumpAction?.Disable();
        }

        void Update()
        {
            Vector2 move = moveAction.ReadValue<Vector2>();
            transform.Translate(new Vector3(move.x, 0f, move.y) * Time.deltaTime * 5f);
        }
    }
    
}
