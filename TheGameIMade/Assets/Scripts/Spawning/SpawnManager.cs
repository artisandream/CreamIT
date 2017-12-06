using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
	private List<WayPointRow> _wayPointRows = new List<WayPointRow>();
	
	[SerializeField] private GameObject _startPoint;
	[SerializeField] private WayPoint _endWayPoint;
	[SerializeField] private GameObject _gamePiecePrefab;
	[SerializeField] private ScriptableObject _charecterMap;
	[SerializeField] private ScriptableObject _wordsMap;

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
		var wordLength = newWord.Key.Length - 1;
		
		while (wordLength >= 0)
		{
			yield return new WaitForSeconds(0.5f);
					
			var newGamePieceObject = Instantiate(_gamePiecePrefab, _startPoint.transform.position, Quaternion.identity, _startPoint.transform);
			var newGamePiece = newGamePieceObject.AddComponent<GamePiece>();
			
			foreach (var wayPointRow in _wayPointRows)
			{
				var wayPoint = wayPointRow.GetRandomWayPoint();
				newGamePiece.AddWayPoint(wayPoint);
			}
			
			newGamePiece.AddWayPoint(_endWayPoint);

			var gamePieceImage = newGamePiece.GetComponent<Image>();
			var randomChar = newWord.Key[wordLength];

			gamePieceImage.sprite = ((Characters) _charecterMap).GetCharecterSprite(randomChar);
			
			newGamePiece.MoveNextWayPoint();
			
			wordLength--;
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
