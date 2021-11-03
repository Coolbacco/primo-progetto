using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Rigidbody2D rb;
    public float mass = 1;

    public GameObject cube;

    public float runSpeed;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    float horizontalMove = 0f;
    float newMass = 1f;
    bool jump = false;
    bool crouch = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed / mass;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if(transform.localScale.x > 0)
            {
                Instantiate(cube, transform.position + transform.right, transform.rotation);
            }
            else if (transform.localScale.x < 0)
            {
                Instantiate(cube, transform.position - transform.right, transform.rotation);
            }
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, newMass);
        jump = false;
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier * mass) * Time.fixedDeltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier * mass) * Time.fixedDeltaTime;
        }
    }

    public void SetMass(float setNewMass)
    {
        mass = setNewMass;
        newMass = Scale(1, 2, 1, 1.5f, mass);
    }

    public float Scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue)
    {

        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

        return (NewValue);
    }
}
