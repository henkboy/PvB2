using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject Player;
    public GameObject Lvl1;

    void Start()
    {
        Player = FindObjectOfType<Player>().gameObject;
        Lvl1 = FindObjectOfType<Level1>().gameObject;
    }

    void OnTriggerEnter(Collider Col)
    {
        Lvl1.GetComponent<Level1>().Moneys++;
        Player.GetComponent<Player>().Money++;
        Destroy(gameObject);
    }
}
