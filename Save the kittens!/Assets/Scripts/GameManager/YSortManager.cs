using UnityEngine;

public class YSortManager : MonoBehaviour
{
    [System.Serializable]
    public class ObjetoParaOrdenar
    {
        public Transform sortPoint;
        public SpriteRenderer spriteRenderer;
    }

    [SerializeField] private ObjetoParaOrdenar[] objetos;

    [SerializeField] private int multiplicador = 1;

    private void LateUpdate()
    {
        foreach (ObjetoParaOrdenar objeto in objetos)
        {
            int order = Mathf.RoundToInt(
                -objeto.sortPoint.position.y * multiplicador
            );

            objeto.spriteRenderer.sortingOrder = order;
        }
    }
}