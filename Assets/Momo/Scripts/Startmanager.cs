using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startmanager : MonoBehaviour
{
     // Start is called before the first frame update
    void Start()
    {
        Invoke("MainSound",1f);
    }

    public void MainSound(){
        SoundManager.instance.PlayPanelBGM(0);
    }
}
