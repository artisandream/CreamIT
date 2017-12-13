using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
	private List<WayPointRow> _wayPointRows = new List<WayPointRow>();

	[Header("Spawn Times"), SerializeField] private float _newWordSpawnTime = 20.0f;
	[SerializeField] private float _newCharecterSpawnTime = 3.0f;
	[SerializeField, Tooltip("Time to move between the different way points, Bigger values makes the piece go slower")] private float _letterSpeed = 10.0f;
	
	[Header("Way Points"),SerializeField] private GameObject _startPoint;
	[SerializeField] private WayPoint _endWayPoint;

	[Header("Prefabs"), SerializeField] private GameObject _emptyLetterPrefab;
	[SerializeField] private GameObject _letterPrefab;
	[SerializeField] private GameObject _lettersParent;
	
	[Header("Scriptable Object Maps"), SerializeField] private ScriptableObject _charecterMap;
	[SerializeField] private ScriptableObject _wordsMap;

	public static UnityAction<string> DefinitionChanged;
	
	private void Awake()
	{
		WayPointRow.WayPointRowAdded += WayPointRowAdded;
	}

	private void Start()
	{
		StartCoroutine(SpawnNewWord());
	}

	private IEnumerator SpawnNewWord()
	{
		while (gameObject.activeInHierarchy)
		{			
			var wordCount = (WordCount)Random.Range(0, 7);
			Debug.Log("SpawnNewWord: " + wordCount);
			StartCoroutine(SpawnNewPiece(wordCount));
			
			yield return new WaitForSeconds(_newWordSpawnTime);
		}
	}

	private IEnumerator SpawnNewPiece(WordCount wordCount)
	{
		var newWord = ((Words) _wordsMap).GetWord(wordCount);
		PopulateLetterToPlayWith(newWord.Key);

		if (DefinitionChanged != null)
		{
			DefinitionChanged.Invoke(newWord.Value);
		}
		
		foreach (var wordChar in newWord.Key)
		{
			yield return new WaitForSeconds(_newCharecterSpawnTime);
					
			var newGamePieceObject = Instantiate(_emptyLetterPrefab, 
				_startPoint.transform.position, 
				Quaternion.identity, 
				_startPoint.transform);
			var newGamePiece = newGamePieceObject.AddComponent<EmptyLetterGamePiece>();
			newGamePiece.CharecterValue = wordChar;

			foreach (var wayPointRow in _wayPointRows)
			{
				var wayPoint = wayPointRow.GetRandomWayPoint();
				newGamePiece.AddWayPoint(wayPoint);
			}
			
			newGamePiece.AddWayPoint(_endWayPoint);
			newGamePiece.MoveToFirstWayPoint();
		}
	}

	private void PopulateLetterToPlayWith(string word)
	{
		//Remove letters from last word
		foreach (Transform childTransform in _lettersParent.transform)
		{
			Destroy(childTransform.gameObject);
		}
		
		var letterToAdd = word.ToList();
		
		//ASCII values for a-z in 97 - 122
		//Add between 2 - 4 random latters
		var randomLetterToAdd = Random.Range(2, 5);
		for (var count = 0; count < randomLetterToAdd; count++)
		{
			letterToAdd.Add((char)Random.Range(97, 123));
		}

		//"Shuffle" the list
		letterToAdd = letterToAdd.OrderBy(a => Random.Range(0, 100)).ToList();

		foreach (var charToAdd in letterToAdd)
		{
			var newGamePieceObject = Instantiate(_letterPrefab, 
				_lettersParent.transform.position, 
				Quaternion.identity,
				_lettersParent.transform);
			
			var newGamePiece = newGamePieceObject.AddComponent<LetterGamePiece>();
			newGamePiece.CharecterValue = charToAdd;
			
			var gamePieceImage = newGamePiece.GetComponent<Image>();
			gamePieceImage.sprite = ((Characters) _charecterMap).GetCharecterSprite(charToAdd);
		}
	}

	private void OnDestroy()
	{
		WayPointRow.WayPointRowAdded -= WayPointRowAdded;
	}

	private void WayPointRowAdded(WayPointRow newWayPointRow)
	{
		_wayPointRows.Add(newWayPointRow);
	}
	
	

}
