using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Escada : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Referências")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GatoDaArvore arvore;
        [SerializeField] PegarItem pegarItem;
    public Vector2 posicao;
    
    
    private GameObject escada;
    [SerializeField] private GameObject escadaPrefab;
    public int escadaID;
    public bool escadaPosicionada;
    public int estadoEscada = 0;
    private GameObject item;


    
    void Start()
    {
        escada = GameObject.Find("EscadaNaArvore "+"("+escadaID+")");
        escada.SetActive(false);
        posicao = escada.transform.position;
        print(escada);
    }

    void Update()
    {
        if(gameManager.AcaoPegar() && estadoEscada == 2 && !arvore.escalando) PegarEscada();
        item = gameManager.itemCarregado;
        if (estadoEscada == 1 && gameManager.AcaoPegar() && !pegarItem.carregando && item.CompareTag("Escada")) ColocarEscada();
    }
    
    
    
    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.tag != "Player") return;

        if (!escadaPosicionada)
        {
            estadoEscada = 1;
        }
        else if (escadaPosicionada)
        {
            estadoEscada = 2;
        }
    }

    private void OnTriggerExit2D(Collider2D other) => estadoEscada = 0;
    private void ColocarEscada()
    {
        escada.SetActive(true);
        Destroy(item);
        gameManager.itemCarregado = null;
        escadaPosicionada = true;
        pegarItem.carregando = false;
        pegarItem.item = null;
    }

    private void PegarEscada()
    {
        escada.SetActive(false);
        Instantiate(escadaPrefab, posicao, Quaternion.identity);
        escadaPosicionada = false;
    }
}
