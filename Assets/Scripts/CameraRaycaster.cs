using UnityEngine;

public class CameraRaycaster : MonoBehaviour
{
    public Camera camera;
    public ATB atb;
    public Grid grid;
    
    
    void Start()
    {
        /*Vector3 BotLeftCorner = camera.ViewportToWorldPoint(new Vector3(0,0,10));
        GameObject botLeft = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        botLeft.transform.position = BotLeftCorner;
        
        Vector3 BotRightCorner = camera.ViewportToWorldPoint(new Vector3(0,1,10));
        GameObject botRight = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        botRight.transform.position = BotRightCorner;
        
        Vector3 TopLeftCorner = camera.ViewportToWorldPoint(new Vector3(1,0,10));
        GameObject topLeft = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        topLeft.transform.position = TopLeftCorner;
        
        Vector3 TopRightCorner = camera.ViewportToWorldPoint(new Vector3(1,1,10));
        GameObject topRighr = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        topRighr.transform.position = TopRightCorner;

        float distance = Vector3.Distance(TopLeftCorner, TopRightCorner);*/
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100.0f))
            {
                Cell cellCoordinate = hit.transform.GetComponent<Cell>();
                if (grid.CanMove(cellCoordinate) == true)
                {
                    atb.currentChar.MoveTo(cellCoordinate);
                    atb.TurnEnd();
                }
                
            }

        }

        /*Ray ray1 = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray1, out RaycastHit hit1, 200.0f))
        {
            MeshRenderer mesh = hit1.transform.GetComponent<MeshRenderer>();
            mesh.sharedMaterial.color = Random.ColorHSV();
        }*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            atb.TurnEnd();
        }

        
    }
}
