using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPlacementController : MonoBehaviour
{

    bool placed;
    GameObject container;
    public float gridSize;

    // -------------------------------------------------------------

    private void Start()
    {
        placed = true;
    }

    private void Update()
    {
        if (!placed)
        {
            container.transform.position = GetNearestPointToGrid();
            if (Input.GetMouseButtonDown(0))
            {
                if (!container.GetComponent<BoxInventory>().invalidPlacementLocation)
                    placed = true;
            }
        }
    }

    // -------------------------------------------------------------

    public void PlaceContainerMode(GameObject c)
    {
        container = Instantiate(c);
        container.GetComponent<BoxInventory>().EnterPlacementMode();
        placed = false;
    }

    public Vector3 GetNearestPointToGrid()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePosition);

        int xCount = Mathf.RoundToInt(mousePosWorld.x / gridSize);
        int yCount = Mathf.RoundToInt(mousePosWorld.y / gridSize);
        int zCount = 1;


        Vector3 result = new Vector3
        (
            xCount * gridSize,
            yCount * gridSize,
            zCount
        );

        return result;
    }




}
