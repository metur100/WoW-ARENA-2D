﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalToUpperCave : MonoBehaviour
{
    public GameObject portal;
    public GameObject player;
    public GameObject portalEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player_Knight_Advanturer"))
        {
            Instantiate(portalEffect, portalEffect.transform.position, Quaternion.identity);
            //StartCoroutine(Teleport());
            player.transform.position = new Vector2(portal.transform.position.x, portal.transform.position.y);
        }
    }
    //    IEnumerator Teleport()
    //    {
    //        yield return new WaitForSeconds(0.1f);
    //        player.transform.position = new Vector2(portal.transform.position.x, portal.transform.position.y);
    //    }
}