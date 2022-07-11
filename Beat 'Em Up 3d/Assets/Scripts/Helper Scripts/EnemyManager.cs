using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// In this script, we manage the enemy spawner.
/// </summary>

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public int timeDelay=2;
    public float damage = 10f;
    [SerializeField]
    private GameObject enemyPrefab;
    
    /// <summary>
    /// Awake method spawns enemies where their predecessor is dead.
    /// </summary>
    void Awake()
    {
            if (instance == null)
            {
                instance = this;
        }
    }

    /// <summary>
    /// In Start we can set how much of a delay we want to have before first spawn of an enemy.
    /// </summary>
    void Start()
    {
            Invoke("SpawnEnemy", timeDelay);
            
    }
    
    /// <summary>
    /// In this method we spawn enemy itself.
    /// </summary>
    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        ScoreManager.instance.AddPoint();
    }
}
