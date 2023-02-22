 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class PlayerShoot : MonoBehaviour
{

    //they are magazines, not clips
    public PlayerShoot playerShoot;
    public GameObject bullet;
    public int currentMag, maxMagSize = 6, currentReserves, maxReserveSize = 90;
    private bool reload = false;
    public float speed;
    public float bulletLifeTime = 1.5f;
    public AudioClip shootSound;
    float timer = 0.0f;
    float reloadTimer = 0.0f;
    public float shootDelay;
    public static bool grounded = false;
    
    Animator animator;
    SpriteRenderer spriteRenderer;

    public float fireRate = 10;
    float lastFired;


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");

        timer += Time.deltaTime;
        if (Time.timeScale == 1)
        {
            if (Input.GetButton("Fire1") &&  currentMag > 0 && reload == false)
            {
                animator.SetTrigger("Active");
                if (Time.time - lastFired > 1 / fireRate)
                {
                 
                    playerShoot.AutomaticFire();
                    currentMag--;
                    GetComponent<AudioSource>().PlayOneShot(shootSound);
                    timer = 0;
                }
            }

            //reload when r is pressed
            reloadTimer += Time.deltaTime;
            
            if (currentMag == 0 && currentReserves > 0)
            {
                reloadTimer = 0;
                playerShoot.Reload();
                reload = true;
                
            }
            if (reloadTimer >= 1.75 )
            {
              
                reload = false;
            }
            
            //flipping the gun
            animator.SetFloat("xInput", xInput);
            animator.SetBool("grounded", grounded);
            if (xInput < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (xInput > 0)
            {
                spriteRenderer.flipX = false;
            }
           
        }
    }

    public void Reload()
    {
        if( currentMag < maxMagSize)
        {
            animator.SetTrigger("reload");
        }
        int reloadAmount = maxMagSize - currentMag;
        reloadAmount = (currentReserves - reloadAmount) >= 0 ? reloadAmount : currentReserves;
        //add rounds to your gun
        currentMag += reloadAmount;
        //take away rounds from reserve
        currentReserves -= reloadAmount;
    }
    //the amount of rounds that get picked up
    public void AddRounds(int roundAmmount)
    {
        currentReserves += roundAmmount;
        if(currentReserves > maxReserveSize)
        {
            currentReserves = maxReserveSize;
        }
    }
     //full auto
    public void AutomaticFire()
    {
        lastFired = Time.time;
        GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.identity);
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 shootDirection = mousePosition - transform.position;
        shootDirection.Normalize();
        bulletClone.GetComponent<Rigidbody2D>().velocity = shootDirection * speed;
        Destroy(bulletClone, bulletLifeTime);
    }
}
