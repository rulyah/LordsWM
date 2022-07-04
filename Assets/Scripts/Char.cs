using UnityEngine;

public class Char : MonoBehaviour
{
    public CharConfig config;
    
    private float startInit;
    
    
    
    
    public float StartInitCalculate(float init)
    {
        return startInit = init + Random.Range(init * -0.1f, init * 0.1f);
    }
    
    
}
