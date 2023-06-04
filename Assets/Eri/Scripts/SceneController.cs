using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

public void TitleScene(){
    SceneManager.LoadScene("Test_Title");
}

public void MainScene(){
    SceneManager.LoadScene("Main");
    print("main");
}
public void ClearScene(){
    SceneManager.LoadScene("Test_Clear");
}

}
