using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction moveLeft;
    public InputAction moveAction;
    // Start is called before the first frame update
    void Start()
    {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 24;
        //moveLeft.Enable();
        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
        Vector2 pos = (Vector2)transform.position + move * 3f*Time.deltaTime;
        transform.position = pos;
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
}
