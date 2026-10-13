using UnityEngine;

public class PLayerAnim : MonoBehaviour
{
    private Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }
        
    public void CheckWalkAnim(float x, float y)
    {
        anim.SetFloat("VelocityX", x);
        anim.SetFloat("VelocityY", y);
    }

}
