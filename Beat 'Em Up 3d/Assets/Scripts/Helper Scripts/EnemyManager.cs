using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public int timeDelay=2;
    [SerializeField]
    private GameObject enemyPrefab;
    // Start is called before the first frame update
    void Awake()
    {
            if (instance == null)
            {
                instance = this;
        }
    }


    void Start()
    {
            Invoke("SpawnEnemy", timeDelay);
    }
    // Update is called once per frame
    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        ScoreManager.instance.AddPoint();
    }
}
