using UnityEngine;

public class ResetAssetColorer : MonoBehaviour, IReset {

	public Animator thisAnims;

	public void Start () {
		thisAnims.SetBool("Reset", false);
		thisAnims = GetComponent<Animator>();
		RunGame.ResetLevel += OnReset;
		RunGame.RestartLevel += OnRestart;
	}
	
	public virtual void OnReset()
    {
        thisAnims.SetBool("Reset", true);
    } 

	public virtual void OnRestart()
    {
        thisAnims.SetBool("Reset", false);
    }
}
