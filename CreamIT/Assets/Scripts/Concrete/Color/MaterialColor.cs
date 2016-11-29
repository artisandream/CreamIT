using System;
using UnityEngine;

[RequireComponent(typeof(Material))]
public class MaterialColor : MonoBehaviour
{
    public static Func<Material> GetMaterial;
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material = GetMaterial();
    }

    void OnMouseUp () {
        Start();
    }
}