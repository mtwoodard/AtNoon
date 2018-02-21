using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Controllers/Player Controller")]
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float speed = 7.0f;
    public float jumpStrength = 5.0f;
    public float terminalVelocity = 52.0f;
    public bool movementLock = false;

    Vector3 movement = Vector3.zero;
    Vector3 gravity = Vector3.zero;
    CharacterController player;

    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!movementLock)
        {

            movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed;
            movement = transform.TransformDirection(movement);
            if (!player.isGrounded)
            {
                gravity += Physics.gravity * Time.deltaTime;
                gravity.y = Mathf.Max(gravity.y, -terminalVelocity);
            }
            else
            {
                gravity = Vector3.zero;
                if (jump)
                    gravity.y = jumpStrength;
            }

            movement += gravity;
            player.Move(movement * Time.deltaTime);
        }
        else
        {
            movement = Vector3.zero;
            if (!player.isGrounded)
            {
                gravity += Physics.gravity * Time.deltaTime;
                gravity.y = Mathf.Max(gravity.y, -terminalVelocity);
            }
            else
            {
                gravity = Vector3.zero;
                if (jump)
                    gravity.y = jumpStrength;
            }
            movement += gravity;
            player.Move(movement * Time.deltaTime);
        }
    }



    bool jump
    {
        get
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
    }

    public bool isGrounded
    {
        get
        {
            return player.isGrounded;
        }
    }
}