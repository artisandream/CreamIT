using TMPro;
using UnityEngine;

public class WorldLoader : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private GameObject _levelParent;
    [SerializeField] private GameObject _levelPrefab;
    
    private World _worldToLoad;

    public void LoadWorld(World world)
    {
        _worldToLoad = world;

        _titleText.text = _worldToLoad.WorldName;
        
        var levels = _worldToLoad.GetLevels();

        foreach (var level in levels)
        {
            var newLevel = Instantiate(_levelPrefab, _levelParent.transform);
            newLevel.name = level.LevelName;
        }
    }

}
