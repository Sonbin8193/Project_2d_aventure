using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectibleHealth : MonoBehaviour
{
    public int plusHealth;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            if (player.health < player.maxHealth)
            {
                player.ChangeHealth(plusHealth);
                Destroy(gameObject);
            }
        }
    }
}
