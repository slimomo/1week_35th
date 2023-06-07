using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
   public Enemy[] m_enemyPrefabs; // 敵のプレハブを管理する配列
   //public Enemy bossEnemy;//ボスのプレファブ
    //public float m_interval; // 出現間隔（秒）
    public float m_intervalFrom; // 出現間隔（秒）（ゲームの経過時間が 0 の時）
    public float m_intervalTo; // 出現間隔（秒）（ゲームの経過時間が m_elapsedTimeMax の時）
    public float m_elapsedTimeMax; // 経過時間の最大値
    public float m_elapsedTime; // 経過時間
    private float m_timer; // 出現タイミングを管理するタイマー
    private bool isBoss;//ボスの出現フラグ
    [SerializeField] private GameObject BossCanvas;
    private bool isEnding;//終わりになったらEnemyの生成はやめる
    [SerializeField] GameObject ClearCanvas;
    [SerializeField] GameObject Player_Moe;

    // 毎フレーム呼び出される関数
    private void Update(){
        if(isEnding)return;
        // 経過時間を更新する
        m_elapsedTime += Time.deltaTime;
        // 出現タイミングを管理するタイマーを更新する
        m_timer += Time.deltaTime;
        // ゲームの経過時間から出現間隔（秒）を算出する
        // ゲームの経過時間が長くなるほど、敵の出現間隔が短くなる
        var t = m_elapsedTime / m_elapsedTimeMax;
        var interval = Mathf.Lerp( m_intervalFrom, m_intervalTo, t );
        // まだ敵が出現するタイミングではない場合、
        // このフレームの処理はここで終える
        if ( m_timer < interval ) return;
     
        m_timer = 0;

        // 出現する敵をランダムに決定する
        var enemyIndex = Random.Range( 0, m_enemyPrefabs.Length );

        // 出現する敵のプレハブを配列から取得する
        var enemyPrefab = m_enemyPrefabs[ enemyIndex ];

        // 敵のゲームオブジェクトを生成する
        var enemy = Instantiate( enemyPrefab );
        //生成したenemyの親にEnemyManagerを設定しておく
        enemy.transform.SetParent(gameObject.transform, false);
        enemy.GetComponent<Enemy>().ExpPlayer =Player_Moe;

        // 敵を画面外のどの位置に出現させるかランダムに決定する
        var respawnType = ( RESPAWN_TYPE )Random.Range( 
            0, ( int )RESPAWN_TYPE.SIZEOF );

        // 敵を初期化する
        enemy.Init( respawnType );

        if(m_elapsedTime >10){

            if (isBoss == true){
                return;}
            // BossCanvasをアクティブにする
            BossCanvas.SetActive(true);
            isBoss = true;
        }
    }
    public void EnemysDestroy(){
        //enemyの生成をやめる
        isEnding = true;
        // EnemyManager の子要素を取得
        int childCount = transform.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            GameObject child = transform.GetChild(i).gameObject;
            Destroy(child);
        }
        Player_Moe.SetActive(false);
        ClearCanvas.SetActive(true);
    }

}
