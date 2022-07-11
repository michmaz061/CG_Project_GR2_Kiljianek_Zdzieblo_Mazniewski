using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A list for following our combos.
/// </summary>
public enum ComboState
{
    NONE,
    PUNCH_1,
    PUNCH_2,
    PUNCH_3,
    KICK_1,
    KICK_2
}

/// <summary>
/// In this script we have defined player attacks.
/// </summary>
public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterAnimation player_Anim;

    private bool activateTimerToReset;
    private bool defendCheck=false;

    private float default_Combo_Timer = 0.4f;
    private float current_Combo_Timer;


    private ComboState current_Combo_State;

    private bool defendToPass= false;
    private bool isWalking;
    void Awake()
    {
        player_Anim = GetComponentInChildren<CharacterAnimation>();
    }

    /// <summary>
    /// In start we define Combo timers used to keep track on combos.
    /// </summary>
    void Start()
    {
        current_Combo_Timer = default_Combo_Timer;
        current_Combo_State = ComboState.NONE;
    }

    /// <summary>
    /// In update we check whether player wants to and can defend. Also we check combo states.
    /// </summary>
    void Update()
    {

            
            if (Input.GetKey(KeyCode.C)&&current_Combo_Timer > 0f&&!isWalking&& !defendCheck)
            {

                player_Anim.Defend(true);
                defendToPass = true;

        }
            else
            {
                player_Anim.Defend(false);
                defendToPass = false;
        }
        ComboAttacks();
        ResetComboState();

    }

    /// <summary>
    /// Simple function for returning bool whether player is defending or not.
    /// </summary>
    /// <returns>A bool telling if defend is used.</returns>
    public bool returnDefend()
    {
        return defendToPass;
    }

    /// <summary>
    /// A method that checks if player is walking, and if not if he is performing combos. It uses time to reset combo state.
    /// </summary>
    void ComboAttacks()
    {
        if (!isWalking)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                defendCheck = true;
                if (current_Combo_State == ComboState.PUNCH_3 || current_Combo_State == ComboState.KICK_1 || current_Combo_State == ComboState.KICK_2)
                    return;
                current_Combo_State++;
                activateTimerToReset = true;
                current_Combo_Timer = default_Combo_Timer;

                if (current_Combo_State == ComboState.PUNCH_1)
                {
                    player_Anim.Punch_1();
                }
                if (current_Combo_State == ComboState.PUNCH_2)
                {
                    player_Anim.Punch_2();
                }
                if (current_Combo_State == ComboState.PUNCH_3)
                {
                    player_Anim.Punch_3();
                }

            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                defendCheck = true;
                if (current_Combo_State == ComboState.PUNCH_3 || current_Combo_State == ComboState.KICK_2)
                    return;
                if (current_Combo_State == ComboState.PUNCH_1 || current_Combo_State == ComboState.PUNCH_2 || current_Combo_State == ComboState.NONE)
                {
                    current_Combo_State = ComboState.KICK_1;
                }
                else if (current_Combo_State == ComboState.KICK_1)
                {
                    current_Combo_State++;
                }
                activateTimerToReset = true;
                current_Combo_Timer = default_Combo_Timer;

                if (current_Combo_State == ComboState.KICK_1)
                    player_Anim.Kick_1();
                if (current_Combo_State == ComboState.KICK_2)
                    player_Anim.Kick_2();
            }
        }
    }

    /// <summary>
    /// Method that resets timer and combo state.
    /// </summary>
    void ResetComboState()
    {
        if (activateTimerToReset)
        {
            current_Combo_Timer -= Time.deltaTime;
            if (current_Combo_Timer <= 0f)
            {
                current_Combo_State = ComboState.NONE;
                activateTimerToReset = false;
                defendCheck = false;
                current_Combo_Timer = default_Combo_Timer;
            }
        }
    }


    /// <summary>
    /// A method used in another script to inform us whether character is walking or not.
    /// </summary>
    /// <param name="currentState">Bool telling us whether it is true or not for player walking</param>
    public void IsCharacterWalking(bool currentState)
    {
        isWalking = currentState;
    }
}
