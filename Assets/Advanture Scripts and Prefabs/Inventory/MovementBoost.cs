﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBoost : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player_Knight_Advanturer"))
        {
            PlayerMovementAdvanturerKnight speedBoost = collision.gameObject.GetComponent<PlayerMovementAdvanturerKnight>();
            speedBoost.normalMovementSpeed = 800f;
        }
        Destroy(gameObject);
    }
}