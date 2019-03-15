using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    public GameObject Player;

    void Start()
    {
        Player = FindObjectOfType<Player>().gameObject;
    }

    void OnCollisionEnter(Collision col)
    {
        Player.GetComponent<Player>().CurrentHealth = 100;
        Destroy(gameObject);
    }
}
