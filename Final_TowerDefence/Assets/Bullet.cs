using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform alvo;

    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private Rigidbody rb;

    public void SetAlvo(Transform _alvo) //Método publico que aceita um transform como paramêtro
    {
        alvo = _alvo; //Atribui o Transform passado como argumento para a variavel alvo
    }
    private void FixedUpdate()
    {
        if (!alvo) return;//Verifica se o alvo é nulo; se for, vai sair do método sem executar o restante do código 

        Vector2 direction = alvo.position - transform.position;
        transform.position += (Vector3)direction * bulletSpeed * Time.deltaTime;
    }

}
