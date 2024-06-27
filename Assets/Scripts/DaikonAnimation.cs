using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DaikonAnimation : MonoBehaviour
{
    public Text angleXText; // X軸の角度を表示するテキスト
    public Text angleYText; // Y軸の角度を表示するテキスト
    public Text angleZText; // Z軸の角度を表示するテキスト
    
    public float rotationSpeed = 10.0f; // 回転速度
    public float noiseScale = 1.0f; // ノイズのスケール
    private float noiseOffsetX; // X軸のノイズオフセット
    private float noiseOffsetY; // Y軸のノイズオフセット
    private float noiseOffsetZ; // Z軸のノイズオフセット

    void Start()
    {
        // ノイズのオフセットをランダムに初期化
        noiseOffsetX = Random.Range(0.0f, 100.0f);
        noiseOffsetY = Random.Range(0.0f, 100.0f);
        noiseOffsetZ = Random.Range(0.0f, 100.0f);
    }

    void Update()
    {
        // 時間に基づいてノイズを生成
        float noiseX = Mathf.PerlinNoise(Time.time * noiseScale, noiseOffsetX);
        float noiseY = Mathf.PerlinNoise(Time.time * noiseScale, noiseOffsetY);
        float noiseZ = Mathf.PerlinNoise(Time.time * noiseScale, noiseOffsetZ);

        // ノイズを回転角度に変換
        float angleX = noiseX * 360.0f;
        float angleY = noiseY * 360.0f;
        float angleZ = noiseZ * 360.0f;

        // 回転をスムーズに適用
        Quaternion targetRotation = Quaternion.Euler(angleX, angleY, angleZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        
        // 角度をテキストに表示
        angleXText.text = "X: " + angleX.ToString("F2");
        angleYText.text = "Y: " + angleY.ToString("F2");
        angleZText.text = "Z: " + angleZ.ToString("F2");
    }
}