using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Referências de UI")]
    [SerializeField] private GameObject[] catalogoDeGatos;
    [SerializeField] private GameObject[] catalagoDesconhecido;
    [SerializeField] private GameObject painelGatos;
    [SerializeField] private TextMeshProUGUI savePan;
    [SerializeField] private GameObject HUD;
    private bool isOpnened = false;

    private InputSystem_Actions inputSystem;
    private InputAction action;

    [Header("referências de mapa")]
    [SerializeField] private GameObject indicadorDePontoSalvo;
    
    private void Awake()
    {
        inputSystem = new InputSystem_Actions();
        action = inputSystem.UI.AbrirCatalogo;
    }
    private void OnEnable() => action.Enable();
    private void OnDisable() => action.Disable();

    private void Update()
    {
        if(action.WasPressedThisFrame())
        {
            AbrirCalogo();
        }
    }
    public void AbrirCalogo()
    {
        painelGatos.SetActive(!isOpnened);
        HUD.SetActive(isOpnened);
        isOpnened = !isOpnened;
    }

    public void AtualizarCatalogo(int id)
    {
        catalagoDesconhecido[id].SetActive(false);
        catalogoDeGatos[id].SetActive(true);
        GatoNovoEncontrado();
    }
    
    public void GatoNovoEncontrado()
    {
    }

    public void AtualizarGatosSalvos(int gatosSalvos)
    {
        savePan.text = "Gatos Salvos: " + gatosSalvos +"/9";
        
    }
    
    public void AlternarPontoSalvar(bool alternar)
    {
        indicadorDePontoSalvo.SetActive(alternar);
    }

    public void IniciarFase()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("Inicio");
    }

    public void TelaVitoria()
    {
        SceneManager.LoadScene("Vitória");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
