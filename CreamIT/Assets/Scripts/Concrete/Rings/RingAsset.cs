using UnityEngine;
using System;
public class RingAsset : MonoBehaviour, IReset
{

    public static Action<RingAsset> SendToGenerator;
    public SpriteRenderer blankCenter;
    public Material black;
    public GameObject ender;
    public GameObject recycler;
	public Animator animator;

    private UnityEngine.AI.NavMeshAgent thisAgent;
    public void Start()
    {
        thisAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        RunGame.OnModGame += OnModGameHandler;
        RunGame.ResetLevel += OnReset;
        RunGame.RestartLevel += OnRestart;
    }

    private void OnModGameHandler(LevelObject currentLevel)
    {
        thisAgent.speed = currentLevel.ringMoveSpeed += currentLevel.ringAddSpeed;
    }

    public void OnSet(Transform destination, LevelObject currentLevel)
    {
        thisAgent.destination = destination.position;
        thisAgent.speed = currentLevel.ringMoveSpeed;
        thisAgent.Resume();
    }

    public void StopAgent()
    {
        thisAgent.Stop();
    }

    public void OnSetColor()
    {
        ender.SetActive(false);
        recycler.SetActive(true);
    }

    public void OnRestart()
    {
		blankCenter.material = black;
        StopAgent();
        SendToGenerator(this);
        ender.SetActive(true);
        recycler.SetActive(false);
		animator.SetBool("Reset", false);
    }

    public void OnReset()
    {
        animator.SetBool("Reset", true);
    }
}
