using System;
using UnityEngine;

public class CatId : MonoBehaviour
{
    [SerializeField] public int catID;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
    private void Update()
    {
        if (gameManager.itemCarregado == null) return;
        if (gameManager.itemCarregado.name == gameObject.name && !gameManager.catIsFounded[catID])
        {
            gameManager.ColetarGatos(catID);
        }
    }
}
