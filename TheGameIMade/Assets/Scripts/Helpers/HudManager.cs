using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
	[SerializeField] private Text _wordDefinitionText;

	private void Awake()
	{
		SpawnManager.DefinitionChanged += DefinitionChanged;
	}

	private void OnDestroy()
	{
		SpawnManager.DefinitionChanged -= DefinitionChanged;
	}

	private void DefinitionChanged(string newDefinition)
	{
		_wordDefinitionText.DOText(newDefinition, 0.75f, false, ScrambleMode.Lowercase, newDefinition);
	}
	
}
