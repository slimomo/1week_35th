using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public Image m_hpGauge; // HP ゲージ
    public Image m_expGauge; // 経験値ゲージ

    // 毎フレーム呼び出される関数
    private void Update()
    {
        // プレイヤーを取得する
        var player = Player.m_instance;

        // HP のゲージの表示を更新する
        var hp = player.m_hp;
        var hpMax = player.m_hpMax;
        m_hpGauge.fillAmount = ( float ) hp/ hpMax;

        // 経験値のゲージの表示を更新する
        var exp = player.m_exp;
        var prevNeedExp = player.m_prevNeedExp;
        var needExp = player.m_needExp;
        m_expGauge.fillAmount = 
            ( float )( exp - prevNeedExp ) / ( needExp - prevNeedExp );
    }
}
