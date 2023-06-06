using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEmanager : MonoBehaviour
{
    public void SEGameOver()
    {
        SoundManager.instance.PlaySE(4);
    }
    
    public void SEButton()
    {

        SoundManager.instance.PlaySE(5);
    }

    public void SECancel()
    {

        SoundManager.instance.PlaySE(6);
    }

    public void SETransition()
    {

        SoundManager.instance.PlaySE(7);
    }
     public void SEAllClear()
    {

        SoundManager.instance.PlaySE(8);
    }

}
