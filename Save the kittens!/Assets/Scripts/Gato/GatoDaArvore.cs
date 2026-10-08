using UnityEngine;
using UnityEngine.Serialization;

public class GatoDaArvore : MonoBehaviour
{

    public bool JaEscalou;
    private Collider2D coll;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private VerificarEscalando escalar;
    private void Start()
    {
        coll = GetComponent<Collider2D>();
        coll.enabled = false;
    }
    private void Update()
    {
        if (escalar.escalando || JaEscalou)
        { 
            coll.enabled = true;
        }
        else coll.enabled = false;

        if (gameManager.itemCarregado == null) return;
        if (gameManager.itemCarregado.name == gameObject.name)
        {
            JaEscalou = true;
        }
    }
}

