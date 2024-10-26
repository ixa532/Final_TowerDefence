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
            isSpawning = true; //Define a vari�vel como verdadeira, indicando que a onda de inimigos est� em processo de spawn
            
            //Obt�m o n�mero total de inimigos para a onda atual chamando o m�todo EnemiesPerWave
            // armazena o resultado na vari�vel enemiesLeftSpawn
            enemiesLeftSpawn = EnemiesPerWave(); 
        }
    private int EnemiesPerWave()
    {
        //Calcula e retorna o n�mero de inimigos para a onda atual
        //Multiplica o n�mero base de inimigos pelo valor da onda atual elevado ao fator de dificuldade
        ////Mathf.RoundToInt esta garantindo que o numero de inimigos seja um valor inteiro 
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWaves, difficultyFactor));
    }
}
