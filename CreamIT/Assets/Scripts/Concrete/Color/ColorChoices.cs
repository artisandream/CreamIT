
using UnityEngine;
using System;
public class ColorChoices : MonoBehaviour
{
    public enum AvaliableColors
    {
        Red,
        Yellow,
        Blue,
        Green,
        Pink,
        Purple,
        Orange,
        LTBlue
    }

    public Material Red;
    public Material Yellow;
    public Material Blue;
    public Material Green;
    public Material Pink;
    public Material Purple;
    public Material Orange;
    public Material LTBlue;

    ColorChoices.AvaliableColors thisColor;
    Material thisMaterial;

    void Awake()
    {
        MaterialColor.GetMaterial += OnSetColor;
    }
    public Material OnSetColor()
    {
        Array values = Enum.GetValues(typeof(ColorChoices.AvaliableColors));
        thisColor = 
		(ColorChoices.AvaliableColors)values.GetValue(UnityEngine.Random.Range(0, values.Length));
        return ChangeMaterial();
    }
    public Material ChangeMaterial()
    {
        switch (thisColor)
        {
            case ColorChoices.AvaliableColors.Red:
                thisMaterial = Red;
                break;
            case ColorChoices.AvaliableColors.Yellow:
                thisMaterial = Yellow;
                break;
            case ColorChoices.AvaliableColors.Blue:
                thisMaterial = Blue;
                break;
            case ColorChoices.AvaliableColors.Green:
                thisMaterial = Green;
                break;
                case ColorChoices.AvaliableColors.Pink:
                thisMaterial = Pink;
                break;
                case ColorChoices.AvaliableColors.Purple:
                thisMaterial = Purple;
                break;
                case ColorChoices.AvaliableColors.LTBlue:
                thisMaterial = LTBlue;
                break;
                case ColorChoices.AvaliableColors.Orange:
                thisMaterial = Orange;
                break;

            default:
                thisMaterial = Red;
                break;
        }
        return thisMaterial;
    }
}

