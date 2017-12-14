using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Level")]
public class Level : ScriptableObject
{
	[SerializeField] private int _levelId;
	[SerializeField] private string _levelName;
	[SerializeField] private bool _isLocked = true;
	[SerializeField] private List<WordsForLevel> _wordsToPlay;

	private int _highScore = 0;
	private StarRating _starRating = StarRating.None;
	private int _numTimesPlayed = 0;
	private System.DateTime _lastPlayedTime;
	
	public string LevelName
	{
		get { return _levelName; }
	}
}
