using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction moveLeft;
    public InputAction moveAction;
    Rigidbody2D rigidbody;
    Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 24;
        moveAction.Enable();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = moveAction.ReadValue<Vector2>();
        
        //float horizontal = 0.0f;
        //float vertical = 0f;
        //if (moveLeft.IsPressed())
        //{
        //    horizontal = -1f;
        //}
        //else if (Keyboard.current.rightArrowKey.isPressed)
        //{
        //    horizontal = 1f;
        //}
        //if (Keyboard.current.upArrowKey.isPressed)
        //{
        //    vertical = 1f;
        //}
        //else if(Keyboard.current.downArrowKey.isPressed)
        //{
        //    vertical = -1f;
        //}
        //Vector2 pos = transform.position;
        //pos.x += 0.1f * horizontal;
        //pos.y += 0.1f * vertical;
        //transform.position = pos;
    }
    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + move * 3f * Time.fixedDeltaTime);
    }
}
