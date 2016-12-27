
using UnityEngine;
using System;
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
        AddDragableAssets();
       
//        MaterialColor.GetMaterial += OnSetColor;
    }

    void AddDragableAssets () {
        foreach (Material _m in LevelMaterials)
        {
		   GameObject newDragable =  Instantiate(dragableAsset);
           newDragable.GetComponent<SpriteRenderer>().material = _m;
           newDragable.name = "Asset";
        }
    }

    // public Material OnSetColor()
    // {
    //     Array values = Enum.GetValues(typeof(LevelMaterialChoices.AvaliableColors));
    //     thisColor =
    //     (LevelMaterialChoices.AvaliableColors)values.GetValue(StaticFunctions.RandomNumber(values.Length));
    //     return ChangeMaterial();
    // }
    // public Material ChangeMaterial()
    // {
    //     switch (thisColor)
    //     {
    //         case LevelMaterialChoices.AvaliableColors.Red:
    //             thisMaterial = Red;
    //             break;
    //         case LevelMaterialChoices.AvaliableColors.Yellow:
    //             thisMaterial = Yellow;
    //             break;
    //         case LevelMaterialChoices.AvaliableColors.Blue:
    //             thisMaterial = Blue;
    //             break;
    //         case LevelMaterialChoices.AvaliableColors.Green:
    //             thisMaterial = Green;
    //             break;
    //         case LevelMaterialChoices.AvaliableColors.Pink:
    //             thisMaterial = Pink;
    //             break;
    //         case LevelMaterialChoices.AvaliableColors.Purple:
    //             thisMaterial = Purple;
    //             break;
    //         case LevelMaterialChoices.AvaliableColors.LTBlue:
    //             thisMaterial = LTBlue;
    //             break;
    //         case LevelMaterialChoices.AvaliableColors.Orange:
    //             thisMaterial = Orange;
    //             break;
    //         default:
    //             thisMaterial = Red;
    //             break;
    //     }
    //     return thisMaterial;
    // }
}

