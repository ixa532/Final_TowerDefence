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
        timeLastSpawn += Time.deltaTime; //Acumulao o tempo desde o último spawn, aumentando a variavél com o tempo passado desde o último frame

        if (timeLastSpawn >= (1f / enemiesPerSecond)) //Verifica se o tempo desde o último spawn é maior ou igual ao intervalo necessário para o próximo spawn
        {
            Debug.Log("Spawn Enemy"); //Se o tempo necessário passou, exibe uma mensagem no console indicando que um inimigo deve ser spawnado 
        }
    }
        private void StartWave()
        {
            isSpawning = true; //Define a variável como verdadeira, indicando que a onda de inimigos está em processo de spawn
            
            //Obtém o número total de inimigos para a onda atual chamando o método EnemiesPerWave
            // armazena o resultado na variável enemiesLeftSpawn
            enemiesLeftSpawn = EnemiesPerWave(); 
        }
    private int EnemiesPerWave()
    {
        //Calcula e retorna o número de inimigos para a onda atual
        //Multiplica o número base de inimigos pelo valor da onda atual elevado ao fator de dificuldade
        ////Mathf.RoundToInt esta garantindo que o numero de inimigos seja um valor inteiro 
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWaves, difficultyFactor));
    }
}
