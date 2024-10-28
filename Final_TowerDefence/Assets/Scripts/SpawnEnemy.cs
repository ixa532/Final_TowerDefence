using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnEnemy : MonoBehaviour
{
   
    [SerializeField] private GameObject[] enemyPrefabs; //Array de prefabs de inimigos, que podem ser instanciados durante o jogo 

    [SerializeField] private int baseEnemies = 8; //N�mero base de inimigos que aparecem na primeira onda
    [SerializeField] private float enemiesPerSecond = 0.5f; //Taxa de spawn de inimigos por segundo
    [SerializeField] private float timeBetweenWaves = 5f;//Tempo em segundos do �nicio de uma onda a outra
    [SerializeField] private float difficultyFactor = 0.75f;//Ajusta a dificuldade,aumentando o n�mero de inimigos em ondas subquentes  

    public static UnityEvent onEnemyDestroy = new UnityEvent() ;//Declara uma variavel de evento est�tica para notificar quando um inimigo � destru�do

    private int currentWaves = 1; //Contador que rastreia o n�mero atual de ondas
    private float timeLastSpawn;//Acumula o tempo desde o �ltimo spawn de inimigo
    private int enemiesAlive;//Contador do n�mero total de inimigos vivos no jogo
    private int enemiesLeftSpawn;//Contador do n�mero de inimigos que ainda precisam ser spawnados na onda atual
    private bool isSpawning = false;//Indica se a onda de inimigos est� em processo de spawn 

    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    private void Start()
    {
        StartWave(); //Come�ar as ondas
    }

    private void Update()
    {
        timeLastSpawn += Time.deltaTime; //Acumulao o tempo desde o �ltimo spawn, aumentando a variav�l com o tempo passado desde o �ltimo frame

        //Verifica se o tempo desde o �ltimo spawn � suficiente para spawnar um novo inimigo
        //e se ainda h� inimigos restantes para spawnar na onda atual 
        if (timeLastSpawn >= (1f / enemiesPerSecond)&& enemiesLeftSpawn > 0) 
        {
            SpawnEnemies(); //Chama o m�todo SpawnEnemies, ou seja, m�todo que realiza o spawn dos inimigos
            enemiesLeftSpawn--; //Diminui o contador de inimigos que faltam spawnar na onda atual
            enemiesAlive++;//Incrementa o contador de inimigos atualmente vivos no jogo
            timeLastSpawn = 0f;//Reinicia o temporizador para controlar o intervalor de tempo at� o pr�ximo spawn 
        }
    }

    private void EnemyDestroyed()
    { 
        enemiesAlive--;
    }

        private void StartWave()
        {
            isSpawning = true; //Define a vari�vel como verdadeira, indicando que a onda de inimigos est� em processo de spawn
            
            //Obt�m o n�mero total de inimigos para a onda atual chamando o m�todo EnemiesPerWave
            // armazena o resultado na vari�vel enemiesLeftSpawn
            enemiesLeftSpawn = EnemiesPerWave(); 
        }

    private void SpawnEnemies()
    {
        // Seleciona um inimigo aleat�rio do array enemyPrefabs
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject prefabToSpawn = enemyPrefabs[randomIndex];

        //Instancia o inimigo escolhido na posi��o inicial definida no LevelManager
        Instantiate(prefabToSpawn, LevelManager.instance.startPoint.position, Quaternion.identity);
    }


    private int EnemiesPerWave()
    {
        //Calcula e retorna o n�mero de inimigos para a onda atual
        //Multiplica o n�mero base de inimigos pelo valor da onda atual elevado ao fator de dificuldade
        ////Mathf.RoundToInt esta garantindo que o numero de inimigos seja um valor inteiro 
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWaves, difficultyFactor));
    }
}
