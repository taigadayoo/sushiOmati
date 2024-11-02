using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaribasiMove : MonoBehaviour
{
    // オブジェクトの移動速度
    public float speed = 5f;

    // 選択された寿司のデータ
    public SushiChat selectedSushi;

    // Start is called before the first frame update
    void Start()
    {
        // 選択された寿司をデバッグログに出力
        Debug.Log(selectedSushi);
    }

    // Update is called once per frame
    void Update()
    {
        // オブジェクトを右方向に移動させる
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // このオブジェクトを兄弟の中で最後に配置する
        transform.SetAsLastSibling();
    }
}
