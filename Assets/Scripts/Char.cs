using UnityEngine;

public class Char : MonoBehaviour
{
    public CharConfig config;
    
    private float startInit;
    public float positionX;
    public float positionY;
    public Cell currentCell;
    
    
    public float StartInitCalculate(float init)
    {
        return startInit = init + Random.Range(init * -0.1f, init * 0.1f);
    }

    public void MoveTo(Cell pos)
    {

        if (pos.charInCell == null)
        {
            currentCell.charInCell = null;
            pos.charInCell = this;
            currentCell = pos;
            transform.position = pos.transform.position + new Vector3(0.0f, 0.0f, -0.07f);
        }


    }

    
    
    
    
}
