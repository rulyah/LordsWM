using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Char : MonoBehaviour
{
    public CharConfig config;
    
    private float startInit;
    public float positionX;
    public float positionY;
    public Cell currentCell;
    public float moveSpeed = 0.01f;
    
    public float StartInitCalculate(float init)
    {
        return startInit = init + Random.Range(init * -0.1f, init * 0.1f);
    }

    public bool MoveTo(Cell pos)
    {
        float distance = Vector2Int.Distance(new Vector2Int(pos.positionX, pos.positionY),
            new Vector2Int(currentCell.positionX, currentCell.positionY));

        if (pos.charInCell == null && distance <= config.speed)
        {
            Vector3 direction = Vector3.Normalize(pos.transform.position - currentCell.transform.position);

            currentCell.charInCell = null;
            pos.charInCell = this;
            //transform.position = pos.transform.position + new Vector3(0.0f, 0.0f, -0.07f);
            currentCell = pos;
            //transform.position += direction * moveSpeed;
            return true;
        }

        return false;

    }

    public void Update()
    {
        float distance = Vector3.Distance(transform.position, currentCell.transform.position);
        if (distance > 0.15f)
        {
            Vector3 direction = Vector3.Normalize(currentCell.transform.position + new Vector3(0.0f, 0.0f, -0.07f) -
                                                  transform.position);
    
            transform.position += direction * moveSpeed;

        }
    }
}
