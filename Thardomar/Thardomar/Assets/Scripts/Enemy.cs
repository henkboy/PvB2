using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    private GameObject Player;
    public float Health;
    public GameObject Ingot;

    // Attacking
    public float AggroRange = 5;
    public float AttackRange = 2;
    private bool Attacked = false;

    void Start()
    {
        Player = FindObjectOfType<Player>().gameObject;
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, (Player.transform.position - transform.position), out hit, AggroRange))
        {
            GetComponent<NavMeshAgent>().destination = Player.transform.position;

            if (Physics.Raycast(transform.position, (Player.transform.position - transform.position), out hit, AttackRange))
            {
                if (Attacked == false)
                {
                    Player.GetComponent<Player>().Health(10);
                    StartCoroutine("Cooldown");
                }
            }
        }

        if (Health <= 0)
        {
            Instantiate(Ingot, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }
    }

    IEnumerator Cooldown()
    {
        Attacked = true;
        yield return new WaitForSeconds(1);
        Attacked = false;
    }
}
