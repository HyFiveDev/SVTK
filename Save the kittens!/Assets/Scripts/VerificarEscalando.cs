using UnityEngine;

public class VerificarEscalando : MonoBehaviour
{
    public bool escalando;
    private BoxCollider2D box;
    private Transform player;

    private void Start()
    {
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Escalavel"))
        {
            escalando = true;
            box = coll.gameObject.GetComponent<BoxCollider2D>();
            box.isTrigger = true;
            transform.position = new Vector3(coll.gameObject.transform.position.x, transform.position.y, transform.position.z);
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
            if(box == null) return;
            escalando = false;
            box.isTrigger = false;
            box = null;
            
    }
}
