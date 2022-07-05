using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public CameraRaycaster cameraRaycaster;
    public ATB atb;
    public GameObject prefab;
    public int sizeX = 12;
    public int sizeY = 18;
    public float paddingX = 0.1f;
    public float paddingY = 0.1f;

    public List<Cell> cubes;


    
    public void SpawnUnit()
    {
        var queue = new List<Char>();
        
        var charConfigs1 = Resources.LoadAll<CharConfig>("Configs/");
        
        foreach (var unitConfig in charConfigs1)
        {
            var unit = Instantiate(unitConfig.prefab);
            Cell currentCell = SearchCell(new Vector2Int(unitConfig.posX, unitConfig.posY));
            unit.transform.position = currentCell.transform.position - new Vector3(0, 0, 0.07f);
            unit.transform.localScale = new Vector3(0.3f, 0.3f, 0.2f);
            Char c = unit.GetComponent<Char>();
            currentCell.charInCell = c;
            c.currentCell = currentCell;
            queue.Add(c);
            
        }
        
        atb.FillList(queue);

    }

    public bool CanMove(Cell pos)
    {
        if (pos.charInCell != null)
        {
            return false;
        }

        return true;
    }

    public Cell SearchCell(Vector2Int pos)
    {
        for (int i = 0; i < cubes.Count; i++)
        {
            if (cubes[i].positionX == pos.x && cubes[i].positionY == pos.y)
            {
                return cubes[i];
            }
        }
        return null;
    }



    void Start()
    {
        cubes = new List<Cell>();
        
        Vector3 leftBorder = cameraRaycaster.camera.ViewportToWorldPoint(new Vector3(paddingX, 0.0f, 10));
        Vector3 rightBorder = cameraRaycaster.camera.ViewportToWorldPoint(new Vector3(1.0f - paddingX, 0.0f, 10));
        Vector3 downBorder = cameraRaycaster.camera.ViewportToWorldPoint(new Vector3(0.0f, paddingY, 10));
        Vector3 upBorder = cameraRaycaster.camera.ViewportToWorldPoint(new Vector3(0.0f, 1.0f - paddingY, 10));
        Vector3 nullBorderX = cameraRaycaster.camera.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 10.0f));

        float distanceForNullY = Vector3.Distance(nullBorderX, downBorder);
        float distanceForNullX = Vector3.Distance(nullBorderX, leftBorder);
        float distanceForY = Vector3.Distance(downBorder, upBorder);
        float distanceForX = Vector3.Distance(leftBorder, rightBorder);
        
        float height = distanceForY / sizeY;
        float width = distanceForX / sizeX;


        for (int y = 1; y <= sizeY; y++)
        {
            for (int x = 1; x <= sizeX; x++)
            {
                var cube = Instantiate(prefab);
                Vector3 pos = cameraRaycaster.camera.ViewportToWorldPoint(new Vector3(
                    x * (1.0f - paddingX * 2.0f) / (float)sizeX, y * (1 - paddingY * 2.0f) / (float)sizeY, 10));
                cube.transform.rotation = Quaternion.Euler(90, 0, 0);
                cube.transform.localScale = new Vector3(width - 0.02f, 0.1f, height - 0.02f);
                cube.transform.position = pos + new Vector3(distanceForNullX - width / 2.0f, distanceForNullY - height / 2.0f, 0);
                Cell cell = cube.GetComponent<Cell>();
                cell.positionX = x;
                cell.positionY = y;
                cubes.Add(cell);

                Material material = new Material(Shader.Find("Standard"));
                MeshRenderer mesh = cube.GetComponent<MeshRenderer>();
                mesh.sharedMaterial = material;

            }
        }
        
        SpawnUnit();
        

    }

}
