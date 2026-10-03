using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Referências de UI")]
    [SerializeField] private GameObject[] catalogoDeGatos;
    [SerializeField] private GameObject painelGatos;
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

    public void AlternarPontoSalvar(bool alternar)
    {
        indicadorDePontoSalvo.SetActive(alternar);
    }
}
