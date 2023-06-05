using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutObject : MonoBehaviour
{
        void OnTriggerEnter2D(Collider2D other)
    {
        // 当たったオブジェクト全てを消す
        Destroy(other.gameObject);
        print("destroy");
    }

}
