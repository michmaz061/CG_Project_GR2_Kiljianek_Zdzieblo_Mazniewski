using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A script used to work with Unity animation.
/// </summary>
public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;
    
    /// <summary>
    /// While awake it constantly gets character to animate.
    /// </summary>
    void Awake()
    {
        anim = GetComponent<Animator>();   
    }

    /// <summary>
    /// Sets an appropriate flag for animation.
    /// </summary>
    /// <param name="move">Bool used to set animation to walk.</param>
    public void Walk(bool move)
    {
        anim.SetBool(AnimationTags.MOVEMENT, move);
    }

    /// <summary>
    /// Sets an appropriate flag for animation.
    /// </summary>
    /// <param name="defend">Bool used to set animation to defend.</param>
    public void Defend(bool defend)
    {
        anim.SetBool(AnimationTags.DEFEND, defend);
    }

    /// <summary>
    /// Sets an appropriate punch trigger for animation.
    /// </summary>
    public void Punch_1()
    {
        anim.SetTrigger(AnimationTags.PUNCH_1_TRIGGER);
    }

    /// <summary>
    /// Sets an appropriate punch2 trigger for animation.
    /// </summary>
    public void Punch_2()
    {
        anim.SetTrigger(AnimationTags.PUNCH_2_TRIGGER);
    }

    /// <summary>
    /// Sets an appropriate punch3 trigger for animation.
    /// </summary>
    public void Punch_3()
    {
        anim.SetTrigger(AnimationTags.PUNCH_3_TRIGGER);
    }

    /// <summary>
    /// Sets an appropriate kick trigger for animation.
    /// </summary>
    public void Kick_1()
    {
        anim.SetTrigger(AnimationTags.KICK_1_TRIGGER);
    }

    /// <summary>
    /// Sets an appropriate kick2 trigger for animation.
    /// </summary>
    public void Kick_2()
    {
        anim.SetTrigger(AnimationTags.KICK_2_TRIGGER);
    }

    /// <summary>
    /// Depending on attack, it sets an animation trigger.
    /// </summary>
    /// <param name="attack">A number of attack to animate.</param>
    public void EnemyAttack(int attack)
    {
        if(attack == 0)
        {
            anim.SetTrigger(AnimationTags.ATTACK_1_TRIGGER);
        }

        if (attack == 1)
        {
            anim.SetTrigger(AnimationTags.ATTACK_2_TRIGGER);
        }

        if (attack == 2)
        {
            anim.SetTrigger(AnimationTags.ATTACK_3_TRIGGER);
        }
    }

    /// <summary>
    /// Sets an appropriate idle flag for animation.
    /// </summary>
    public void Play_IdleAnimation()
    {
        anim.Play(AnimationTags.IDLE_ANIMATION);
    }

    /// <summary>
    /// Sets an appropriate knockdown trigger for animation.
    /// </summary>
    public void KnockDown()
    {
        anim.SetTrigger(AnimationTags.KNOCK_DOWN_TRIGGER);
    }

    /// <summary>
    /// Sets an appropriate Stand up trigger for animation.
    /// </summary>
    public void StadUp()
    {
        anim.SetTrigger(AnimationTags.STAND_UP_TRIGGER);
    }

    /// <summary>
    /// Sets an appropriate hit trigger for animation.
    /// </summary>
    public void Hit()
    {
        anim.SetTrigger(AnimationTags.HIT_TRIGGER);
    }

    /// <summary>
    /// Sets an appropriate death trigger for animation.
    /// </summary>
    public void Death()
    {
        anim.SetTrigger(AnimationTags.DEATH_TRIGGER);
    }
}
