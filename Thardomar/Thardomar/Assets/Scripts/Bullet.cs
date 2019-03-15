using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    
    private Player playerscript;
    public int Damage;

    void Start()
    {
        StartCoroutine(Timer());
        playerscript = FindObjectOfType<Player>();
    }

    void OnCollisionEnter(Collision Col)
    {
        if (Col.gameObject.name == "Player")
        {
            playerscript.Health(Damage);
        }
        Destroy(gameObject);
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
