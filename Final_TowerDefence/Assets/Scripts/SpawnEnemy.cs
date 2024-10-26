using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [Header("References")] //// Header � utilizado para deixar mais organizado
    [SerializeField] private GameObject[] enemyPrefabs; //Array de prefabs de inimigos, que podem ser instanciados durante o jogo 

    [Header("Attributes")]//// Header � utilizado para deixar mais organizado
    [SerializeField] private int baseEnemies = 8; //N�mero base de inimigos que aparecem na primeira onda
    [SerializeField] private float enemiesPerSecond = 0.5f; //Taxa de spawn de inimigos por segundo
    [SerializeField] private float timeBetweenWaves = 5f;//Tempo em segundos do �nicio de uma onda a outra
    [SerializeField] private float difficultyFactor = 0.75f;//Ajusta a dificuldade,aumentando o n�mero de inimigos em ondas subquentes  

    private int currentWaves = 1; //Contador que rastreia o n�mero atual de ondas
    private float timeLastSpawn;//Acumula o tempo desde o �ltimo spawn de inimigo
    private int enemiesAlive;//Contador do n�mero total de inimigos vivos no jogo
    private int enemiesLeftSpawn;//Contador do n�mero de inimigos que ainda precisam ser spawnados na onda atual
    private bool isSpawning = false;//Indica se a onda de inimigos est� em processo de spawn 

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
