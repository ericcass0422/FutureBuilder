using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject building1;
    public GameObject building2;

    public GameObject selectedBuilding;

    void Start()
    {
        selectedBuilding = building1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedBuilding = building1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedBuilding = building2;
        }
    }
}