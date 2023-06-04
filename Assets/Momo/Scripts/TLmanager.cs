using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class TLmanager : MonoBehaviour
{
   [SerializeField] private PlayableDirector PD;
    [SerializeField] private double restartTime;
    [SerializeField] private double skipTime;

    bool looping;


    void Start()
    {
        PD = GetComponent<PlayableDirector>();
        looping = true;
    }

    //loop from the time as you wish
    public void ReplayFromStart()
    {
        if (looping)
        {
            PD.time = restartTime;
        }
    }

    //skip to another frame
    public void SkipOne()
    {
        looping = false;
        PD.time = skipTime;
    }

    public void resetLoop()
    {
        looping = true;
    }
}
