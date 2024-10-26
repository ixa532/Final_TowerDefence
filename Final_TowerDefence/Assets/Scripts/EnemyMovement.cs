using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")] // Header é utilizado para deixar mais organizado, para separar as funções
    [SerializeField] private Rigidbody2D rb; //Referencia ao Rigidbody2D do objeto, que configura no inspector para o controle de movimento

    [Header("Attributes")] //Header é utilizado para deixar mais organizado, para separar as funções
    [SerializeField] private float moveSpeed = 2f;//Velocidade de movimento do objeto, configurável no Inspector

    private Transform alvo; //Alvo atual para o qual o objeto irá se mover
    private int caminhoIndex = 0;//Índice do ponto atual no caminho, que inicia como 0


}
