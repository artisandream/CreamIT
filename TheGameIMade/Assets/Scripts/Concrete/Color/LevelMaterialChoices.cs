
using UnityEngine;
using System.Collections.Generic;

public class LevelMaterialChoices : MonoBehaviour
{
    // public enum AvaliableColors
    // {
    //     Red,
    //     Yellow,
    //     Blue,
    //     Green,
    //     Pink,
    //     Purple,
    //     Orange,
    //     LTBlue
    // }
    
    public GameObject dragableAsset;
    public GameObject ringAsset;
    public int totalRingCount;

    public List<Material> LevelMaterials;

    // public Material Red;
    // public Material Yellow;
    // public Material Blue;
    // public Material Green;
    // public Material Pink;
    // public Material Purple;
    // public Material Orange;
    // public Material LTBlue;

//    LevelMaterialChoices.AvaliableColors thisColor;
    //Material thisMaterial;

    void Awake()
    {       
        MaterialColor.GetMaterial += OnSetColor;
        WaveObject.RingCount += AddToRingCount;
        AddDragableAssets();
        Invoke("AddRingAssets", 0.5f);
    }

    private void AddToRingCount(int _count)
    {
        
        if(totalRingCount <= _count) {
            totalRingCount = _count;
        }    
    }

    void AddDragableAssets () {
        foreach (Material _m in LevelMaterials)
        {
		   GameObject newDragable =  Instantiate(dragableAsset);
           newDragable.GetComponent<SpriteRenderer>().material = _m;
           newDragable.name = "Asset";
        }
    }

    void AddRingAssets () {
        while (totalRingCount > 0) {
            GameObject newRing =  Instantiate(ringAsset);
           // newRing.GetComponent<SpriteRenderer>().material = LevelMaterials[0];
//            newRing.GetComponent<RingAsset>().OnSetColor()
            newRing.name = "Asset";
            totalRingCount--;
        }
    }

    public Material OnSetColor()
    {   
        int random = StaticFunctions.RandomNumber(LevelMaterials.Count);
        // Array values = Enum.GetValues(typeof(LevelMaterialChoices.AvaliableColors));
        // thisColor =
        // (LevelMaterialChoices.AvaliableColors)values.GetValue(StaticFunctions.RandomNumber(values.Length));
       print(random);
       return LevelMaterials[random];
    }
    // public Material ChangeMaterial()
    // {
    //     return null;
    //     // switch (thisColor)
    //     // {
    //     //     case LevelMaterialChoices.AvaliableColors.Red:
    //     //         thisMaterial = Red;
    //     //         break;
    //     //     case LevelMaterialChoices.AvaliableColors.Yellow:
    //     //         thisMaterial = Yellow;
    //     //         break;
    //     //     case LevelMaterialChoices.AvaliableColors.Blue:
    //     //         thisMaterial = Blue;
    //     //         break;
    //     //     case LevelMaterialChoices.AvaliableColors.Green:
    //     //         thisMaterial = Green;
    //     //         break;
    //     //     case LevelMaterialChoices.AvaliableColors.Pink:
    //     //         thisMaterial = Pink;
    //     //         break;
    //     //     case LevelMaterialChoices.AvaliableColors.Purple:
    //     //         thisMaterial = Purple;
    //     //         break;
    //     //     case LevelMaterialChoices.AvaliableColors.LTBlue:
    //     //         thisMaterial = LTBlue;
    //     //         break;
    //     //     case LevelMaterialChoices.AvaliableColors.Orange:
    //     //         thisMaterial = Orange;
    //     //         break;
    //     //     default:
    //     //         thisMaterial = Red;
    //     //         break;
    //     // }
    //     // return thisMaterial;
    // }
}

