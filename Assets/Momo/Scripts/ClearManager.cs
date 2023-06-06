using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearManager : MonoBehaviour
{
      // Start is called before the first frame update
    void Start()
    {
        Invoke("MainSound",0.5f);
    }

    public void MainSound(){
        SoundManager.instance.PlayPanelBGM(3);
    }
}
