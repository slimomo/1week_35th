using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("MainSound",1.6f);
    }

    public void MainSound(){
        SoundManager.instance.PlayPanelBGM(0);
    }
}
