using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseClick : MonoBehaviour
{
    public float rayLength;
    public GameObject fishPrefab;
    public LayerMask layerMask;

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, rayLength, layerMask))
            {
                if (hit.collider.tag == "Apple")
                {
                    Vector3 position = Camera.main.transform.position;
                    position.z -= 10;
                    GameObject fish = Instantiate(fishPrefab);
                    fish.transform.position = position;
                    fish.GetComponent<Fish>().SetTarget(hit.collider.transform.position);
                }
            }

        }
    }
}
