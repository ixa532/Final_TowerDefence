using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour //Representa uma �rea onde torres podem ser constru�das no jogo.
{
    [SerializeField] private SpriteRenderer sr;    // Componente SpriteRenderer usado para mudar a apar�ncia do plot.

    [SerializeField] private Color hoverColor;    // Cor que ser� aplicada quando o mouse passar sobre o plot.

    private GameObject tower;    // Refer�ncia ao objeto da torre constru�da neste plot.

    private Color startColor;    // Cor inicial do plot.
    
    private void Start()// M�todo chamado ao iniciar o jogo. Inicializa a cor inicial do plot.
    {
        startColor = sr.color;// Armazena a cor inicial do SpriteRenderer.
    }
}
