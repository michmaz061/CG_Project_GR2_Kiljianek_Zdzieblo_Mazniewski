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

    private ShakeCamera shakeCamera;

    /// <summary>
    ///  Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
		animationScript = GetComponent<CharacterAnimation>();
        audioSource = GetComponent<AudioSource>();

		if(gameObject.CompareTag(Tags.ENEMY_TAG))
		{
			enemy_Movement = GetComponentInParent<EnemyMovement>();
		}

        shakeCamera = GameObject.FindWithTag(Tags.MAIN_CAMERA_TAG).GetComponent<ShakeCamera>();
	}

    /// <summary>
    ///  Turns on the left's arm attack point.
    /// </summary>
    void Left_Arm_Attack_Point_On()
    {
        left_Arm_Attack_Point.SetActive(true);
    }

    /// <summary>
    /// Turns off the left's arm attack point.
    /// </summary>
    void Left_Arm_Attack_Point_Off()
    {
        if (left_Arm_Attack_Point.activeInHierarchy)
        {
            left_Arm_Attack_Point.SetActive(false);
        }
    }
    
    /// <summary>
    /// Turns on the right's arm attack point.
    /// </summary>
    void Right_Arm_Attack_Point_On()
    {
        right_Arm_Attack_Point.SetActive(true);
    }

    /// <summary>
    /// Turns off the left's arm attack point.
    /// </summary>
    void Right_Arm_Attack_Point_Off()
    {
        if (right_Arm_Attack_Point.activeInHierarchy)
        {
            right_Arm_Attack_Point.SetActive(false);
        }
    }
    
    /// <summary>
    /// Turns on the left's leg attack point.
    /// </summary>
    void Left_Leg_Attack_Point_On()
    {
        left_Leg_Attack_Point.SetActive(true);
    }

    /// <summary>
    /// Turns off the left's leg attack point.
    /// </summary>
    void Left_Leg_Attack_Point_Off()
    {
        if (left_Leg_Attack_Point.activeInHierarchy)
        {
            left_Leg_Attack_Point.SetActive(false);
        }
    }
    
    /// <summary>
    /// Turns on the right's leg attack point.
    /// </summary>
    void Right_Leg_Attack_Point_On()
    {
        right_Leg_Attack_Point.SetActive(true);
    }

    /// <summary>
    /// Turns off the right's leg attack point.
    /// </summary>
    void Right_Leg_Attack_Point_Off()
    {
        if (right_Leg_Attack_Point.activeInHierarchy)
        {
            right_Leg_Attack_Point.SetActive(false);
        }
    }

    /// <summary>
    /// Tags left arm in animation.
    /// </summary>
    void TagLeft_Arm()
    {
        left_Arm_Attack_Point.tag = Tags.LEFT_ARM_TAG;
    }
    
    /// <summary>
    /// Untags left arm in animation.
    /// </summary>
    void UnTagLeft_Arm()
    {
        left_Arm_Attack_Point.tag = Tags.UNTAGGED_TAG;
    }
    
    /// <summary>
    /// Tags left leg in animation.
    /// </summary>
    void TagLeft_Leg()
    {
        left_Leg_Attack_Point.tag = Tags.LEFT_ARM_TAG;
    }
    
    /// <summary>
    /// Untags left leg in animation.
    /// </summary>
    void UnTagLeft_Leg()
    {
        left_Leg_Attack_Point.tag = Tags.UNTAGGED_TAG;
    }

    /// <summary>
    /// Starts the function for standing up.
    /// </summary>
    void Enemy_StandUp()
    {
        StartCoroutine(StandUpAfterTime());
    }

    /// <summary>
    /// Stands up the character.
    /// </summary>
    IEnumerator StandUpAfterTime()
    {
        yield return new WaitForSeconds(stand_Up_Timer);
        animationScript.StadUp();
    }

    /// <summary>
    /// Reference to the shake camera script.
    /// </summary>
    void ShakeCameraOnFall()
    {
        shakeCamera.ShouldShake = true;
    }

    /// <summary>
    /// Invoking the deactivate function on the enemy
    /// </summary>
    void CharacterDied()
    {
        Invoke("DeactivateGameObject", 2f);
    }

    /// <summary>
    /// Deactivates the game object(Enemy).
    /// </summary>
    void DeactivateGameObject()
    {
        EnemyManager.instance.SpawnEnemy();
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Plays the whoosh sound.
    /// </summary>
    public void Attack_FX_Sound()
    {
		audioSource.volume = 0.2f;
        audioSource.clip = whoosh_Sound;
		audioSource.Play();
    }

    /// <summary>
    /// Plays the dead sound.
    /// </summary>
    void CharacterDiedSound()
	{
		audioSource.volume = 1f;
		audioSource.clip = dead_Sound;
		audioSource.Play();
	}

    /// <summary>
    /// Plays the fall sound.
    /// </summary>
	void Enemy_KnockedDown()
	{
		audioSource.clip = fall_Sound;
		audioSource.Play();
	}

    /// <summary>
    /// Plays the ground hit sound.
    /// </summary>
	void Enemy_HitGround()
	{
		audioSource.clip = ground_Hit_Sound;
		audioSource.Play();
	}

    /// <summary>
    /// Disables the enemy's movement.
    /// </summary>
    void DisableMovement()
    {
            enemy_Movement.enabled = false;
			transform.parent.gameObject.layer = 0;
    }

    /// <summary>
    /// Enables the enemy's movement.
    /// </summary>
    void EnableMovement()
    {
            enemy_Movement.enabled = true;
			transform.parent.gameObject.layer = 10;
    }

}
