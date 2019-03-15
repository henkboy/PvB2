using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject Player;
    public GameObject Lvl1;
    public GameObject Lvl2;

    void Start()
    {
        Player = FindObjectOfType<Player>().gameObject;
        Lvl1 = FindObjectOfType<Level1>().gameObject;
        Lvl2 = FindObjectOfType<Level2>().gameObject;
    }

    void OnTriggerEnter(Collider Col)
    {
        Lvl1.GetComponent<Level1>().Moneys++;
        Lvl2.GetComponent<Level2>().Moneys++;
        Player.GetComponent<Player>().Money++;
        Destroy(gameObject);
    }
}
