using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private GameObject Player;
    public GameObject Ingot;

    // Attacking
    public float AggroRange = 5;
    public float AttackRange = 2;
    private bool Attacked = false;

    // Health
    public float Health;
    private float CurrentHealth;
    public Material Blue;
    public Material Red;

    public AudioSource Damaged;

    void Start()
    {
        Player = FindObjectOfType<Player>().gameObject;
        Damaged = GetComponent<AudioSource>();
        CurrentHealth = Health;
    }

    void Update()
    {
        Vector3 PlayerPos = new Vector3(Player.transform.position.x - transform.position.x, 0, Player.transform.position.z - transform.position.z);

        Debug.DrawRay(transform.position, PlayerPos * AggroRange, Color.blue);
        Debug.DrawRay(transform.position, PlayerPos * AttackRange, Color.red);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, PlayerPos, out hit, AggroRange))
        {
            GetComponent<NavMeshAgent>().destination = Player.transform.position;

            if (Physics.Raycast(transform.position, PlayerPos, out hit, AttackRange))
            {
                if (Attacked == false)
                {
                    Player.GetComponent<Player>().Health(10);
                    StartCoroutine("Cooldown");
                }
            }
        }
        if( Health != CurrentHealth)
        {
            CurrentHealth = Health;
            StartCoroutine("Damage");
            Damaged.Play();
        }

        if (Health <= 0)
        {
            Instantiate(Ingot, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }
    }

    IEnumerator Damage()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            child.GetComponent<Renderer>().material = Red;
        }
            GetComponent<Renderer>().material = Red;
        yield return new WaitForSeconds(0.2f);

        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            child.GetComponent<Renderer>().material = Blue;
        }
        GetComponent<Renderer>().material = Blue;
    }

    IEnumerator Cooldown()
    {
        Attacked = true;
        yield return new WaitForSeconds(1);
        Attacked = false;
    }
}
