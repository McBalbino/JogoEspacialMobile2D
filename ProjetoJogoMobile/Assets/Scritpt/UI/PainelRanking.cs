using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainelRanking : MonoBehaviour
{
    [SerializeField]
    private Ranking ranking;
    [SerializeField]
    private GameObject prefabColocado;

    // Start is called before the first frame update
    private void Start()
    {
        var quantidade = this.ranking.Quantidade();
        for(var i = 0; i < quantidade; i++)
        {
            GameObject.Instantiate(this.prefabColocado, this.transform);
        }
    }

}
