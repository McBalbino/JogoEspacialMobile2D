using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguir : MonoBehaviour
{
    [SerializeField]
    private Transform alvo;
    [SerializeField]
    private float velocidade;

    // Update is called once per frame
    void Update()
    {
        var deslocamento = alvo.position - transform.position;
        deslocamento = deslocamento.normalized;
        deslocamento *= this.velocidade;
        this.transform.position += deslocamento * Time.deltaTime;
    }

    public void SetAlvo(Transform novoAlvo) 
    {
        this.alvo = novoAlvo;
    }
}
