using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
	private List<WayPointRow> _wayPointRows = new List<WayPointRow>();
	
	[SerializeField] private GameObject _startPoint;
	[SerializeField] private WayPoint _endWayPoint;
	[SerializeField] private GameObject _gamePiecePrefab;
	[SerializeField] private GameObject _lettersToUse;
	[SerializeField] private ScriptableObject _charecterMap;
	[SerializeField] private ScriptableObject _wordsMap;

	public static UnityAction<string> DefinitionChanged;
	private void Awake()
	{
		WayPointRow.WayPointRowAdded += WayPointRowAdded;

		StartCoroutine(SpawnNewWord());
	}

	private IEnumerator SpawnNewWord()
	{
		while (true)
		{
			yield return new WaitForSeconds(5.0f);
			
			var wordCount = (WordCount)Random.Range(0, 7);
			Debug.Log("SpawnNewWord: " + wordCount);
			StartCoroutine(SpawnNewPiece(wordCount));
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
			yield return new WaitForSeconds(0.5f);
					
			var newGamePieceObject = Instantiate(_gamePiecePrefab, 
				_startPoint.transform.position, 
				Quaternion.identity, 
				_startPoint.transform);
			var newGamePiece = newGamePieceObject.AddComponent<GamePiece>();
			
			foreach (var wayPointRow in _wayPointRows)
			{
				var wayPoint = wayPointRow.GetRandomWayPoint();
				newGamePiece.AddWayPoint(wayPoint);
			}
			
			newGamePiece.AddWayPoint(_endWayPoint);

			var gamePieceImage = newGamePiece.GetComponent<Image>();
			gamePieceImage.sprite = ((Characters) _charecterMap).GetCharecterSprite(wordChar);
			
			newGamePiece.MoveNextWayPoint();
		}
	}

	private void PopulateLetterToPlayWith(string word)
	{
		//Remove letters from last word
		foreach (Transform childTransform in _lettersToUse.transform)
		{
			Destroy(childTransform.gameObject);
		}
		
		var letterToAdd = word.ToList();
		
		//ASCII values for a-z in 97 - 122
		letterToAdd.Add((char)Random.Range(97, 123));
		letterToAdd.Add((char)Random.Range(97, 123));

		//"Shuffle" the list
		letterToAdd = letterToAdd.OrderBy(a => Random.Range(0, 100)).ToList();

		foreach (var charToAdd in letterToAdd)
		{
			var newGamePieceObject = Instantiate(_gamePiecePrefab, 
				_lettersToUse.transform.position, 
				Quaternion.identity,
				_lettersToUse.transform);
			var newGamePiece = newGamePieceObject.AddComponent<GamePiece>();
			
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
