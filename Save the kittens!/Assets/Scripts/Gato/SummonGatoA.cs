
using UnityEngine;
using Random = UnityEngine.Random;

public class SummonGatoA : MonoBehaviour
{
    private int pontoEscolhido;
    [SerializeField] private Transform[] pontoSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AleatorizarSpawn();
    }



    private void AleatorizarSpawn()
    {

        pontoEscolhido = Random.Range(0, pontoSpawn.Length);
        gameObject.transform.position = pontoSpawn[pontoEscolhido].transform.position;
    }
}
