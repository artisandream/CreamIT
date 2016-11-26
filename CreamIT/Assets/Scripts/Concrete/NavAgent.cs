using UnityEngine;
public class NavAgent : MonoBehaviour {

	private NavMeshAgent thisAgent;
	void Start () {
		thisAgent = GetComponent<NavMeshAgent>();
	}

	public void ResetAgent (Transform destination) {
		thisAgent.destination = destination.position;
		thisAgent.speed = StaticVars.moveSpeed;
	}

	public void StopAgent () {
		thisAgent.Stop();
	}

}
