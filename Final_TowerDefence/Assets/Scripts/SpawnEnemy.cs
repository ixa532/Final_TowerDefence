using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [Header("References")] //// Header é utilizado para deixar mais organizado
    [SerializeField] private GameObject[] enemyPrefabs; //Array de prefabs de inimigos, que podem ser instanciados durante o jogo 

    [Header("Attributes")]//// Header é utilizado para deixar mais organizado
    [SerializeField] private int baseEnemies = 8; //Número base de inimigos que aparecem na primeira onda
    [SerializeField] private float enemiesPerSecond = 0.5f; //Taxa de spawn de inimigos por segundo
    [SerializeField] private float timeBetweenWaves = 5f;//Tempo em segundos do ínicio de uma onda a outra
    [SerializeField] private float difficultyFactor = 0.75f;//Ajusta a dificuldade,aumentando o número de inimigos em ondas subquentes  

    private int currentWaves = 1; //Contador que rastreia o número atual de ondas
    private float timeLastSpawn;//Acumula o tempo desde o último spawn de inimigo
    private int enemiesAlive;//Contador do número total de inimigos vivos no jogo
    private int enemiesLeftSpawn;//Contador do número de inimigos que ainda precisam ser spawnados na onda atual
    private bool isSpawning = false;//Indica se a onda de inimigos está em processo de spawn 

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
