using UnityEngine;

[CreateAssetMenu(menuName = "New Character Map")]
public class Characters : ScriptableObject
{
    [SerializeField] private CharecterMap _characterImageMap = new CharecterMap
    {
        //Sprites will be assigned in the editor
        {'a', null},
        {'b', null},
        {'c', null},
        {'d', null},
        {'e', null},
        {'f', null},
        {'g', null},
        {'h', null},
        {'i', null},
        {'j', null},
        {'k', null},
        {'l', null},
        {'m', null},
        {'n', null},
        {'o', null},
        {'p', null},
        {'q', null},
        {'r', null},
        {'s', null},
        {'t', null},
        {'u', null},
        {'v', null},
        {'w', null},
        {'x', null},
        {'y', null},
        {'z', null}
    };

    public Sprite GetCharecterSprite(char charecterKey)
    {
        var lowerChar = char.ToLowerInvariant(charecterKey);

        if (_characterImageMap.ContainsKey(lowerChar))
        {
            return _characterImageMap[lowerChar];
        }
        
        Debug.LogError("GetCharecterSprite: Key Not Found " + lowerChar);
        
        //TODO: Add a default image to return if nothing was found
        return null;
    }
}
