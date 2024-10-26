using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")] // Header � utilizado para deixar mais organizado, para separar as fun��es
    [SerializeField] private Rigidbody2D rb; //Referencia ao Rigidbody2D do objeto, que configura no inspector para o controle de movimento

    [Header("Attributes")] //Header � utilizado para deixar mais organizado, para separar as fun��es
    [SerializeField] private float moveSpeed = 2f;//Velocidade de movimento do objeto, configur�vel no Inspector

    private Transform alvo; //Alvo atual para o qual o objeto ir� se mover
    private int caminhoIndex = 0;//�ndice do ponto atual no caminho, que inicia como 0


}
