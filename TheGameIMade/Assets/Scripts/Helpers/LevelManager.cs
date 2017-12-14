using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<World> _worlds;
    [SerializeField] private GameObject _levelParent;
    [SerializeField] private GameObject _levelPrefab;
    [SerializeField] private TextMeshProUGUI _worldName;

    private int _currentWorldIndex = 0;

    private void Start()
    {
        ShowWorld(_currentWorldIndex);
    }

    private void ShowWorld(int worldIndex = -1)
    {
        worldIndex = _worlds.InBounds(worldIndex) ? worldIndex : _currentWorldIndex;
        
        _worldName.text = _worlds[worldIndex].WorldName;
        
        var levels = _worlds[worldIndex].GetLevels();

        foreach (var level in levels)
        {
            var newLevel = Instantiate(_levelPrefab, _levelParent.transform);
            newLevel.name = level.LevelName;
        }
    }
}
