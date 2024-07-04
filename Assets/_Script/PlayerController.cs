using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction moveLeft;
    public InputAction moveAction;
    public GameObject projectilePrefabs;
    public InputAction launchAction;
    public int maxHealth = 5;
    public float speed = 3f;
    public float timeInvicible = 2f;
    public int health { get { return currentHealth; } }

    Animator animator;
    Vector2 moveDirection = new Vector2 (1f, 0f);
    Rigidbody2D rb;
    
    private int currentHealth;
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
        animator = GetComponent<Animator>();
        launchAction.Enable();
        launchAction.performed += Launch;
    }


    void Update()
    {         
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            moveDirection.Set (move.x, move.y);
            moveDirection.Normalize ();
        }
        animator.SetFloat("Look X", moveDirection.x);
        animator.SetFloat("Look Y", moveDirection.y);
        animator.SetFloat("Speed", move.magnitude);
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
        move = moveAction.ReadValue<Vector2>();
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
        animator.SetTrigger("Hit");
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHandler.instance.SetHealth((float)currentHealth / maxHealth);
    }

    private void Launch(InputAction.CallbackContext context)
    {
        GameObject projectileObject = Instantiate(projectilePrefabs, rb.position + Vector2.up * 0.5f, Quaternion.identity);
        projectileObject.GetComponent<Projectile>().Launch(moveDirection, 300);
        animator.SetTrigger("Launch");
    }
}
