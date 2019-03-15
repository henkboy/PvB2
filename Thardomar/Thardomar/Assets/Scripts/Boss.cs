using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour {

    private GameObject Player;
    public GameObject Ingot;
    public GameObject EndText;

    // Attacking
    public int Bullets;
    public GameObject Bullet;
    public GameObject SpawnPos;
    private GameObject BulletClone;
    public float AggroRange = 5;
    public float AttackRange = 2;
    private bool Attacked = false;

    // Health
    public float Health;
    private float CurrentHealth;
    public Material Green;
    public Material Red;

    void Start()
    {
        Player = FindObjectOfType<Player>().gameObject;
        StartCoroutine("Shooting");
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
        }

        if (Health != CurrentHealth)
        {
            CurrentHealth = Health;
            StartCoroutine("Damage");
        }

        if (Health <= 0)
        {
            EndText.SetActive(true);
            Instantiate(Ingot, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            for (int i = 0; i < Bullets; i++)
            {
                yield return new WaitForSeconds(0.5f);
                BulletClone = Instantiate(Bullet, SpawnPos.transform.position, SpawnPos.transform.rotation);
                BulletClone.GetComponent<Rigidbody>().AddForce(SpawnPos.transform.forward * 1000);
            }
            yield return new WaitForSeconds(3.5f);
        }
    }

    IEnumerator Damage()
    {
        GetComponent<Renderer>().material = Red;

        yield return new WaitForSeconds(0.2f);

        GetComponent<Renderer>().material = Green;
    }

    IEnumerator Cooldown()
    {
        Attacked = true;
        yield return new WaitForSeconds(1);
        Attacked = false;
    }
}
