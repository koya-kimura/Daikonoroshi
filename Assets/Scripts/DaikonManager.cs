using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DaikonManager : MonoBehaviour
{
    private Vector3 screenPoint;
    private float previousXPosition;

    void Start()
    {
        // 初期化時に現在のX座標を保存
        previousXPosition = transform.position.x;
    }

    void Update()
    {
        // オブジェクトのワールド座標をスクリーン座標に変換
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        // マウスのスクリーン座標を取得し、ワールド座標に変換
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // 前のフレームとのX座標の差分を計算
        float deltaX = worldPosition.x - previousXPosition;

        // オブジェクトの位置を更新
        transform.position = new Vector3(worldPosition.x, transform.position.y, transform.position.z);

        // オブジェクトのYスケールを差分だけ低くする
        Vector3 newScale = transform.localScale;
        newScale.y -= Mathf.Abs(deltaX) * 0.001f; // 差分の絶対値だけ高さを低くする
        
        // スケールが0未満にならないように制御
        if (newScale.y < 0)
        {
            newScale.y = 0;
        }
        
        transform.localScale = newScale;

        // 現在のX座標を次のフレームのために保存
        previousXPosition = worldPosition.x;
    }
}