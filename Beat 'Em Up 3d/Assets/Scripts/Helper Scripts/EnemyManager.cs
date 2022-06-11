using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    [SerializeField]
    private GameObject enemyPrefab;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
    }


    void Start()
    {
        SpawnEnemy();
    }
    // Update is called once per frame
    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
