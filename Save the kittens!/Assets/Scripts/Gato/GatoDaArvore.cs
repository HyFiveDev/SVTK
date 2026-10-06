using UnityEngine;
using UnityEngine.Serialization;

public class GatoDaArvore : MonoBehaviour
{
    public bool escalando;
    public bool JaEscalou;
    private Collider2D coll;
    private CapsuleCollider2D capsule;
    private GatoForaDaArvore gatoArvore;
    [SerializeField] private GameManager gameManager;
    private void Start()
    {
        coll = GetComponent<Collider2D>();
        capsule = GetComponent<CapsuleCollider2D>();
        gatoArvore = GetComponent<GatoForaDaArvore>();
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

        if (escalando || JaEscalou)
        { 
            coll.enabled = true;
        }
        else coll.enabled = false;

        if (gameManager.itemCarregado == null) return;
        if (gameManager.itemCarregado.name == gameObject.name)
        {
            JaEscalou = true;
            Destroy(capsule);
        }
    }
}

