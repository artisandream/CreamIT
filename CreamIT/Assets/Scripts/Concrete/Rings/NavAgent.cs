using UnityEngine;
public class NavAgent : MonoBehaviour {

	private NavMeshAgent thisAgent;
	void Start () {
		thisAgent = GetComponent<NavMeshAgent>();
		StartGame.OnModGame += OnModGameHandler;
	}

    private void OnModGameHandler()
    {
        thisAgent.speed = StaticVars.moveSpeed;
    }

    public void OnSet (Transform destination) {
		thisAgent.destination = destination.position;
		thisAgent.speed = StaticVars.moveSpeed;
		thisAgent.Resume();
	}

	public void StopAgent () {
		thisAgent.Stop();
	}

}
