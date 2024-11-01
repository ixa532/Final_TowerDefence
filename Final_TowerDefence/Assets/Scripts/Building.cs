using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour//classe que gerencia a seleçaão e configuração das torres 
{
    public static Building Instance; // instancia estatica da classe para permitir o aceso global a seleção das torres
    [SerializeField] private Tower[] towers; //Array de torres disponivel para seleção

   
}
