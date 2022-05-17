using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject left_Arm_Attack_Point, right_Arm_Attack_Point, left_Leg_Attack_Point, right_Leg_Attack_Point;

	public float stand_Up_Timer = 2f;	

	private CharacterAnimation animationScript;

	private AudioSource audioSource;

	[SerializeField]
	public AudioClip whoosh_Sound, fall_Sound, ground_Hit_Sound, dead_Sound;

	private EnemyMovement enemy_Movement;

    void Awake()
    {
		animationScript = GetComponent<CharacterAnimation>();
        audioSource = GetComponent<AudioSource>();

		if(gameObject.CompareTag(Tags.ENEMY_TAG))
		{
			enemy_Movement = GetComponentInParent<EnemyMovement>();
		}
	}

    void Left_Arm_Attack_Point_On()
    {
        left_Arm_Attack_Point.SetActive(true);
    }

    void Left_Arm_Attack_Point_Off()
    {
        if (left_Arm_Attack_Point.activeInHierarchy)
        {
            left_Arm_Attack_Point.SetActive(false);
        }
    }
    
    void Right_Arm_Attack_Point_On()
    {
        right_Arm_Attack_Point.SetActive(true);
    }

    void Right_Arm_Attack_Point_Off()
    {
        if (right_Arm_Attack_Point.activeInHierarchy)
        {
            right_Arm_Attack_Point.SetActive(false);
        }
    }
    
    void Left_Leg_Attack_Point_On()
    {
        left_Leg_Attack_Point.SetActive(true);
    }

    void Left_Leg_Attack_Point_Off()
    {
        if (left_Leg_Attack_Point.activeInHierarchy)
        {
            left_Leg_Attack_Point.SetActive(false);
        }
    }
    
    void Right_Leg_Attack_Point_On()
    {
        right_Leg_Attack_Point.SetActive(true);
    }

    void Right_Leg_Attack_Point_Off()
    {
        if (right_Leg_Attack_Point.activeInHierarchy)
        {
            right_Leg_Attack_Point.SetActive(false);
        }
    }





	public void Attack_FX_Sound()
    {
		audioSource.volume = 0.2f;
        audioSource.clip = whoosh_Sound;
		audioSource.Play();
    }

    void CharacterDiedSound()
	{
		audioSource.volume = 1f;
		audioSource.clip = dead_Sound;
		audioSource.Play();
	}

	void Enemy_KnockedDown()
	{
		audioSource.clip = fall_Sound;
		audioSource.Play();
	}

	void Enemy_HitGround()
	{
		audioSource.clip = ground_Hit_Sound;
		audioSource.Play();
	}

    void DisableMovement()
    {
            enemy_Movement.enabled = false;
			transform.parent.gameObject.layer = 0;
    }

    void EnableMovement()
    {
            enemy_Movement.enabled = true;
			transform.parent.gameObject.layer = 10;
    }

}
