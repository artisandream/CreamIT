
using UnityEngine;
using System;
public class ColorChoices : MonoBehaviour
{
    public enum AvaliableColors
    {
        Red,
        Yellow,
        Blue,
        Green
    }

    public Material Red;
    public Material Yellow;
    public Material Blue;
    public Material Green;

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

            default:
                thisMaterial = Red;
                break;
        }
        return thisMaterial;
    }
}

