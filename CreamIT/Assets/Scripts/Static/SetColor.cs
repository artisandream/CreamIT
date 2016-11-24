using UnityEngine;
using System;

public class SetColor
{

    private static ColorChoices.AvaliableColors thisColor;

    private static Color dotColor = Color.red;
    private static Material material;

    public static Color OnSetColor()
    {
        Array values = Enum.GetValues(typeof(ColorChoices.AvaliableColors));
        System.Random random = new System.Random();
        thisColor = (ColorChoices.AvaliableColors)values.GetValue(random.Next(values.Length));
        return OnChangeColor();
    }

    public static Color OnChangeColor()
    {
        switch (thisColor)
        {
            case ColorChoices.AvaliableColors.Blue:
                dotColor = Color.blue;
                break;

            case ColorChoices.AvaliableColors.Green:
                dotColor = Color.green;
                break;
            case ColorChoices.AvaliableColors.Red:
                dotColor = Color.red;
                break;
            case ColorChoices.AvaliableColors.Yellow:
                dotColor = Color.yellow;
                break;

            default:
                dotColor = Color.red;
                break;
        }
        return dotColor;
    }

}
