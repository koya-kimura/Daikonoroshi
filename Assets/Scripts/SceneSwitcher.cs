using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // 遷移先のシーン名
    public string sceneName;

    // ボタンが押されたときに呼ばれるメソッド
    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}