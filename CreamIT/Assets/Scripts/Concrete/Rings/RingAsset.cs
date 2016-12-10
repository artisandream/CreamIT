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
        ColorTrigger.AddSpeedOnTrigger += ResetSpeed;
        RunGame.ResetWave += OnReset;
        RunGame.RestartWave += OnRestart;
        RunGame.SetSpeed += ResetSpeed;
        RunGame.OnModSpeed += ResetSpeed;
    }

    private void ResetSpeed(float obj)
    {
        thisAgent.speed = obj;
    }

    public void OnSet(Transform destination)
    {
        thisAgent.destination = destination.position;
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
