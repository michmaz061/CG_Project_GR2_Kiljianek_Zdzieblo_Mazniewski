using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    // Start is called before the first frame update
    public HealthScript instance;
    private HealthUI health_UI;
    public float health = 100f;
    public bool playerAlive = true;
    private CharacterAnimation animationScript;
    private EnemyMovement enemyMovement;

    private bool  characterDied;
    public bool is_Player;

    void Awake()
    {
        animationScript = GetComponentInChildren<CharacterAnimation>();

        health_UI = GetComponent<HealthUI>();
        if (playerAlive == false)
        {
            GameObject.Find("Canvas").SendMessage("DeathOfPlayer");
        }
    }

    public void ApplyDamage(float damage, bool knockDown)
    {
        if (characterDied)
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
                EndingScreen.instance.DeathOfPlayer();
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
