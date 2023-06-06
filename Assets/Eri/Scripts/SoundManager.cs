using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    //--シングルトン終わり--

    public AudioSource audioSourceBGM; // BGMのスピーカー
    public AudioClip[] audioClipsBGM;  // BGMの素材
    public AudioSource audioSourceSE; // SEのスピーカー
    public AudioClip[] audioClipsSE; //SEの素材
      /*BGM種類について
    0.スタート画面
    1.ゲーム画面　通常
    2.ゲーム画面　ボスが出てきた時
    3.ゲームクリア
    クリア・ゲームオーバー時はBGMストップでいいでしょうかね？
    */

    /*SE種類について
    0.プレイヤーがレベルアップした時
    1.プレイヤーがダメージを受けた時
    2.敵を倒した時
    3.宝石を取った時
    4.ゲームオーバー時
    5.ボタン音
    6.キャンセル音
    7.画面遷移音

    */

    public void PlayPanelBGM(int Scene)
    {
        audioSourceBGM.Stop();
        switch (Scene)
        {
            default:
            case 0:
                audioSourceBGM.clip = audioClipsBGM[0];
               
                break;
            case 1:
                audioSourceBGM.clip = audioClipsBGM[1];
                
                break;
            case 2:
                audioSourceBGM.clip = audioClipsBGM[2];
               
                break;
            case 3:
                audioSourceBGM.clip = audioClipsBGM[3];
                
                break;

            
        }
        audioSourceBGM.Play();
    }

   

    public void StopSE()
    {
        audioSourceSE.Stop();
        //Debug.Log("stopSE");
    }
    
    public void PlaySE(int index)
    {
        audioSourceSE.PlayOneShot(audioClipsSE[index]); // SEを一度だけならす
        //Debug.Log("Se");
    }
    
    public void BGMmute(){
        audioSourceBGM.mute = true;
    }
    
    public void UnmuteBGM(){
        audioSourceBGM.mute = false;
    }
    
    public void SEmute(){
        audioSourceSE.mute = true;
    }
    
    public void UnmuteSE(){
        audioSourceSE.mute = false;
    }

}