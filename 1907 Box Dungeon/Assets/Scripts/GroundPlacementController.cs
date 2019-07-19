using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPlacementController : MonoBehaviour
{
    bool placed;
    GameObject container;

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
            Vector3 placementPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
            container.transform.position = Camera.main.ScreenToWorldPoint(placementPosition);
            if (Input.GetMouseButtonDown(0))
            {
                placed = true;
            }
        }
    }



}
