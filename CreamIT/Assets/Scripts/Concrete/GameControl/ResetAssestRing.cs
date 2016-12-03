using UnityEngine;

public class ResetAssestRing : ResetAssetColorer, IReset {

	public GameObject ender;
	public GameObject recycler;

    public override void OnRestart()
    {
		base.OnRestart();
    }

    public override void OnReset()
    {
		base.OnReset();
		ender.SetActive(true);
        recycler.SetActive(false);
    }
}
