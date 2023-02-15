 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerShoot : MonoBehaviour
{
    public PlayerShoot playerShoot;
    public GameObject bullet;
    public int currentCylinder, maxMagSize = 6, currentReserves, maxReserveSize = 90;
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
            if (Input.GetButtonDown("Fire1") && timer >= shootDelay &&  currentCylinder > 0 && reload == false)
            {
                animator.SetTrigger("Active");
                GameObject bulletSpawn = Instantiate(bullet, transform.position, Quaternion.identity);
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = -Camera.main.transform.position.z;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                Vector3 shootDirection = mousePosition - transform.position;
                shootDirection.Normalize();
                bulletSpawn.GetComponent<Rigidbody2D>().velocity = shootDirection * speed;
                Destroy(bulletSpawn, bulletLifeTime);
                currentCylinder--;
                GetComponent<AudioSource>().PlayOneShot(shootSound);
                timer = 0;
            }

            reloadTimer += Time.deltaTime;
            
            if (Input.GetKeyDown(KeyCode.R) && currentCylinder < maxMagSize)
            {
                reloadTimer = 0;
                playerShoot.Reload();
                reload = true;
            }
            if (reloadTimer >= 1.25)
            {
                reload = false;
            }

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
        if( currentCylinder < maxMagSize)
        {
            animator.SetTrigger("reload");
        }
        int reloadAmount = maxMagSize - currentCylinder;
        reloadAmount = (currentReserves - reloadAmount) >= 0 ? reloadAmount : currentReserves;
        currentCylinder += reloadAmount;
        currentReserves -= reloadAmount;
    }

    public void AddRounds(int roundAmmount)
    {
        currentReserves += roundAmmount;
        if(currentReserves > maxReserveSize)
        {
            currentReserves = maxReserveSize;
        }
    }
}
