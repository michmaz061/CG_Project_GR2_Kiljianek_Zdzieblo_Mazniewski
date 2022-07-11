using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// In this script we go deeper in Attack behaviour, such as detecking collisions and applying damage.
/// </summary>
public class AttackUniversal : MonoBehaviour
{

    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damage = 10f;

    public bool is_Player, is_Enemy;

    public GameObject hit_FX_Prefab;

    /// <summary>
    /// This method is used to detect collisions. Also differentiate between enemy, unguarded player and player to pass information to another script whether to apply damage and how much.
    /// </summary>
    void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);

        if (hit.Length > 0)
        {
            if (is_Player)
            {
                Vector3 hitFX_Pos = hit[0].transform.position;
                hitFX_Pos.y += 1.3f;

                if (hit[0].transform.forward.x > 0)
                {
                    hitFX_Pos.x += 0.3f;
                }
                else if (hit[0].transform.forward.x < 0)
                {
                    hitFX_Pos.x -= 0.3f;
                }

                Instantiate(hit_FX_Prefab, hitFX_Pos, Quaternion.identity);

                if (gameObject.CompareTag(Tags.LEFT_ARM_TAG) || gameObject.CompareTag(Tags.LEFT_LEG_TAG))
                {
                    
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage,true);
                    
                    
                }
                else
                {
                    
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
                   
                }
                
            }
            if (is_Enemy)
            {
                hit[0].GetComponent<HealthScript>().CheckIfDefend(FindObjectOfType<PlayerAttack>().returnDefend());
                hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
            }

                gameObject.SetActive(false);
        }
    }


    /// <summary>
    /// Update is used to constantly deteck collisions.
    /// </summary>
    void Update()
    {
        DetectCollision();
    }
}
