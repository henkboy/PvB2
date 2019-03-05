using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Health
    public float CurrentHealth;
    public float MaxHealth;
    public Slider healthSlider;
    public GameObject Restart;

    // Movement
    private float Speed;
    public float WalkSpeed;
    public float SprintSpeed;
    public Rigidbody rb;

    // Attacking
    public GameObject SpawnPos;
    public GameObject EndBoss;

    // Collectibles
    public Text Collectibles;
    private int m_Collectible;
    public int Collectible
    {
        get { return m_Collectible; }
        set
        {
            if (m_Collectible == value)
                return;

            m_Collectible = value;
            Collectibles.text = "Collectibles: " + m_Collectible + "/8";
        }
    }

    private AudioSource JumpSound;
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

        float translationX = Input.GetAxis("Horizontal") * Speed;
        float translationZ = Input.GetAxis("Vertical") * Speed;

        translationX *= Time.deltaTime;
        translationZ *= Time.deltaTime;

        transform.Translate(translationX, 0, translationZ);

        // Animations
        //float MoveVertical = Input.GetAxis("Vertical");
        //Anim.SetFloat("Vertical", MoveVertical);
        //float MoveHorizontal = Input.GetAxis("Horizontal");
        //Anim.SetFloat("Horizontal", MoveHorizontal);
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            RaycastHit hit;
            Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.forward);
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.forward);
            if (Physics.Raycast(ray, out hit))
            {
                //if (hit.collider.name == "EndBoss")
                //{
                //    EndBoss.GetComponent<Enemy>().Health(5);
                //}
            }
        }
    }

    public void Health(int amount)
    {
        CurrentHealth -= amount;
        healthSlider.value = CurrentHealth;

        if (CurrentHealth <= 0)
        {
            healthSlider.value = MaxHealth;
            //Restart.gameObject.GetComponent<Reset>().CheckProgression();
        }
    }
}