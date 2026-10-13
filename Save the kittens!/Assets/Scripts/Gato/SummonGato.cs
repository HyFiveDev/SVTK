
using UnityEngine;
using Random = UnityEngine.Random;

public class SummonGato : MonoBehaviour
{
    private int pontoEscolhido;
    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        AleatorizarSpawn();
    }



    private void AleatorizarSpawn()
    {

        pontoEscolhido = Random.Range(0, gameManager.pontosSpawn.Length);

        if (!gameManager.pontosLivres[pontoEscolhido])
        {
            gameObject.transform.position = gameManager.pontosSpawn[pontoEscolhido].transform.position;
            gameManager.escolherPonto(pontoEscolhido);

        }
        else
        { 
            AleatorizarSpawn();
        }
    }
}
