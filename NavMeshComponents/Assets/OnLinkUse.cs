using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class OnLinkUse : MonoBehaviour
{
    public NavMeshLink link;
    public NavMeshAgent agent;
    private bool traversedLink = false;
    private bool traversedLinkOld = false;

    private bool enteredLink;
    public bool EnteredLink
    {
        get { return enteredLink; }
        set
        {
            enteredLink = value;
            if (value == true)
            {
                OnEnterLink();
            }

        }
    }

    private bool exitedLink;
    public bool ExitedLink
    {
        get { return exitedLink; }
        set
        {
            exitedLink = value;
            if (value == true)
            {
                OnExitLink();
            }
        }
    }

    private bool onFrontPlatform = true;

    private void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {
        if (agent.isOnOffMeshLink)
        {
            traversedLink = true;
        }
        else
        {
            if (traversedLink)
            {
                traversedLink = false;
                EnteredLink = false;
                ExitedLink = false;
            }
        }

        if (traversedLink != traversedLinkOld)
        {
            if (traversedLink) EnteredLink = true;
            else ExitedLink = true;
            traversedLinkOld = traversedLink;
        }
    }

    private void OnEnterLink()
    {
        agent.speed = 100f;
        agent.acceleration = 100f;
        agent.gameObject.GetComponent<Renderer>().enabled = false;

    }

    private void OnExitLink()
    {
        agent.gameObject.GetComponent<Renderer>().enabled = true;
        agent.velocity = Vector3.zero;
        agent.speed = 5;
        agent.acceleration = 30f;
        onFrontPlatform = !onFrontPlatform;
        //agent.transform.localScale = onFrontPlatform ? new Vector3(1f, 1f, 1f) : new Vector3(.25f, .25f, .25f);
    }
}
