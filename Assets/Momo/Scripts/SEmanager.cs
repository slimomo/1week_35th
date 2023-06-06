using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEmanager : MonoBehaviour
{
   
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
    

}
