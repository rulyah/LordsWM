using UnityEngine;

[CreateAssetMenu(fileName = "UnitConfig", menuName = "Configs/Unit")]
public class CharConfig : ScriptableObject
{
    public GameObject prefab;
    
    
    
    
    public int posX;
    public int posY;

    public int attack;
    public int defence;
    public int health;
    public int speed;
    public int minDamage;
    public int maxDamage;
    public float proactiveness;
    
    

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
