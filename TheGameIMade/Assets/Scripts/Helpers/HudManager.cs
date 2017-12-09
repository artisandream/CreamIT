using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
	[SerializeField] private Text _wordDefinitionText;

	// Use this for initialization
	private void Start()
	{
		SpawnManager.DefinitionChanged += DefinitionChanged;
	}

	private void DefinitionChanged(string newDefinition)
	{
		_wordDefinitionText.DOText(newDefinition, 0.75f, false, ScrambleMode.Lowercase, newDefinition);
	}

	// Update is called once per frame
	private void OnDestroy()
	{
		SpawnManager.DefinitionChanged -= DefinitionChanged;
	}
}
