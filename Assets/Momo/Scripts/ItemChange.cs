using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChange : MonoBehaviour
{
    [SerializeField] private GameObject objOld;
    [SerializeField] private GameObject objNew;
    
   

    public void itemChange()
    {

        objOld.SetActive(false);
        objNew.SetActive(true);
    }

}
