using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region Fields & Properties
    private float RightLimit = 9.4f;
    private float LeftLimit = -9.4f;
    private float UpLimit = 6.6f;
    private float EnemySeconds = 4.0f;
    [SerializeField] private GameObject EnemyPrefab = null;
    [SerializeField] private GameObject[] PowerUps;
    private bool IsPlayerAlive = true;
    #endregion

    #region Methods
    private void Start()
    {
        
    }

    private void Update()
    {

    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnRoutineEnemy());
        StartCoroutine(SpawnRoutinePowerUp());
    }

        private IEnumerator SpawnRoutineEnemy()
    {
        while (IsPlayerAlive)
        {
            var enemyPosition = new Vector3(Random.Range(LeftLimit, RightLimit), UpLimit, 0);
            Instantiate(EnemyPrefab, enemyPosition, Quaternion.identity);
            yield return new WaitForSeconds(EnemySeconds);
        }
    }

    private IEnumerator SpawnRoutinePowerUp()
    {
        while (IsPlayerAlive)
        {
            var powerUpPosition = new Vector3(Random.Range(LeftLimit, RightLimit), UpLimit, 0);
            var randomPowerUp = Random.Range(0, 3);
            Instantiate(PowerUps[randomPowerUp], powerUpPosition, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(10, 16));
        }
    }

    public void PlayerDied()
    {
        IsPlayerAlive = false;
    }
    #endregion

}
