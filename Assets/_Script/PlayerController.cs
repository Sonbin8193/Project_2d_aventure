using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction moveLeft;
    public InputAction moveAction;
    Rigidbody2D rb;
    public int maxHealth = 5;
    public float speed = 3f;
    public int health { get { return currentHealth; } }
    private int currentHealth;

    public float timeInvicible = 2f;
    private bool isInvicible;
    private float damageCooldown;

    Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 24;
        moveAction.Enable();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
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
        if (isInvicible)
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown < 0)
            {
                isInvicible = false;
            }
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }
    public void ChangeHealth(int amount)
    {
        if (amount<0)
        {
            if (isInvicible)
            {
                return;
            }
            isInvicible = true;
            damageCooldown = timeInvicible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHandler.instance.SetHealth((float)currentHealth / maxHealth);
    }
}
