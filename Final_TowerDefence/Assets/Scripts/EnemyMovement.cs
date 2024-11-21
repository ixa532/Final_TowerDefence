using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    [SerializeField] private Rigidbody2D rb; //Referencia ao Rigidbody2D do objeto, que configura no inspector para o controle de movimento

    [SerializeField] private float moveSpeed = 2f;//Velocidade de movimento do objeto, configur�vel no Inspector

    private Transform alvo; //Alvo atual para o qual o objeto ir� se mover
    private int caminhoIndex = 0;//�ndice do ponto atual no caminho, que inicia como 0
    private float baseSpeed;

    private void Awake()// m�todo usado para obter e armazenar a refer�ncia ao componente Rigidbody2D do objeto
    {
        rb = GetComponent<Rigidbody2D>(); //Obt�m o componente Rigidbody2D do objeto que o script est� anexado e o armazena na vari�vel 'rb'.

    }

    private void Start() //m�todo chamado para que o script seja iniciado
    {
        baseSpeed = moveSpeed;
        alvo = LevelManager.instance.caminho[caminhoIndex];//Define o alvo inicial como o primeiro ponto no caminho, que � obtido pelo LevelManager 
    }
    private void Update() //M�todo chamado uma vez por frame
    {
        if (Vector2.Distance(alvo.position, transform.position) <= 0.1f)//Verifica a dist�ncia entre o objeto e o alvo atual; se � menor ou igual a 0.1; considera que chegou ao alvo 
        {
            caminhoIndex++;//Avan�a para o pr�ximo ponto no caminho

            if (caminhoIndex == LevelManager.instance.caminho.Length)//Se o �ndice alcan�ar o fim do caminho, o objeto se destr�i
            {
                SpawnEnemy.onEnemyDestroy.Invoke();
                Destroy(gameObject);//Destroi o objeto ao final do caminho
                return;//Interrompe a execu��o para evitar erros ao tentar acessar alvo que n�o existe
            }
            else
            {
                alvo = LevelManager.instance.caminho[caminhoIndex];//Atualiza o alvo para o pr�ximo ponto no caminho

            }
        }
    }
    private void FixedUpdate()//m�todo chamado em intervalos fixos e usado para "f�sica"
    {
        Vector2 direction = (alvo.position - transform.position).normalized; //Calcula a dire��o normalizada do objeto em dire��o ao alvo atual //normalized permite que a velocidade de moveSpeed seja aplicada de forma que mova o objeto na dire��o do alvo na velocidade, sem alterar a dire��o do movimento; e converte o vetor em um vetor unit�rio ou seja Comprimento 1 
        rb.velocity = direction * moveSpeed;//Define a velocidade do Rigidbody do objeto, movendo para a dire��o calculada
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
