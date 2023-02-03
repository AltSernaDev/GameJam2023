using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    CharacterController controller;
    [SerializeField] float speed = 2, runMultiplier = 2, gravity = 9.8f;
    [Range(0.5f, 5f)][SerializeField] float jumpHeigth = 1f;

    Vector3 normalDirection, gravityV, jump;
    float x, z, normalAngleD, normalAngleR, Jmagnitude, baseMovementModifier, angleModifier, movementModifierX, movementModifierZ, jumpModifier;
    bool isGrounded, jumping;

    Vector3 allMovement, baseMovement, gravityMovement;

    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
        allMovement = Vector3.zero;
        baseMovement = Vector3.zero;
        gravityMovement = Vector3.zero;
        jump = Vector3.zero;
    }
    private void Update()
    {
        baseMovement = BaseMovement();
        gravityMovement = GravityMovement();    
        jump = Jump();

        allMovement = (baseMovement * Running() * baseMovementModifier) + gravityMovement + jump;

        controller.Move(allMovement * Time.deltaTime);
    }

    Vector3 BaseMovement()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        baseMovement = Vector3.ClampMagnitude((transform.right * x + transform.forward * z), 1) * speed;

        return baseMovement;
    }

    float Running()
    {
        float multiplier = 1;
        if (Input.GetKey(KeyCode.LeftShift))
            multiplier = runMultiplier;
        else
            multiplier = 1;

        return multiplier;
    }

    Vector3 Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jump = Vector3.up * Mathf.Sqrt(jumpHeigth * 2 * gravity);
            jump.y -= jumpModifier;
            jumping = true;
            Invoke("NoJump", 0.2f);
        }
        else if (isGrounded)
        {
            jumpModifier = 0;
            jump = Vector3.zero;
        }

        return jump;
    }
    void NoJump()
    {
        jumping = false;
    }

    Vector3 GravityMovement()
    {
        RaycastHit hit;

        if (Physics.SphereCast(transform.position, 0.5f, Vector3.down, out hit, 0.6f) && !jumping)
        {            
            Physics.Raycast(transform.position, Vector3.down, out hit);

            normalDirection = hit.normal;

            normalAngleR = Mathf.Acos(Vector3.Dot(normalDirection.normalized, Vector3.up));
            normalAngleD = normalAngleR * Mathf.Rad2Deg;

            normalDirection.y = 0;

            if (normalAngleD < 70)
            {
                isGrounded = true;
                gravityMovement = Vector3.zero; 
            }
            else
                isGrounded = false;

            if (normalAngleD < 45)
            {
                baseMovementModifier = 1;

                //angleModifier = Vector3.Dot(normalDirection.normalized, baseMovement.normalized); //modificador correcto
                angleModifier = Vector3.Dot(normalDirection.normalized, baseMovement.normalized);
                if (angleModifier < 0) 
                {
                    normalAngleR = normalAngleR * angleModifier;
                    jumpModifier = (Mathf.Tan(normalAngleR) * baseMovement.magnitude * Running()) + 0.1f;
                }

                normalAngleR = normalAngleR * angleModifier;

                gravityV = Vector3.down * ((Mathf.Tan(normalAngleR) * baseMovement.magnitude * Running()) + 0.1f);

                gravityMovement = gravityV;
            }
            else if (normalAngleD >= 45 && normalAngleD < 70)
            {
                baseMovementModifier = 0.5f;
                Jmagnitude = Mathf.Sin(normalAngleR) * gravity;
                normalDirection = normalDirection.normalized * (Mathf.Cos(normalAngleR) * Jmagnitude);

                gravityV = Vector3.down * (Mathf.Sin(normalAngleR) * Jmagnitude);
                //
                angleModifier = Vector3.Dot(normalDirection.normalized, baseMovement.normalized);
                if (angleModifier < 0)
                {
                    normalAngleR = normalAngleR * angleModifier;
                    jumpModifier = (Mathf.Tan(normalAngleR) * baseMovement.magnitude * Running()) + 0.1f;
                }

                normalAngleR = normalAngleR * angleModifier;

                gravityV = gravityV + Vector3.down * ((Mathf.Tan(normalAngleR) * baseMovement.magnitude * Running()) + 0.1f);
                //
                gravityMovement = normalDirection + gravityV;
            }
            else if (normalAngleD >= 70)
            {
                baseMovementModifier = 1f;
                Jmagnitude = Mathf.Sin(normalAngleR) * gravity;

                gravityV = Vector3.down * (Mathf.Sin(normalAngleR) * Jmagnitude);

                normalDirection = normalDirection.normalized * (Mathf.Cos(normalAngleR) * Jmagnitude);

                gravityMovement += (normalDirection + gravityV) * Time.deltaTime;               
            }
        }
        else
        {
            baseMovementModifier = 1;
            isGrounded = false;
            normalDirection = Vector3.zero;
            gravityMovement += Vector3.down * gravity * Time.deltaTime;
        }

        return gravityMovement;
    }
}

