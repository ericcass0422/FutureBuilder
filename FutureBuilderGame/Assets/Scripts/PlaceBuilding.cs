using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceBuilding : MonoBehaviour
{
    public BuildManager buildmanager;

    private GameObject previewBuilding;
    private Vector3 currentGridPosition;

    void Start()
    {
        previewBuilding = Instantiate(buildmanager.selectedBuilding);
        previewBuilding.GetComponent<Collider>().enabled = false;

        Renderer renderer = previewBuilding.GetComponent<Renderer>();

        if (renderer != null)
        {
            Color color = renderer.material.color;
            color = Color.green;
            renderer.material.color = color;
        }
    }

    void Update()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 pos = hit.point;
            pos.x = Mathf.Round(pos.x / 5) * 5;
            pos.z = Mathf.Round(pos.z / 5) * 5;

            currentGridPosition = pos;
            if (previewBuilding != null)
            {
                previewBuilding.transform.position = currentGridPosition;
            }
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                Collider[] colliders = Physics.OverlapSphere(pos + Vector3.up, 0.5f);

                if (colliders.Length == 0)
                {
                    Instantiate(buildmanager.selectedBuilding, pos, Quaternion.identity);
                }
            }
        }
    }
}
