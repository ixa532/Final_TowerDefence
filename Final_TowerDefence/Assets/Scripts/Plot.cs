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
    private void OnMouseEnter() // M�todo chamado quando o mouse entra na �rea do plot.

    {
        sr.color = hoverColor; // Muda a cor do plot para a cor de hover.
    }

    private void OnMouseExit() // M�todo chamado quando o mouse sai da �rea do plot.

    {
        sr.color = startColor;// Restaura a cor inicial do plot.
    }
    private void OnMouseDown()    // M�todo chamado quando o mouse clica no plot.

    {
        if (tower != null) return;        // Se j� houver uma torre constru�da, n�o faz nada.


        TowerMain towerToBuild = Building.intance.GetSelectedTower();      // Obt�m a torre selecionada do BuildManager.
        if (towerToBuild.cost > LevelManager.instance.currency)
        {
            Debug.Log("Sem dinheiro");
            return;
        }
        LevelManager.instance.SpendCurrency(towerToBuild.cost);
        tower = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);        // Instancia a torre na posi��o do plot.

    }
}
