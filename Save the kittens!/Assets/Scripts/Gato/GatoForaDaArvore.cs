using UnityEngine;

public class GatoForaDaArvore : MonoBehaviour
{
    public bool JaEscalou;
    [SerializeField] private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.itemCarregado.name == gameObject.name) JaEscalou = true;
    }
}
