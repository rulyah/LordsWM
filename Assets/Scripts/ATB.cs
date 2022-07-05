using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ATB : MonoBehaviour
{

    public Char currentChar;
    public List<Char> atbList;

    public void FillList(List<Char> units)
    {
        atbList = units;
        SortAtb();
    }

    public void SortAtb()
    {
        atbList = atbList.OrderByDescending(n => n.config.proactiveness).ToList();
        currentChar = atbList[0];
    }

    public void TurnEnd()
    {
        atbList.Remove(atbList[0]);
        atbList.Add(currentChar);
        currentChar = atbList[0];
    }
    
    
    

}
