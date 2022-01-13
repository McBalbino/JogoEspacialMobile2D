using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Ranking : MonoBehaviour
{
    private static string NOME_DO_ARQUIVO = "Ranking.json";
    [SerializeField]
    private List<int> pontos;
    // Start is called before the first frame update
    private void Awake()
    {
        this.pontos = new List<int>();
    }

    public void AdicionarPontuacao(int pontos)
    {
        this.pontos.Add(pontos);
        this.SalvarRanking();
    }

    private void SalvarRanking()
    {
        //como irei salvar o ranking?
        var textoJson = JsonUtility.ToJson(this);
        var caminhoParaOArquivo = Path.Combine(Application.persistentDataPath, NOME_DO_ARQUIVO);
        File.WriteAllText(caminhoParaOArquivo, textoJson);
        //para ver onde o arquivo foi salvo
        Debug.Log(Application.persistentDataPath);
    }
}
