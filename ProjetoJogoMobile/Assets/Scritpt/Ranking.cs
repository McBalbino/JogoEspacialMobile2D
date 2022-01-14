using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Ranking : MonoBehaviour
{
    private static string NOME_DO_ARQUIVO = "Ranking.json";
    [SerializeField]
    private List<int> pontos;
    private string caminhoParaOArquivo;

    // Start is called before the first frame update
    private void Awake()
    {
        this.caminhoParaOArquivo = Path.Combine(Application.persistentDataPath, NOME_DO_ARQUIVO);
        var textoJson = File.ReadAllText(this.caminhoParaOArquivo);
        JsonUtility.FromJsonOverwrite(textoJson, this);
        //Debug.Log(this.pontos.Count);
    }

    public void AdicionarPontuacao(int pontos)
    {
        this.pontos.Add(pontos);
        this.SalvarRanking();
    }

    public int Quantidade() {
        return this.pontos.Count;
    }

    private void SalvarRanking()
    {
        //como irei salvar o ranking?
        var textoJson = JsonUtility.ToJson(this);
        File.WriteAllText(this.caminhoParaOArquivo, textoJson);
        //para ver onde o arquivo foi salvo
        //Debug.Log(Application.persistentDataPath);
    }
}
