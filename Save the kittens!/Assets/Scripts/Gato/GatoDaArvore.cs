using UnityEngine;
using UnityEngine.Serialization;

public class GatoDaArvore : MonoBehaviour
{
    public bool escalando;
    [SerializeField] private Collider2D coll;
    [SerializeField] private GatoForaDaArvore gatoArvore;
    private void Start()
    {
        coll.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            escalando = true;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {    
        if (other.CompareTag("Player"))
        { 
            escalando = false;
        }
    }
    private void Update()
    {

        if (escalando || gatoArvore.JaEscalou) coll.enabled = true;
        else coll.enabled = false;
        
    }
}

