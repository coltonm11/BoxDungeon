using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPlacementController : MonoBehaviour
{
    bool placed;
    GameObject container;
    public float gridSize;

    private void Start()
    {
        placed = true;
    }

    public void PlaceContainer(GameObject c)
    {
        container = Instantiate(c);
        placed = false;
    }

    private void Update()
    {
        if (!placed)
        {
            container.transform.position = GetNearestPointToGrid();
            if (Input.GetMouseButtonDown(0))
            {
                placed = true;
            }
        }
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
