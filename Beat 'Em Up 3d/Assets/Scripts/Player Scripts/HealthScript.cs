using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script is used to keep track on character health and modify its value.
/// </summary>
public class HealthScript : MonoBehaviour
{
    public HealthScript instance;
    private HealthUI health_UI;
    public float health = 100f;
    public bool playerAlive = true;
    private CharacterAnimation animationScript;
    private EnemyMovement enemyMovement;
    public bool defend=false;
    private bool  characterDied;
    public bool is_Player;

    /// <summary>
    /// In awake we have updated Player health UI.
    /// </summary>
    void Awake()
    {
        animationScript = GetComponentInChildren<CharacterAnimation>();

        health_UI = GetComponent<HealthUI>();
        if (playerAlive == false)
        {
            GameObject.Find("Canvas").SendMessage("DeathOfPlayer");
        }
    }

    /// <summary>
    /// Simple function used in debugging.
    /// </summary>
    /// <param name="defendToCheck">Checks whether player is defending or not.</param>
    public void CheckIfDefend(bool defendToCheck)
    {
        defend = defendToCheck;
        if (defend)
            print("Defending");

        if (!defend)
            print("Stopped defending");
    }

    /// <summary>
    /// A method that applies damage to character health. It checks a set of things such as whether its player or enemy, if player is defending etc. To decide how much and if apply a damage to character. It also decides whether character dies or has enough health to keep going.
    /// </summary>
    /// <param name="damage">An float number of damage to be applied. </param>
    /// <param name="knockDown">A bool deciding whether character can be knocked down or not. </param>
    public void ApplyDamage(float damage, bool knockDown)
    {

        if (characterDied||defend)
            return;

            health -= damage;
        if (is_Player)
        {
            health_UI.DisplayHealth(health);
        }
        if(health <= 0f)
        {
            animationScript.Death();
            characterDied = true;

            if (is_Player)
            {
                FindObjectOfType<EndingScreen>().DeathOfPlayer();
                FindObjectOfType<PlayerMovement>().CharacterDied();
                GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<EnemyMovement>().enabled = false;
            }
            return;
        }
        if (!is_Player)
        {
            if (knockDown)
            {
                if (Random.Range(0, 2) > 0)
                {
                    animationScript.KnockDown();
                }
            }
            else
            {
                if (Random.Range(0, 3) > 1)
                {
                    animationScript.Hit();
                }
            }
        }
    }
}
