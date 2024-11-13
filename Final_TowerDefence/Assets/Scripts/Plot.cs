using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour //Representa uma área onde torres podem ser construídas no jogo.
{
    [SerializeField] private SpriteRenderer sr;    // Componente SpriteRenderer usado para mudar a aparência do plot.

    [SerializeField] private Color hoverColor;    // Cor que será aplicada quando o mouse passar sobre o plot.

    private GameObject tower;    // Referência ao objeto da torre construída neste plot.

    private Color startColor;    // Cor inicial do plot.
    
    private void Start()// Método chamado ao iniciar o jogo. Inicializa a cor inicial do plot.
    {
        startColor = sr.color;// Armazena a cor inicial do SpriteRenderer.
    }
}
