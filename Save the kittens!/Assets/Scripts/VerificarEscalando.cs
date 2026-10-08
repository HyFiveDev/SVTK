using UnityEngine;

public class VerificarEscalando : MonoBehaviour
{
    public bool escalando;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Escalavel"))
        {
            escalando = true;
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Escalavel"))
        {
            escalando = false;
        }
    }
}
