using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using DG.Tweening;//DOTween

public class Gem : MonoBehaviour
{
    public int m_exp; // 取得できる経験値
    public float m_brake = 0.9f; // 散らばる時の減速量、数値が小さいほどすぐ減速する

    private Vector3 m_direction; // 散らばる時の進行方向
    private float m_speed; // 散らばる時の速さ
    // プレイヤーを追尾する時の加速度、数値が大きいほどすぐ加速する
    public float m_followAccel = 0.01f;
    private bool m_isFollow; // プレイヤーを追尾するモードに入った場合 true
    private float m_followSpeed; // プレイヤーを追尾する速さ
    public Transform sliderexTransform; // SliderexのTransform

    void Awake(){
        GameObject sliderexObject = GameObject.FindGameObjectWithTag("sliderEX");
        
        if (sliderexObject != null)
        {
            sliderexTransform = sliderexObject.transform;
        }
        else
        {
            print("sliderEX見つからない");
        }
    }

    private void Start()
    {
        // Gemの現在の位置からSliderexの位置までのパスを作成
        Vector3[] path = { transform.position, sliderexTransform.position };

        // パスの移動にかかる時間やイージングなどのオプションを設定
        float duration = 2.0f; // 移動にかかる時間
        Ease easeType = Ease.OutQuart; // イージングの種類

        // パスの移動アニメーションを実行し、終了時にDestroyする
        transform.DOPath(path, duration, PathType.CatmullRom)
            .SetEase(easeType)
            .SetLink(gameObject)
            .OnComplete(() => DestroyGem());
    }

    void DestroyGem(){
        Destroy(gameObject);
    }
    /*
    // 毎フレーム呼び出される関数
    private void Update()
    {
        // プレイヤーの現在地を取得する
        var playerPos = Player.m_instance.transform.localPosition;
        
        // プレイヤーと宝石の距離を計算する
        var distance = Vector3.Distance( playerPos, transform.localPosition );
        // プレイヤーと宝石の距離が近づいた場合
        
        if ( distance < Player.m_instance.m_magnetDistance ){
    // プレイヤーを追尾するモードに入る
    m_isFollow = true;
    }
    // プレイヤーを追尾するモードに入っている場合かつ
    // プレイヤーがまだ死亡していない場合
    if ( m_isFollow && Player.m_instance.gameObject.activeSelf )
    {
    // プレイヤーの現在位置へ向かうベクトルを作成する
    var direction = playerPos - transform.localPosition;
    direction.Normalize();

    // 宝石をプレイヤーが存在する方向に移動する
    transform.localPosition += direction * m_followSpeed;

    // 加速しながら近づく
    m_followSpeed += m_followAccel;
    return;
    }
        // 散らばる速度を計算する
        var velocity = m_direction * m_speed;

        // 散らばる
        transform.localPosition += velocity;

        // だんだん減速する
        m_speed *= m_brake;

        // 宝石が画面外に出ないように位置を制限する
        transform.localPosition = 
            Utils.ClampPosition( transform.localPosition );
    }
    */

    // 宝石が出現する時に初期化する関数
    public void Init( int score, float speedMin, float speedMax )
    {
        // 宝石がどの方向に散らばるかランダムに決定する
        var angle = Random.Range( 0, 360 );

        // 進行方向をラジアン値に変換する
        var f = angle * Mathf.Deg2Rad;

        // 進行方向のベクトルを作成する
        m_direction = new Vector3( Mathf.Cos( f ), Mathf.Sin( f ), 0 );

        // 宝石の散らばる速さをランダムに決定する
        m_speed = Mathf.Lerp( speedMin, speedMax, Random.value );

        // 8 秒後に宝石を削除する
        //Destroy( gameObject, 2 );
    }
    /*
    // 他のオブジェクトと衝突した時に呼び出される関数
    private void OnTriggerEnter2D( Collider2D collision )
    {
    // 衝突したオブジェクトがプレイヤーではない場合は無視する
    if ( !collision.name.Contains( "Player" ) ) return;
    //Enemy.csで経験値は処理する
    /*
    // プレイヤーの経験値を増やす
    var player = collision.GetComponent<Player>();
    player.AddExp( m_exp );

    SoundManager.instance.PlaySE(3);
    
    // 宝石を削除する
    Destroy( gameObject );
    }*/
}
