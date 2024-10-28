using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform alvo; //Referencia ao alvo que a bala deve atingir

    [SerializeField] private float bulletSpeed = 5f; //Velocidade da bala, pode ser ajustada através do inspector
    [SerializeField] private Rigidbody rb;//Referencia ao componente Rigidbody da bala para aplicar física 

    private float dano; //valor de dano que a bala causa´ra ao atingir o alvo

    private void SetDano(float danoValue) //Método privado para definir o valor de dano, recebendo um valor como parametro 
    {
        dano = danoValue;//Define o valor de dano com o valor recebido como parametro
    }

    public void SetAlvo(Transform _alvo) //Método publico que aceita um transform como paramêtro
    {
        alvo = _alvo; //Atribui o Transform passado como argumento para a variavel alvo
    }
    private void FixedUpdate()//responsável pela movimentação de um objeto em direção a um alvo. 
    {
        if (!alvo) return;//Verifica se o alvo é nulo; se for, vai sair do método sem executar o restante do código 

        // Calcula a direção em que a bala deve se mover, subtraindo a posição do objeto atual da posição do alvo.

        Vector2 direction = alvo.position - transform.position;

        //// Atualiza a posição do objeto atual, movendo para a direção do alvo com a velocidade da bala, multiplicada pelo tempo desde o último frame
        transform.position += (Vector3)direction * bulletSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)//Método chamado quando o objeto colide com outro objeto 2D.
    {
        Destroy(gameObject);//Destrói o objeto atual (como uma bala ou inimigo) ao colidir com qualquer outro objeto.

    }

}
