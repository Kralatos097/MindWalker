using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mur : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerMove player = other.GetComponent<PlayerMove>();
        if(player != null)
        {
            player.DeathAction();
        }
    }
}
