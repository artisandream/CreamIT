using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New World")]
public class World : ScriptableObject
{
    [Header("World Information")]
    [SerializeField] private int _worldId;
    [SerializeField] private string _worldName;
    [SerializeField] private bool _isLocked;

    [Header("Level Information")]
    [SerializeField] private List<Level> _levels;


    public string WorldName
    {
        get { return _worldName; }
    }

    public IEnumerable<Level> GetLevels()
    {
        return _levels;
    }
}