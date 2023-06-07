using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public Image m_hpGauge; // HP ゲージ
    public Image m_expGauge; // 経験値ゲージ
    public Text m_levelText;// レベルのテキスト
    //public GameObject Result_Canvas;//ゲームオーバー時に表示する
    public GameObject moePlayer;//プレイヤー
    public Slider ex;//経験値のスライダー
    public Slider life;//ライフのスライダー


    // 毎フレーム呼び出される関数
    private void Update()
    {
        // プレイヤーを取得する
        var player = Player.m_instance;
        // レベルのテキストの表示を更新する
        m_levelText.text = player.m_level.ToString();
        

        // HP のゲージの表示を更新する
        var hp = player.m_hp;
        var hpMax = player.m_hpMax;
        life.value = ( float ) hp/ hpMax;
        //m_hpGauge.fillAmount = ( float ) hp/ hpMax;

        // 経験値のゲージの表示を更新する
        var exp = player.m_exp;
        var prevNeedExp = player.m_prevNeedExp;
        var needExp = player.m_needExp;
        ex.value = ( float )( exp - prevNeedExp ) / ( needExp - prevNeedExp );
        /*
        m_expGauge.fillAmount = 
            ( float )( exp - prevNeedExp ) / ( needExp - prevNeedExp );*/
        
        // レベルのテキストの表示を更新する
        m_levelText.text = player.m_level.ToString();
        //Playerの方に追加してくれてるみたいなので削除
        /*
        // プレイヤーが非表示ならゲームオーバーと表示する
        if(moePlayer.activeSelf == false){
            gameOverCanvas.SetActive(true);
        }*/
    }
}
