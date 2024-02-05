using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] Color color;

    public void ChangeColor()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.material.SetColor("_BaseColor", Random.ColorHSV());
    }
}
