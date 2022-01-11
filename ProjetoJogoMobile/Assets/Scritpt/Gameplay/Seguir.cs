using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguir : MonoBehaviour
{
    [SerializeField]
    private Transform alvo;

    // Update is called once per frame
    void Update()
    {
        var deslocamento = alvo.position - transform.position;
        deslocamento = deslocamento.normalized;
        this.transform.position += deslocamento * Time.deltaTime;
    }
}
