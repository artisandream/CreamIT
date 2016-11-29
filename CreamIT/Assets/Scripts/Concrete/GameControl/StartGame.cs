using UnityEngine;

public class StartGame : MonoBehaviour {

	public float generateTime = 2f;
	public float moveSpeed = 3.5f;
	void Start () {
		StaticVars.generateTime = generateTime;
		StaticVars.moveSpeed = moveSpeed;
	}
}
