using System.Collections;

using System.Collections.Generic;

using UnityEngine;


/// <summary>
/// A simple manager for animation tags to simplify work for scripts.
/// </summary>
public class AnimationTags

{



    public const string MOVEMENT = "Movement";



    public const string PUNCH_1_TRIGGER = "Punch1";

    public const string PUNCH_2_TRIGGER = "Punch2";

    public const string PUNCH_3_TRIGGER = "Punch3";



    public const string KICK_1_TRIGGER = "Kick1";

    public const string KICK_2_TRIGGER = "Kick2";



    public const string ATTACK_1_TRIGGER = "Attack1";

    public const string ATTACK_2_TRIGGER = "Attack2";

    public const string ATTACK_3_TRIGGER = "Attack3";



    public const string IDLE_ANIMATION = "Idle";

    public const string DEFEND = "Defend";

    public const string KNOCK_DOWN_TRIGGER = "KnockDown";

    public const string STAND_UP_TRIGGER = "StandUp";

    public const string HIT_TRIGGER = "Hit";

    public const string DEATH_TRIGGER = "Death";

    public const string DEFENDENEMY_TRIGGER = "DefendEnemy";

}


/// <summary>
/// A simple manager for axis tags to simplify work for scripts.
/// </summary>
public class Axis
{

    public const string HORIZONTAL_AXIS = "Horizontal";

    public const string VERTICAL_AXIS = "Vertical";

}


/// <summary>
/// A simple manager for tags to simplify work for scripts.
/// </summary>
public class Tags
{

    public const string GROUND_TAG = "Ground";

    public const string PLAYER_TAG = "Player";

    public const string ENEMY_TAG = "Enemy";



    public const string LEFT_ARM_TAG = "LeftArm";

    public const string LEFT_LEG_TAG = "LeftLeg";

    public const string UNTAGGED_TAG = "Untagged";

    public const string MAIN_CAMERA_TAG = "MainCamera";

    public const string HEALTH_UI = "HealthUI";

}