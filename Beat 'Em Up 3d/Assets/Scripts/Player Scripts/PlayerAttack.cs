using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ComboState
{
    NONE,
    PUNCH_1,
    PUNCH_2,
    PUNCH_3,
    KICK_1,
    KICK_2
}

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

    void Start()
    {
        current_Combo_Timer = default_Combo_Timer;
        current_Combo_State = ComboState.NONE;
    }

    // Update is called once per frame
    void Update()
    {

            if (Input.GetKey(KeyCode.C)&&current_Combo_Timer > 0f&&!isWalking&& !defendCheck)
            {

                //print("Defending");
                player_Anim.Defend(true);
                defendToPass = true;
            //FindObjectOfType<HealthScript>().CheckIfDefend(true);

        }
            else
            {
                //print("Stopped defending");
                player_Anim.Defend(false);
                defendToPass = false;
            //FindObjectOfType<HealthScript>().CheckIfDefend(false);
        }
        ComboAttacks();
        ResetComboState();
        //ResetDefendState();

    }

    public bool returnDefend()
    {
        return defendToPass;
    }

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



    public void IsCharacterWalking(bool currentState)
    {
        isWalking = currentState;
    }
}
