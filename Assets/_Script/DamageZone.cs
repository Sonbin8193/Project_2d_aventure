using System.Collections;       
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            //player.BroadcastMessage("ChangeHealth", -1);
            player.ChangeHealth(-1);
        }
    }
}
