using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour {

    private GameObject Player;
    public float Moneys;
    public GameObject CanType;
    public GameObject Level3;

    // Password
    public bool Letter1 = false;
    public bool Letter2 = false;
    public bool Letter3 = false;
    public bool Letter4 = false;
    public bool Letter5 = false;
    public bool Letter6 = false;
    public bool Letter7 = false;
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
            if (Moneys >= 6)
            {
                Completed = true;
                Player.transform.position = new Vector3(17.5f, 0.6f, 33);
                Level3.GetComponent<Level3>().Lvl2Complete = true;
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
                if (CanType.activeInHierarchy == false)
                {
                    CanType.SetActive(true);
                }

                if (Input.anyKeyDown)
                {
                    if (Input.GetKeyDown(KeyCode.C) && Letter1 == false)
                    {
                        Letter1 = true;
                        PasswordText.text = "*";
                        PasswordText.characterSize = 0.19f;
                    }
                    else if (Input.GetKeyDown(KeyCode.H) && Letter2 == false && Letter1 == true)
                    {
                        Letter2 = true;
                        PasswordText.text = "**";
                    }
                    else if (Input.GetKeyDown(KeyCode.A) && Letter3 == false && Letter2 == true)
                    {
                        Letter3 = true;
                        PasswordText.text = "***";
                    }
                    else if (Input.GetKeyDown(KeyCode.I) && Letter4 == false && Letter3 == true)
                    {
                        Letter4 = true;
                        PasswordText.text = "****";
                    }
                    else if (Input.GetKeyDown(KeyCode.R) && Letter5 == false && Letter4 == true)
                    {
                        Letter5 = true;
                        PasswordText.text = "*****";
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha1) && Letter6 == false && Letter5 == true)
                    {
                        Letter6 = true;
                        PasswordText.text = "******";
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha2) && Letter7 == false && Letter6 == true)
                    {
                        Letter7 = true;
                        PasswordText.text = "*******";
                        Moneys = 0;
                        Guessed = true;
                        Player.transform.position = new Vector3(22, 0.6f, 33);
                        Player.GetComponent<Player>().CurrentLevel = 2;
                        CanType.SetActive(false);
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
                if (CanType.activeInHierarchy == true)
                {
                    CanType.SetActive(false);
                }
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
