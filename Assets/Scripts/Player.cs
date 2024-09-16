using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IEntity
{
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody rb;

    //изменить логику дамага
    [SerializeField] private int damage;
    [Space(10)]

    [SerializeField] private float speed;
    [SerializeField] private float speedBoostMultiplier;
    [SerializeField] private float maxSpeed;
    [Space(10)]
 
    public float maxStamina;
    public float stamina;
    [SerializeField] private float staminaPerSec;
    [Space(10)]

    [SerializeField] private float jumpForce;
    [Space(10)]

    [SerializeField] private int maxHp;
    [Space(10)]

    [SerializeField] private GroundCheck groundCheck;
    [SerializeField] private InteractionZone InteractionZone;
    private bool running;

    private int hp;

    public int Hp => hp;

    public int MaxHp => maxHp;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InputManager.OnMouseLeftClick += Attack;
        stamina = maxStamina;
    }

    private void Update()
    {
        if (groundCheck.isGrounded)
        {
            Jump();
        }
        Run();

    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //разобрать как работает
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        rb.AddForce(moveDirection * speed);

        if (rb.velocity.magnitude >= maxSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.normalized.x * maxSpeed, rb.velocity.y, rb.velocity.normalized.z * maxSpeed);
        }
    }

    private void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && stamina > 0)
        {
            running = true;
            speed *= speedBoostMultiplier;
            maxSpeed *= speedBoostMultiplier;
            //stamina -= staminaPerSec * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            stamina -= staminaPerSec * Time.deltaTime;
            stamina = Mathf.Clamp(stamina, 0, maxStamina);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || stamina <= 0)
        {
            running = false;
            speed /= speedBoostMultiplier;
            maxSpeed /= speedBoostMultiplier;
            StartCoroutine(StaminaRecovery());
        }
    }

    private IEnumerator StaminaRecovery()
    {
        Debug.Log("coroutine");

        if (!running)
        {
            while (stamina < maxStamina && !running)
            {
                yield return new WaitForSeconds(1f);

                Debug.Log("Stamina");
                stamina += staminaPerSec;
            }
        }
        
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (InteractionZone.entity != null)
            {
                InteractionZone.entity.Damage(damage);
            }
        }
    }

    public void Damage(int damage)
    {
        throw new System.NotImplementedException();
    }

    public void Heal(int heal)
    {
        throw new System.NotImplementedException();
    }
}
