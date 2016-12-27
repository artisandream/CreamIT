
using UnityEngine;
using System.Collections.Generic;

public class LevelMaterialChoices : MonoBehaviour
{
    public GameObject dragableAsset;
    public GameObject ringAsset;
    public int totalRingCount;
    public List<Material> LevelMaterials;

    void Awake()
    {
        MaterialColor.GetMaterial += OnSetRandomColor;
        WaveObject.RingCount += AddToRingCount;
        AddDragableAssets();
        Invoke("AddRingAssets", 0.5f);
    }

    private void AddToRingCount(int _count)
    {
        if (totalRingCount <= _count)
        {
            totalRingCount = _count;
        }
    }

    void AddDragableAssets()
    {
        foreach (Material _m in LevelMaterials)
        {
            GameObject newDragable = Instantiate(dragableAsset);
            newDragable.GetComponent<SpriteRenderer>().material = _m;
            newDragable.name = "Asset";
        }
    }

    void AddRingAssets()
    {
        while (totalRingCount > 0)
        {
            GameObject newRing = Instantiate(ringAsset);
            newRing.name = "Asset";
            totalRingCount--;
        }
    }

    public Material OnSetRandomColor()
    {
        int random = StaticFunctions.RandomNumber(LevelMaterials.Count);
        return LevelMaterials[random];
    }
}

