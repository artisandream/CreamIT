using System;
using UnityEngine;

namespace Concrete.Color
{
    [RequireComponent(typeof(Material))]
    public class MaterialColor : MonoBehaviour
    {
        public static Func<Material> GetMaterial;
        void Start()
        {
            Renderer rend = GetComponent<Renderer>();
            rend.material = GetMaterial();
        }
    }
}