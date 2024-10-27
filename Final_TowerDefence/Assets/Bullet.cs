using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform alvo;

    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private Rigidbody rb;

    public void SetAlvo(Transform _alvo) //M�todo publico que aceita um transform como param�tro
    {
        alvo = _alvo; //Atribui o Transform passado como argumento para a variavel alvo
    }
    private void FixedUpdate()
    {
        Vector2 direction = alvo.position - transform.position;
        transform.position += (Vector3)direction * bulletSpeed * Time.deltaTime;
    }

}
