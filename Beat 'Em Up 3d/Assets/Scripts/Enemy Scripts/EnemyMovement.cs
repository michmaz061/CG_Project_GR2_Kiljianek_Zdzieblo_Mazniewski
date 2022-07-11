using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Script used to define the movement of an enemy.
/// </summary>
public class EnemyMovement : MonoBehaviour
{

    private CharacterAnimation enemyAnim;
    private Rigidbody myBody;

    
    public float speed = 5f;

    private Transform playerTarget;
    public float attack_Distance = 1f;
    public float chase_Player_After_Attack = 1f;

    private float current_Attack_Time;
    private float default_Attack_Time = 2f;

    private bool followPlayer, attackPlayer;

    /// <summary>
    /// While awake it gets animation for Enemy and its body, also a target (player).
    /// </summary>
    void Awake()
    {
        enemyAnim = GetComponentInChildren<CharacterAnimation>();
        myBody = GetComponent<Rigidbody>();

        playerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }

    /// <summary>
    /// In start we define whether enemy wants to follow player and set the default attack time.
    /// </summary>
    void Start()
    {
        followPlayer = true;
        current_Attack_Time = default_Attack_Time;
    }

    /// <summary>
    /// In update we run Attack script.
    /// </summary>
    void Update()
    {
        Attack();
    }

    /// <summary>
    /// In fixed update we run Follow target script.
    /// </summary>
    void FixedUpdate()
    {
        FollowTarget();
    }

    /// <summary>
    /// In this method we check whether we want to follow player (its set in start) and calculate follow movement actions. When enemy gets close enough he will initate attack.
    /// </summary>
    void FollowTarget()
    {
        if (!followPlayer)
            return;

        if(Vector3.Distance(transform.position, playerTarget.position) > attack_Distance)
        {
            transform.LookAt(playerTarget);
            myBody.velocity = transform.forward * speed;

            if(myBody.velocity.sqrMagnitude != 0)
            {
                enemyAnim.Walk(true);
            }
        }
        else if(Vector3.Distance(transform.position, playerTarget.position) <= attack_Distance)
        {
            myBody.velocity = Vector3.zero;
            enemyAnim.Walk(false);
            followPlayer = false;
            attackPlayer = true;
        }
    }

    /// <summary>
    /// In attack, we chceck whether movement script allows enemy to attack. If yes it uses timer to ensure that enemy will attack in intervals.
    /// </summary>
    void Attack()
    {
        if (!attackPlayer)
            return;

        current_Attack_Time += Time.deltaTime;

        if(current_Attack_Time > default_Attack_Time)
        {
            enemyAnim.EnemyAttack(Random.Range(0, 3));
            current_Attack_Time = 0f;
        }
        if (Vector3.Distance(transform.position, playerTarget.position) > attack_Distance + chase_Player_After_Attack)
        {
            attackPlayer = false;
            followPlayer = true;
        }
    }
}
