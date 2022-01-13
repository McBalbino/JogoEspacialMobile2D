using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Pontuacao : MonoBehaviour
{
    //metodo acessor
    public int Pontos 
    {
        get
        {
            return this.pontos;
        }
    }

    [SerializeField]
    private MeuEventoPersonalizadoInt aoPontuar;
    private int pontos;

    public void Pontuar() 
    {
        this.pontos++;
        this.aoPontuar.Invoke(this.pontos);
    }
}

[System.Serializable]
public class MeuEventoPersonalizadoInt : UnityEvent<int>
{

}
