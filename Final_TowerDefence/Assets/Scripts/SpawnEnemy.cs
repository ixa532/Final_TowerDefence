using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float difficultyFactor = 0.75f;

    private int currentWaves = 1;
    private float timeLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftSpawn;
    private bool isSpawning = false;

    private void Update()
    {
        timeLastSpawn += Time.deltaTime; //Acumulao o tempo desde o �ltimo spawn, aumentando a variav�l com o tempo passado desde o �ltimo frame

        if (timeLastSpawn >= (1f / enemiesPerSecond)) //Verifica se o tempo desde o �ltimo spawn � maior ou igual ao intervalo necess�rio para o pr�ximo spawn
        {
            Debug.Log("Spawn Enemy"); //Se o tempo necess�rio passou, exibe uma mensagem no console indicando que um inimigo deve ser spawnado 
        }
    }
        private void StartWave()
        {
            isSpawning = true;
            enemiesLeftSpawn = EnemiesPerWave();
        }
}
