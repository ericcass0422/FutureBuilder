using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceBuilding : MonoBehaviour
{
    public GameObject buildingPrefab;

    void Update()
    {
        if (UnityEngine.Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 pos = hit.point;
                pos.x = Mathf.Round(pos.x / 5) * 5;
                pos.z = Mathf.Round(pos.z / 5) * 5;

                Collider[] colliders = Physics.OverlapSphere(pos + Vector3.up, 0.5f);

                if (colliders.Length == 0)
                {
                    Instantiate(buildingPrefab, pos, Quaternion.identity);
                }
            }
        }
    }
}
