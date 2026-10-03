using System;
using UnityEngine;

public class CatId : MonoBehaviour
{
    [SerializeField] public int catID;
    [SerializeField] private GameManager gameManager;
    
    [Header("condições")]
    [SerializeField] public bool gatoSalvoNaArvore;
    private void Update()
    {
        if (gameManager.itemCarregado == null) return;
        if (gameManager.itemCarregado.name == gameObject.name && !gameManager.catIsFounded[catID])
        {
            gameManager.ColetarGatos(catID);
        }
    }
}
