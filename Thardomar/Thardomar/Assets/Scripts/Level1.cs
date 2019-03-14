using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1 : MonoBehaviour
{
    private GameObject Player;
    public float Moneys;

    // Password
    public bool Letter1 = false;
    public bool Letter2 = false;
    public bool Letter3 = false;
    public bool Letter4 = false;
    public bool Letter5 = false;
    public bool Letter6 = false;
    public float Range;
    public TextMesh PasswordText;
    public bool Guessed = false;
    public bool Completed = false;


    void Start()
    {
        Player = FindObjectOfType<Player>().gameObject;
    }

    void Update()
    {
        if (Guessed == true && Completed == false)
        {
            if (Moneys >= 4)
            {
                Completed = true;
                Player.transform.position = new Vector3(-17, 0.6f, 30);
            }
        }

        Password();
    }

    void Password()
    {
        if (Guessed == false)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Player.transform.position - transform.position, out hit, Range))
            {
                if (Input.anyKeyDown)
                {
                    if (Input.GetKeyDown(KeyCode.L) && Letter1 == false)
                    {
                        Letter1 = true;
                        PasswordText.text = "*";
                        PasswordText.characterSize = 0.19f;
                    }
                    else if (Input.GetKeyDown(KeyCode.A) && Letter2 == false && Letter1 == true)
                    {
                        Letter2 = true;
                        PasswordText.text = "**";
                    }
                    else if (Input.GetKeyDown(KeyCode.M) && Letter3 == false && Letter2 == true)
                    {
                        Letter3 = true;
                        PasswordText.text = "***";
                    }
                    else if (Input.GetKeyDown(KeyCode.P) && Letter4 == false && Letter3 == true)
                    {
                        Letter4 = true;
                        PasswordText.text = "****";
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha5) && Letter5 == false && Letter4 == true)
                    {
                        Letter5 = true;
                        PasswordText.text = "*****";
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha6) && Letter6 == false && Letter5 == true)
                    {
                        Letter6 = true;
                        PasswordText.text = "******";
                        Moneys = 0;
                        Guessed = true;
                        Player.transform.position = new Vector3(-22, 0.6f, 30);
                        Player.GetComponent<Player>().CurrentLevel = 1;
                    }
                    else
                    {
                        PasswordText.text = "Password";
                        PasswordText.characterSize = 0.1f;
                        Letter1 = false;
                        Letter2 = false;
                        Letter3 = false;
                        Letter4 = false;
                        Letter5 = false;
                        Letter6 = false;
                    }
                }
            }
            else
            {
                Letter1 = false;
                Letter2 = false;
                Letter3 = false;
                Letter4 = false;
                Letter5 = false;
                Letter6 = false;
            }
        }
    }
}

