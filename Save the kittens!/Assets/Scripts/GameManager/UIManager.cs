using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Referências de UI")]
    [SerializeField] private GameObject[] catalogoDeGatos;
    [SerializeField] private GameObject painelGatos;
    [SerializeField] private TextMeshProUGUI savePan;
    [SerializeField] private GameObject HUD;
    private bool isOpnened = false;
    
    [Header("referências de mapa")]
    [SerializeField] private GameObject indicadorDePontoSalvo;
    
    public void AbrirCalogo()
    {
        painelGatos.SetActive(!isOpnened);
        HUD.SetActive(isOpnened);
        isOpnened = !isOpnened;
    }

    public void AtualizarCatalogo(int id)
    {
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

    public void TelaVitoria()
    {
        SceneManager.LoadScene("Vitória");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
