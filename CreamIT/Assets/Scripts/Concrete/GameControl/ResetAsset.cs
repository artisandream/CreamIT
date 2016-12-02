using UnityEngine;

public class ResetAsset : MonoBehaviour {
	public Animator thisAnims;
	public GameObject ender;
	public GameObject recycler;

	void Start () {
		ResetGame.ResetLevel += OnResetAsset;
		thisAnims.SetBool("Reset", false);
		thisAnims = GetComponent<Animator>();
	}

    public virtual void OnResetAsset()
    {
		ender.SetActive(true);
        recycler.SetActive(false);
        thisAnims.SetBool("Reset", true);
    }
}
