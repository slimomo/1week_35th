using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
  // 移動可能な範囲 Spriteのサイズに応じて調整する
    public static Vector2 m_moveLimit = new Vector2( 6.0f, 2.8f );

    // 指定された位置を移動可能な範囲に収めた値を返す Player.csが参照する
    public static Vector3 ClampPosition( Vector3 position )
    {
        return new Vector3
        (
            Mathf.Clamp( position.x, -m_moveLimit.x, m_moveLimit.x ),
            Mathf.Clamp( position.y, -m_moveLimit.y, m_moveLimit.y ),
            0
        );
    }

    	// 指定された 2 つの位置から角度を求めて返す
	public static float GetAngle( Vector2 from, Vector2 to )
	{
		var dx  = to.x - from.x;
		var dy  = to.y - from.y;
		var rad = Mathf.Atan2( dy, dx );
		return rad * Mathf.Rad2Deg;
	}
    
    public static Vector3 GetDirection( float angle )
    {
    return new Vector3
    (
        Mathf.Cos( angle * Mathf.Deg2Rad ),
        Mathf.Sin( angle * Mathf.Deg2Rad ),
        0
    );
}
}
