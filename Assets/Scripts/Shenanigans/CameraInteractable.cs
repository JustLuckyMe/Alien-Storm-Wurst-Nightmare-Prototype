using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteractable : MonoBehaviour
{
    private Camera camera;
   
    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray mouseRay = camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(mouseRay, out RaycastHit hit))
            {
                Interactable interactable = hit.transform.GetComponent<Interactable>();
                if (interactable)
                {
                    interactable.ChangeColor();
                }
            }
        }
    }
}
