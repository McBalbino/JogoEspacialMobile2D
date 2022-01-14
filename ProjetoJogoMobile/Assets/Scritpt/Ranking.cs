using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Collections.ObjectModel;

public class Ranking : MonoBehaviour
{
    private static string NOME_DO_ARQUIVO = "Ranking.json";
    [SerializeField]
    private List<Colocado> listaDeColocados;
    private string caminhoParaOArquivo;

    // Start is called before the first frame update
    private void Awake()
    {
        this.caminhoParaOArquivo = Path.Combine(Application.persistentDataPath, 
        NOME_DO_ARQUIVO);
        if (File.Exists(this.caminhoParaOArquivo))
        {
            var textoJson = File.ReadAllText(this.caminhoParaOArquivo);
            JsonUtility.FromJsonOverwrite(textoJson, this);
        } else 
        {
            this.listaDeColocados = new List<Colocado>();
        }

        //Debug.Log(this.pontos.Count);
    }

    public int AdicionarPontuacao(int pontos, string nome)
    {
        var id = this.listaDeColocados.Count * Random.Range(1, 10000);
        var novoColocado = new Colocado(nome, pontos, id);
        this.listaDeColocados.Add(novoColocado);
        this.SalvarRanking();
        return id;
    }

    public void AlterarNome(string novoNome, int id)
    {
        foreach(var item in this.listaDeColocados)
        {
            if(item.id == id)
            {
                item.nome = novoNome;
                break;
            }
        }
        this.SalvarRanking();
    }

    public int Quantidade() {
        return this.listaDeColocados.Count;
    }

    public ReadOnlyCollection<Colocado> GetColocados()
    {
        //devolvendo uma lista imutavel
        return this.listaDeColocados.AsReadOnly();
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

[System.Serializable]
public class Colocado
{
    public string nome;
    public int pontos;
    public int id;

    public Colocado(string nome, int pontos, int id)
    {
        this.nome = nome;
        this.pontos = pontos;
        this.id = id;
    }
}
