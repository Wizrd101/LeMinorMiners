using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IBMGAI : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        
    }
}
