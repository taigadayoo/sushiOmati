using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatNort : MonoBehaviour
{
    // 選択された寿司を保持するためのフィールド
    [SerializeField]
    public SushiChat selectedSushi;

    // 現在の寿司を保持するためのフィールド
    public SushiChat currentSushi;
    // GameManagerのインスタンスを保持するためのフィールド
    GameManager gameManager;

    // Startメソッドはゲームオブジェクトが有効になったときに呼び出される
    void Start()
    {
        // 現在の寿司を選択された寿司で初期化
        currentSushi = selectedSushi;
        // GameManagerのインスタンスを取得
        gameManager = FindObjectOfType<GameManager>();
        // DestroyChatコルーチンを開始
        StartCoroutine(DestroyChat());
    }

    // 寿司チャットを一定時間後に削除するためのコルーチン
    IEnumerator DestroyChat()
    {
        // 7秒間待機
        yield return new WaitForSeconds(7f);
        // このゲームオブジェクトを削除
        Destroy(this.gameObject);
    }
}
