using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script used to manage player movement.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    private CharacterAnimation player_Anim;
    private Rigidbody myBody;
    public float walk_Speed = 3f;
    public float z_Speed = 1.5f;
    public bool isAlive = true;

    private float rotation_Y = -90f;
    private float rotation_Speed = 15f;


    /// <summary>
    /// Awake gets player body and his animations.
    /// </summary>
    void Awake()
    {
 
        myBody = GetComponent<Rigidbody>();
        player_Anim = GetComponentInChildren<CharacterAnimation>();
    }

    /// <summary>
    /// Update checks whether player is alive and if yes it fires off Rotate and Walk scripts.
    /// </summary>
    void Update()
    {
        if (isAlive)
        {
            RotatePlayer();
            AnimatePlayerWalk();
        }
    }

    /// <summary>
    /// In fixed update we detect if player moves.
    /// </summary>
    void FixedUpdate()
    {
        if (isAlive)
        {
            DetectMovement();
        }
    }

    /// <summary>
    /// A method used to rotate player object.
    /// </summary>
    void RotatePlayer()
    {
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0)
        {
            transform.rotation = Quaternion.Euler(0f, -Mathf.Abs(rotation_Y), 0f);
        }
        else if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0)
        {
            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(rotation_Y), 0f);
        }
    }

    /// <summary>
    /// Method used to detect if player moves.
    /// </summary>
    void DetectMovement()
    {
        myBody.velocity = new Vector3(
            Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (-walk_Speed),
            myBody.velocity.y,
            Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (-z_Speed));
    }

    /// <summary>
    /// Method used to animate player walking and sending this information to Player attack script.
    /// </summary>
    void AnimatePlayerWalk()
    {
        if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS)!=0 || Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0)
        {
            player_Anim.Walk(true);
            FindObjectOfType<PlayerAttack>().IsCharacterWalking(true);
        }
        else
        {
            player_Anim.Walk(false);
            FindObjectOfType<PlayerAttack>().IsCharacterWalking(false);
        }
    }

    /// <summary>
    /// Simple method setting isAlive bool.
    /// </summary>
    public void CharacterDied()
    {
        isAlive = false;
    }

}
