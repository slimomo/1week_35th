using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIE : MonoBehaviour
{
   
     //n秒後に消す
    [SerializeField] private float destroyTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyCoroutine());
    }


    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(destroyTime);
        //Destroy(gameObject);
        this.gameObject.SetActive(false);

    }


}
