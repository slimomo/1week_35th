using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//unity eventを使うために必要
using UnityEngine.Events;


public class StartEvent : MonoBehaviour
{
    //unity eventを使うために必要
    [SerializeField] private UnityEvent startEvent;

    // Start is called before the first frame update
    void Start()
    {
        startEvent?.Invoke();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
