﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject Player;
    public GameObject LvlManager;

    void Start()
    {
        Player = FindObjectOfType<Player>().gameObject;
    }

    void OnTriggerEnter(Collider Col)
    {
        Player.GetComponent<Player>().Money++;
        Destroy(gameObject);
    }
}
