using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PegarItem : MonoBehaviour
{
    [Header("referências")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private UIManager ui;
    [SerializeField] private Transform pontoCarregar;
    
    [Header("Pontos")]
    private Transform pontoSalvar;
    public bool pontoProximo = false;
    
    [Header("Ações")]
  
 
    public bool carregando = false;
    
    public GameObject item;
    private SpriteRenderer itemSprite;
    private SpriteRenderer gObjSprite;
    
    void Awake()
    {
        gObjSprite = GetComponent<SpriteRenderer>();

    }
    

    void Update()
    {
        if (item == null) return;
        ui.AlternarPontoSalvar(carregando);
             
        if (gameManager.AcaoSoltar() && carregando && pontoProximo)
        {
            SalvarGato();
            gameManager.itemEstado = 2;
            StartCoroutine(gameManager.AtualizarEstado());
        }  

        if (carregando && gameManager.AcaoSoltar())
        {

            SoltarItem();

            StartCoroutine(gameManager.AtualizarEstado());
        }
        
        if (gameManager.AcaoPegar() && !carregando && item != null || carregando && item != null)
        {
            CarregarItem(item);

        }


    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Item") && !carregando)
        {
            item = collision.gameObject;
        }

        if (collision.gameObject.CompareTag("PontoSalvar") && item.CompareTag("Gato") && carregando)
        {
            pontoProximo = true;
            pontoSalvar = collision.transform;
            Debug.Log("Ponto salvar próximo!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
    
        if (other.gameObject.CompareTag("PontoSalvar") && item.CompareTag("Gato") && carregando)
        {
            pontoSalvar = null;
            pontoProximo = false;
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Item") && !carregando)
        {
            item = null;
            gameManager.itemCarregado = null;
        }

        
    }

    public void CarregarItem(GameObject item)
    {
        carregando = true;
        gameManager.itemCarregado = item;
        itemSprite = item.GetComponent<SpriteRenderer>();
        item.transform.position = pontoCarregar.position;
        itemSprite.sortingOrder = gObjSprite.sortingOrder;
        gameManager.itemEstado = 1;

        
        //MostrarSetinha();
        Debug.Log("Carregando!");
    }

    private void SalvarGato()
    {
        if (gameManager.itemCarregado.tag != "Gato") return;
        CatId cat = gameManager.itemCarregado.GetComponent<CatId>();
        item.transform.position = pontoSalvar.position;
        itemSprite.sortingOrder = 0;
        gameManager.itemCarregado = null;
        item = null;
        carregando = false;
        gameManager.SalvarGatos(cat.catID);
        Debug.Log("Gato Salvo!");
    }
    private void SoltarItem()
    {
        gameManager.itemEstado = 2;
        itemSprite.sortingOrder = 0;
        carregando = false;
        item = null;
        Debug.Log("Item solto!");
    }

    private void MostrarSetinha()
    {

        GameObject setinha = GameObject.Find("setinha");
        setinha.SetActive(true);
    }
}
