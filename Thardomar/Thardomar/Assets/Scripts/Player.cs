﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Movement
    private float Speed;
    public float WalkSpeed;
    public float SprintSpeed;
    public float TurnSpeed;

    // Attacking
    public GameObject Boss;

    // Health
    public float CurrentHealth;
    public float MaxHealth;
    public Slider healthSlider;
    public float CurrentLevel;
    public bool TimeStarted = false;

    // Collectibles
    public Text MoneyUI;
    private int i_money;
    public int Money
    {
        get { return i_money; }
        set
        {
            if (i_money == value)
                return;

            i_money = value;
            MoneyUI.text = "Money: " + i_money;
        }
    }

    private Animator Anim;

    void Start()
    {
        CurrentHealth = MaxHealth;
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
        Attack();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Joystick1Button8))
        {
            Speed = SprintSpeed;
        }
        else
        {
            Speed = WalkSpeed;
        }

        float translationZ = Input.GetAxis("Vertical") * Speed;
        translationZ *= Time.deltaTime;
        transform.Translate(0, 0, translationZ);

        transform.Rotate(0, Input.GetAxis("Rotate") * TurnSpeed * Time.deltaTime, 0);

        // Animations
        float MoveVertical = Input.GetAxis("Vertical");
        Anim.SetFloat("Walk", MoveVertical);
        if(Speed == SprintSpeed)
        {
            Anim.SetBool("Run", true);
        }
        else
        {
            Anim.SetBool("Run", false);
        }
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            RaycastHit hit;
            Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.forward);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == "Guard")
                {
                    hit.collider.gameObject.GetComponent<Enemy>().Health--;
                }
                else if (hit.collider.name == "Boss")
                {
                    hit.collider.gameObject.GetComponent<Boss>().Health--;
                }
            }
        }
    }

    public void Health(int amount)
    {
        CurrentHealth -= amount;
        healthSlider.value = CurrentHealth;

        if (CurrentHealth <= 0 && TimeStarted == false)
        {         
            StartCoroutine("Dying");
        }
    }
    IEnumerator Dying()
    {
        TimeStarted = true;
        Anim.SetTrigger("Dying");
        yield return new WaitForSeconds(4);
        
        if(CurrentLevel == 1)
        {
            healthSlider.value = MaxHealth;
            CurrentHealth = MaxHealth;
            transform.position = new Vector3(-22, 0.6f, 30);
        }
        if (CurrentLevel == 2)
        {
            healthSlider.value = MaxHealth;
            CurrentHealth = MaxHealth;
            transform.position = new Vector3(22, 0.6f, 33);
        }
        if (CurrentLevel == 3)
        {
            healthSlider.value = MaxHealth;
            CurrentHealth = MaxHealth;
            transform.position = new Vector3(-1, 0.6f, 18);
            Boss.GetComponent<Boss>().Health = 10;
            
        }
        TimeStarted = false;
    }
}