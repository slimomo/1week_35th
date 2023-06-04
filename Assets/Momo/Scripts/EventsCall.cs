using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//unity eventを使うために必要
using UnityEngine.Events;


public class EventsCall : MonoBehaviour
{

    //unity eventを使うために必要
    [SerializeField] private UnityEvent m_event;

    //unity eventを使うために必要
    public void CallEvent()
    {
        m_event?.Invoke();
    }

}
