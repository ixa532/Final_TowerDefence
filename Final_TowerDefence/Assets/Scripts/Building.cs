using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour//classe que gerencia a sele�a�o e configura��o das torres 
{
    public static Building Instance; // instancia estatica da classe para permitir o aceso global a sele��o das torres
    [SerializeField] private Tower[] towers; //Array de torres disponivel para sele��o

   
}
