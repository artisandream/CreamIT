using System.Collections.Generic;
using Concrete.GameControl;
using Static;
using UnityEngine;

namespace Concrete.Color
{
    public class LevelMaterialChoices : MonoBehaviour
    {
        public GameObject DragableAsset;
        public GameObject RingAsset;
        public int TotalRingCount;
        public List<Material> LevelMaterials;

        void Awake()
        {
            MaterialColor.GetMaterial += OnSetRandomColor;
            WaveObject.RingCountAction += AddToRingCount;
            AddDragableAssets();
            Invoke("AddRingAssets", 0.5f);
        }

        private void AddToRingCount(int count)
        {
            TotalRingCount += count;
            StaticFunctions.totalRingCount += count;
        }

        void AddDragableAssets()
        {
            foreach (Material _m in LevelMaterials)
            {
                GameObject newDragable = Instantiate(DragableAsset);
                newDragable.GetComponent<SpriteRenderer>().material = _m;
                newDragable.name = "Asset";
            }
        }

        void AddRingAssets()
        {
            while (TotalRingCount > 0)
            {
                GameObject newRing = Instantiate(RingAsset);
                newRing.name = "Asset";
                TotalRingCount--;
            }
        }

        public Material OnSetRandomColor()
        {
            int random = StaticFunctions.RandomNumber(LevelMaterials.Count);
            return LevelMaterials[random];
        }
    }
}

