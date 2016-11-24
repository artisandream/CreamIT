using UnityEngine;
using System.Collections;

public class TempTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		print("h");
		SpriteRenderer render = GetComponent<SpriteRenderer>();
		render.color = SetColor.OnSetColor();
	}
}
