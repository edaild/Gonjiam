using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class characterKillerContoroller : MonoBehaviour
{
    public float killer_Speed;
    public float killer_RotageSpeed;
    public Transform killer_SponPoint;
    public Transform playerTarget;
    public AudioClip killerAudioClipMuisic;
    public AudioClip killerAudioClipEffect;
    public Animator killerAnimator;

    private NavMeshAgent navMeshAgent;


    // Start is called before the first frame update
    void Start()
    {
        killerAudioClipMuisic = GetComponent<AudioClip>();
        killerAudioClipEffect = GetComponent<AudioClip>();

        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = killer_Speed;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TargetPlayer();
        }
        else
        {
            StartCoroutine(SponPoint());
        }
    }

    void TargetPlayer()
    {
        
        navMeshAgent.SetDestination(playerTarget.position);
        killerAnimator.SetBool("isRun", true);

    }

    IEnumerator SponPoint()
    {
        yield return new WaitForSeconds(30f);

        navMeshAgent.SetDestination(killer_SponPoint.position);
        killerAnimator.SetBool("isRun", true);
    }

    void Die()
    {
        killerAnimator.SetBool("isDie", true);
    }
}