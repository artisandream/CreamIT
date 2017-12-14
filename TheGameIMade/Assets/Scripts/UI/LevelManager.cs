using TMPro;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI.Extensions;

public class LevelManager : MonoBehaviour
{
    private const string PlayerPrefsKey = "world_data";
    
    [SerializeField] private List<World> _worlds;
    [SerializeField] private GameObject _worldPrefab;
    [SerializeField] private HorizontalScrollSnap _worldScrollSnap;

    private int _currentWorldIndex = 0;

    private void Awake()
    {
        LoadFromPlayerPrefs();
    }

    private void Start()
    {
        foreach (var world in _worlds)
        {
            var newWorld = Instantiate(_worldPrefab);
            newWorld.GetComponent<WorldLoader>().LoadWorld(world);
            _worldScrollSnap.AddChild(newWorld);
        }
    }

    private void OnDestroy()
    {
        SaveToPlayerPrefs();
    }

    private void LoadFromPlayerPrefs()
    {
        var worldsJson = PlayerPrefs.GetString(PlayerPrefsKey);
        
        JsonUtility.FromJsonOverwrite(worldsJson, _worlds);
    }

    public void SaveToPlayerPrefs()
    {
        var worldsJson = JsonUtility.ToJson(_worlds);
        
        PlayerPrefs.SetString(PlayerPrefsKey, worldsJson);
    }

}
