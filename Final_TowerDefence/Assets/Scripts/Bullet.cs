using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform alvo; //Referencia ao alvo que a bala deve atingir
    

    [SerializeField] private float bulletSpeed = 5f; //Velocidade da bala, pode ser ajustada atrav�s do inspector
    [SerializeField] private Rigidbody2D rb;//Referencia ao componente Rigidbody da bala para aplicar f�sica 
    [SerializeField] private int bulletDamage = 1;

    private Transform target; 

    public void SetTarget(Transform _target) //M�todo publico que aceita um transform como param�tro
    {
        target = _target;//Atribui o Transform passado como argumento para a variavel alvo
    }
    private void FixedUpdate()//respons�vel pela movimenta��o de um objeto em dire��o a um alvo. 
    {
        if (!alvo) return;//Verifica se o alvo � nulo; se for, vai sair do m�todo sem executar o restante do c�digo 

        // Calcula a dire��o em que a bala deve se mover, subtraindo a posi��o do objeto atual da posi��o do alvo.

        Vector2 direction = (target.position - transform.position).normalized;

        //// Atualiza a posi��o do objeto atual, movendo para a dire��o do alvo com a velocidade da bala, multiplicada pelo tempo desde o �ltimo frame
        rb.velocity = direction * bulletSpeed;
    }
    
    private void OnCollisionEnter2D(Collision2D other)//M�todo chamado quando o objeto colide com outro objeto 2D.
    {
        //Other foi usado para poder acessar o gameObject no qual o objeto atual colidiu
        other.gameObject.GetComponent<Healthy>().TakeDamage(bulletDamage);//Obt�m o componente "Healthy" do objeto no qual teve colis�o e aplica o dano chamando o m�todo TakeDamage. Passando pela variavel bulletDamage que indica a quantidade de dano que o alvo levar�
        Destroy(gameObject);//Destr�i o objeto atual (como uma bala ou inimigo) ao colidir com qualquer outro objeto.

    }

}
