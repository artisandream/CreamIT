﻿using System.Collections;
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

	private void Awake()
	{
		WayPointRow.WayPointRowAdded += WayPointRowAdded;

		StartCoroutine(SpawnNewWord());
	}

	private IEnumerator SpawnNewWord()
	{
		while (true)
		{
			yield return new WaitForSeconds(2.5f);
			
			var wordCount = Random.Range(3, 7);
			Debug.Log("SpawnNewWord: " + wordCount);
			StartCoroutine(SpawnNewPiece(wordCount));
		}
	}

	private IEnumerator SpawnNewPiece(int wordLength)
	{
		while (wordLength > 0)
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
			//Char 'a' - 'z' is 97 - 122
			var randomChar = (char)Random.Range(97, 122);

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
