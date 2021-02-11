using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Character1 : MonoBehaviour
{
   
    public TextMeshProUGUI text;
    private Rigidbody2D rb;
    private Animator anim;
   
    public float moveSpeed = 5f;
    float currentSpeed = 0;
    public int health = 100;
    public float invulTime = 2f;

    private float dirX;
    private bool facingRight = true;
    private Vector3 localScale;
    public float hitVol = 5f;
    public Projectile projectile;
    public GameObject hitbox;
    public GameObject barrel;
    public GameObject electricity;
    public GameObject heat;
    public HeatWave heatWave;
    public GameObject Spawn;
    public float idleTime = 15f;
    bool spinning = false;
    bool dashing = false;
    bool canSpin = true;
    public AudioClip SPin;
    public AudioClip DAsh;
    public AudioClip Jump;
    public float dashTime = 1f;
    public float currentDashTime = 0f;
    bool canDash = true;
    float dashSpeed = 0f;
    public bool sideStuck = false;
    public bool downStuck = false;
    bool firstFrameDash = true;
    public GameObject SpinBox;
    bool downDashing = false;
    bool gotHit = false;
    bool down = false;
    bool Left = false;
    public float downDashSpeed = 10f;
    public GameObject downHitBox;
    public GameObject sideHitBox;
    public GameObject Swipe;
    public GameObject Swipe2;
    public float deathTime = 3f;
    float currentDeathTime = 0f;
    bool dieing = false;
    public Slider healthSlider;
    public GameObject meleeeffect;
    public AudioClip blast;
    public AudioClip fvoosh;
    public AudioClip melee;
    public AudioSource main;
    public float waterMass = 0.2f;
    public float Gravity;
    bool isUnder = false;
    float score = 0;
    public float maxScore = 12;
    bool canJump = false;
    bool electric = false;
    bool hot = false;
    bool attacking = false;
    bool canMove = true;
    public float attackTime = 0.2f;
    float time = 0;
    public float SpawnX = 0;
    public float SpawnY = 0;
    enum GravityDirection { Down, Left, Up, Right };
    GravityDirection m_GravityDirection;


    
    void Start()
    {
        Physics2D.gravity = new Vector2(0, -9.8f);
        m_GravityDirection = GravityDirection.Down;
        time = attackTime;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        currentSpeed = moveSpeed;
        SpinBox.SetActive(false);
        currentDashTime = dashTime;
        downHitBox.SetActive(false);
        sideHitBox.SetActive(false);
        Swipe.SetActive(false);
        Swipe2.SetActive(false);
        meleeeffect.SetActive(false);
        currentDeathTime = deathTime;
       
        healthSlider.maxValue = health;
    }

    
    void Update()
    {
        
        healthSlider.value = health;
        if (Input.GetAxisRaw("Vertical") < -0.3)
        {
            down = true;
        }
        if (Input.GetAxisRaw("Vertical") >= 0)
        {
            down = false;
        }
        if (canMove)
        {
            dirX = Input.GetAxisRaw("Horizontal") * currentSpeed;
        }
        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0)
        {
            if (canJump)
            {
                if (canMove)
                {
                    main.PlayOneShot(Jump, hitVol / 2);
                    Physics2D.gravity = new Vector2(0, -9.8f);
                    sideStuck = false;
                    downStuck = false;
                    gameObject.transform.SetParent(null);
                    anim.SetBool("sidestuck", false);
                    anim.SetBool("downstuck", false);
                    anim.SetBool("dashing", false);
                    sideHitBox.SetActive(false);
                    downHitBox.SetActive(false);
                    SpinBox.SetActive(false);
                    if (isUnder == false)
                    {
                        rb.AddForce(Vector2.up * 700f);
                    }
                    else
                    {
                        rb.AddForce(Vector2.up * 400f);
                    }
                }
            }
        }
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.E))
        {
            if (!dashing && !downStuck && !sideStuck)
            {
                if (electric)
                {
                    Projectile clone = (Projectile)Instantiate(projectile, barrel.transform.position, barrel.transform.rotation);
                    clone.clone = true;
                    if (facingRight)
                    {
                        clone.direction = 1;
                    }
                    else
                    {
                        clone.direction = -1;
                    }
                    main.PlayOneShot(blast, hitVol);
                    electric = false;
                }
                else if (hot && !electric)
                {

                    main.PlayOneShot(fvoosh, hitVol);
                    HeatWave clone = (HeatWave)Instantiate(heatWave, gameObject.transform.position, gameObject.transform.rotation);
                    hot = false;

                }
            }
        }
       

        if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0 && !sideStuck && !downStuck)
        {
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);
        }

        if (rb.velocity.y == 0)
        {
            anim.SetBool("jumping", false);
            anim.SetBool("falling", false);
            canJump = true;
        }

        if (rb.velocity.y > 0)
        {
            anim.SetBool("jumping", true);
            anim.SetBool("falling", false);
            canJump = false;
        }

        if (rb.velocity.y < 0)
        {
            anim.SetBool("jumping", false);
            anim.SetBool("falling", true);
            canJump = false;
        }
        if (electric)
        {
            electricity.SetActive(true);
        }
        if (electric == false)
        {
            electricity.SetActive(false);
        }
        if (hot)
        {
            heat.SetActive(true);
        }
        if (!hot)
        {
            heat.SetActive(false);
        }
        if (attacking)
        {
            time -= Time.deltaTime;
            currentSpeed = 0;
        }
        if (time <= 0)
        {
            hitbox.SetActive(false);
            attacking = false;
            anim.SetBool("attacking", false);
            canMove = true;
            meleeeffect.SetActive(false);

        }
        if (!attacking)
        {
            time = attackTime;
            currentSpeed = moveSpeed;
        }
        if (dirX == 0 && canJump == true && idleTime <= 0)
        {
            anim.SetBool("sleeping", true);
        }

        idleTime -= Time.deltaTime;
        Gravity = rb.gravityScale;
        
        if (dirX != 0 || Input.GetButtonDown("Jump"))
        {
            idleTime = 10f;
            anim.SetBool("sleeping", false);
        }
        if (Input.GetButtonDown("Fire2"))
        {

            if (attacking == false && rb.velocity.y == 0)
            {
                Attack();
                main.PlayOneShot(melee, hitVol);
                meleeeffect.SetActive(true);
            }
            
            if (attacking == false && rb.velocity.y != 0 && dirX == 0 && !down && canSpin)
            {

                spinning = true;
                anim.SetBool("spinning", true);
                SpinBox.SetActive(true);
                canSpin = false;
                rb.velocity = new Vector3(0, 10f, 0);
                main.PlayOneShot(SPin, hitVol);
            }

            if (attacking == false && rb.velocity.y != 0 && dirX != 0 && canDash && !spinning && !down)
            {
                if (firstFrameDash)
                {
                    dashSpeed = dirX;
                    firstFrameDash = false;
                    main.PlayOneShot(DAsh, hitVol);
                }
                dashing = true;
                anim.SetBool("dashing", true);
                main.PlayOneShot(DAsh, hitVol);
                SpinBox.SetActive(true);
                sideHitBox.SetActive(true);
                if (dirX < 0)
                {
                    rb.velocity = new Vector3(dashSpeed - 5f, 0, 0);
                    Left = true;
                }
                if (dirX > 0)
                {
                    rb.velocity = new Vector3(dashSpeed + 5f, 0, 0);
                    Left = false;
                }
                
                canDash = false;
            }
            if (attacking == false && rb.velocity.y != 0 && canDash && !spinning && down)
            {
                downHitBox.SetActive(true);
                main.PlayOneShot(DAsh, hitVol);
                downDashing = true;
                anim.SetBool("downdashing", true);
                main.PlayOneShot(DAsh, hitVol);
                rb.velocity = new Vector3(0, -downDashSpeed, 0);
                
            }
        }
        if (dashing)
        {
            currentDashTime -= Time.deltaTime;
            Physics2D.gravity = new Vector2(0, -0.1f);
        }
        if (currentDashTime <= 0)
        {
            dashing = false;
            currentDashTime = dashTime;
            anim.SetBool("dashing", false);
            SpinBox.SetActive(false);
            Physics2D.gravity = new Vector2(0, -9.8f);
            sideHitBox.SetActive(false);
        }
        if (downDashing || downStuck)
        {
            rb.velocity = new Vector3(0, -downDashSpeed, 0);
        }
        if (dashing)
        {
            if (Left)
            {
                rb.velocity = new Vector3(dashSpeed - 5f, 0, 0);
            }
            if (!Left)
            {
                rb.velocity = new Vector3(dashSpeed + 5f, 0, 0);
            }
        }
        if (downStuck)
        {
            anim.SetBool("jumping", false);
        }
        if (gotHit)
        {
            invulTime -= Time.fixedDeltaTime;
            anim.SetBool("gothit", true);
        }
        if (invulTime <= 0)
        {
            gotHit = false;
            invulTime = 2f;
            anim.SetBool("gothit", false);
        
        }
        if (spinning)
        {
            if (facingRight)
            {
                Swipe.SetActive(true);
                Swipe2.SetActive(false);
            }
            else
            {
                Swipe.SetActive(false);
                Swipe2.SetActive(true);
            }
        }
        if (!spinning)
        {
            Swipe.SetActive(false);
            Swipe2.SetActive(false);
        }
        if (dieing)
        {
            currentDeathTime -= Time.fixedDeltaTime;
        }
        if (currentDeathTime <= 0)
        {
            Reset();
            currentDeathTime = deathTime;
            dieing = false;
        }
    }
    private void FixedUpdate()
    {
        if (!dashing)
        {
            if(!sideStuck)
            {
                if (!downStuck)
                {
                    if (!gotHit)
                    {
                        rb.velocity = new Vector2(dirX, rb.velocity.y);
                    }
                }
            }
        }
    }

    private void LateUpdate()
    {
        if (dirX > 0)
        {
            facingRight = true;
            
            
        }
        else if (dirX < 0)
        {
            facingRight = false;
            
        }
        if (!dashing && !sideStuck && !downStuck)
        {
            if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            {
                localScale.x *= -1;
                
            }
        }

        transform.localScale = localScale;
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag == "Water")
        {
            isUnder = true;
            electric = false;
            hot = false;
        }
        if (other.transform.tag == "electricity")
        {
            electric = true;
        }
        if (other.transform.tag == "magnetu")
        {
            if (electric)
            {
                Physics2D.gravity = new Vector2(0, 9.8f);
            }
            else
            {
                Physics2D.gravity = new Vector2(0, -9.8f);
            }
        }
        if (other.transform.tag == "magnetd")
        {
            if (electric)
            {
                Physics2D.gravity = new Vector2(0, -50f);
            }
            else
            {
                Physics2D.gravity = new Vector2(0, -9.8f);
            }
        }
        if (other.transform.tag == "magnetl")
        {
            if (electric)
            {
                Physics2D.gravity = new Vector2(-100f, -9.8f);
            }
            else
            {
                Physics2D.gravity = new Vector2(0, -9.8f);
            }
        }
        if (other.transform.tag == "magnetr")
        {
            if (electric)
            {
                Physics2D.gravity = new Vector2(100f, -9.8f);
            }
            else
            {
                Physics2D.gravity = new Vector2(0, -9.8f);
            }
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.transform.tag == "KillZone")
        {
            CallReset();
        }
        if (spinning)
        {
            spinning = false;
            anim.SetBool("spinning", false);
            SpinBox.SetActive(false);
        }
        if (collision.transform.tag == "Untagged")
        {
            canSpin = true;
            canDash = true;
        }
        firstFrameDash = true;        
    }
    public void DownDash()
    {
            downStuck = true;
            downDashing = false;
            anim.SetBool("falling", false);
            anim.SetBool("downstuck", true);
            canJump = true;
            rb.velocity = new Vector3(0, 0, 0);
            anim.SetBool("downdashing", false);       
    }
    public void SideDash()
    {
        sideStuck = true;
        dashing = false;
        anim.SetBool("sidestuck", true);
        Physics2D.gravity = new Vector2(0, 0f);
        canJump = true;
        currentDashTime = dashTime;
        rb.velocity = new Vector3(0, 0, 0);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Water")
        {
            isUnder = false;
           
        }
        if (collision.transform.tag == "magnetu" || collision.transform.tag == "magnetl" || collision.transform.tag == "magnetr" || collision.transform.tag == "magnetd")
        {
            Physics2D.gravity = new Vector2(0, -9.8f);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Lava")
        {
            hot = true;
        }
        if (collision.transform.tag == "Pickup")
        {
            score = score + 1;
            text.text = "" + score;
        }
        if (score == maxScore)
        {
            text.text = "All Thingamagigs Collected!";
        }
        

    }
    void Attack()
    {
        hitbox.SetActive(true);
        attacking = true;
        anim.SetBool("attacking", true);
        canMove = false;
    }
    public void Damage(int damage)
    {
        if (!spinning && !dashing && !attacking && !downDashing && !gotHit)
        {
            health -= damage;
            anim.SetBool("gothit", true);
            gotHit = true;
            if (localScale.x == 1)
            {
                rb.velocity += new Vector2(-5f, 0);
            }
            if (localScale.x == -1)
            {
                rb.velocity += new Vector2(5f, 0);
            }
            if (health <= 0)
            {
                CallReset();
            }
        }
    }
    
    void Reset()
    {
        gameObject.transform.position = new Vector2(SpawnX, SpawnY);
        health = 100;
        Physics2D.gravity = new Vector2(0, -9.8f);
    }
    public void CallReset()
    {
        dieing = true;
    }
}