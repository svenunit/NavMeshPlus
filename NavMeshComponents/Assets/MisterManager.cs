using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MisterManager : MonoBehaviour
{
    public NavMeshLink[] links;
    public ParticleSystemPair[] particleSystemPairs;

    private void Awake()
    {

    }

    void Start()
    {
        MarkLinkLocations();
    }

    void Update()
    {

    }

    private void MarkLinkLocations()
    {
        for (int i = 0; i < links.Length; i++)
        {
            particleSystemPairs[i].particleSystem1.transform.localPosition = links[i].transform.position + links[i].startPoint;
            particleSystemPairs[i].particleSystem2.transform.localPosition = links[i].transform.position + links[i].endPoint;
        }
    }
}

[System.Serializable]
public class ParticleSystemPair
{
    public ParticleSystem particleSystem1;
    public ParticleSystem particleSystem2;
}
