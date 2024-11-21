using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    [SerializeField] private Rigidbody2D rb; //Referencia ao Rigidbody2D do objeto, que configura no inspector para o controle de movimento

    [SerializeField] private float moveSpeed = 2f;//Velocidade de movimento do objeto, configurável no Inspector

    private Transform alvo; //Alvo atual para o qual o objeto irá se mover
    private int caminhoIndex = 0;//Índice do ponto atual no caminho, que inicia como 0
    private float baseSpeed;

    private void Awake()// método usado para obter e armazenar a referência ao componente Rigidbody2D do objeto
    {
        rb = GetComponent<Rigidbody2D>(); //Obtém o componente Rigidbody2D do objeto que o script está anexado e o armazena na variável 'rb'.

    }

    private void Start() //método chamado para que o script seja iniciado
    {
        baseSpeed = moveSpeed;
        alvo = LevelManager.instance.caminho[caminhoIndex];//Define o alvo inicial como o primeiro ponto no caminho, que é obtido pelo LevelManager 
    }
    private void Update() //Método chamado uma vez por frame
    {
        if (Vector2.Distance(alvo.position, transform.position) <= 0.1f)//Verifica a distância entre o objeto e o alvo atual; se é menor ou igual a 0.1; considera que chegou ao alvo 
        {
            caminhoIndex++;//Avança para o próximo ponto no caminho

            if (caminhoIndex == LevelManager.instance.caminho.Length)//Se o índice alcançar o fim do caminho, o objeto se destrói
            {
                SpawnEnemy.onEnemyDestroy.Invoke();
                Destroy(gameObject);//Destroi o objeto ao final do caminho
                return;//Interrompe a execução para evitar erros ao tentar acessar alvo que não existe
            }
            else
            {
                alvo = LevelManager.instance.caminho[caminhoIndex];//Atualiza o alvo para o próximo ponto no caminho

            }
        }
    }
    private void FixedUpdate()//método chamado em intervalos fixos e usado para "física"
    {
        Vector2 direction = (alvo.position - transform.position).normalized; //Calcula a direção normalizada do objeto em direção ao alvo atual //normalized permite que a velocidade de moveSpeed seja aplicada de forma que mova o objeto na direção do alvo na velocidade, sem alterar a direção do movimento; e converte o vetor em um vetor unitário ou seja Comprimento 1 
        rb.velocity = direction * moveSpeed;//Define a velocidade do Rigidbody do objeto, movendo para a direção calculada
    }

    public void UpdateSpeed(float newSpeed)
    {
        moveSpeed = newSpeed; //Atualizaa velocidade do inimigo
    }
    public void ResetSpeed()
    {
        moveSpeed = baseSpeed;
    }
}
