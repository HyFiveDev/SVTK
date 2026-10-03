using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager ui;

    [Header("gatos")] public bool[] catIsFounded;

    [SerializeField] private int gatos = 5;

    [Header("spawn dos gatos")] public bool[] pontosLivres;
    public GameObject[] pontosSpawn;

    [Header("itens")] public GameObject itemCarregado;

    [FormerlySerializedAs("itemSolto")] public int itemEstado;
    //1=item pegado; 2=item solto; 3=item largado.

    //InputSystem
    private InputSystem_Actions inputSystem;
    public InputAction pegar;

    void Awake()
    {
        inputSystem = new InputSystem_Actions();
        pegar = inputSystem.Player.Catch;


        //definir pontos de spawn de gato
        pontosLivres = new bool[pontosSpawn.Length];
        for (int i = 0; i < pontosLivres.Length; i++) pontosLivres[i] = false;

        catIsFounded = new bool[gatos];
    }

    private void OnEnable()
    {
        pegar.Enable();
    }

    private void OnDisable()
    {
        pegar.Disable();
    }


    public void escolherPonto(int ponto)
    {
        //os gato escolhe o ponto
        pontosLivres[ponto] = true;
    }

    public void ColetarGatos(int id)
    {
        ui.AtualizarCatalogo(id);
        catIsFounded[id] = true;
    }

    public bool AcaoPegar()
    {

        return pegar.WasPressedThisFrame();

    }

    public bool AcaoSoltar()
    {
        return pegar.WasPressedThisFrame();
    }


    public IEnumerator AtualizarEstado()
    {
        yield return new WaitForSeconds(2f);
        itemEstado = 3;
        StartCoroutine(AtualizarEstado());
    }
}
