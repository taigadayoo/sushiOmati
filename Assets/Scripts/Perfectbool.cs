using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perfectbool : MonoBehaviour
{
    // 対象となる寿司のデータ
    [SerializeField]
    public SushiChat sushi;

    // WaribasiMove コンポーネントの参照
    WaribasiMove waribasiMove;

    // ゲームマネージャーの参照
    public GameManager gameManager;

    // 衝突したオブジェクトを保持
    private GameObject collidedObject;

    // 全インスタンスを保持するリスト
    public static List<Perfectbool> allPerfectbools = new List<Perfectbool>();

    // テキスト表示用のスクリプト
    TextSpawn textSpawn;

    // Start is called before the first frame update
    void Start()
    {
        // GameManagerのインスタンスを取得
        gameManager = FindObjectOfType<GameManager>();
        // このインスタンスをリストに追加
        allPerfectbools.Add(this);
        // TextSpawnコンポーネントを取得
        textSpawn = FindObjectOfType<TextSpawn>();
    }

    // オブジェクトが破壊された時にリストから削除
    void OnDestroy()
    {
        allPerfectbools.Remove(this);
    }

    // オブジェクトがトリガーに入っている間の処理
    private void OnTriggerStay2D(Collider2D collision)
    {
        // 衝突したオブジェクトのWaribasiMoveコンポーネントを取得
        waribasiMove = collision.GetComponent<WaribasiMove>();
        collidedObject = collision.gameObject;

        // 寿司が一致し、タグが "hasi" の場合
        if (waribasiMove != null && sushi == waribasiMove.selectedSushi && collision.gameObject.tag == "hasi")
        {
            // 寿司の種類に応じてゲームマネージャーの状態を更新
            switch (sushi)
            {
                case SushiChat.maguro:
                    gameManager.OnmaguroPerfect = true;
                    break;
                case SushiChat.negitoro:
                    gameManager.OnnegitoroPerfect = true;
                    break;
                case SushiChat.ika:
                    gameManager.OnikaPerfect = true;
                    break;
                case SushiChat.samon:
                    gameManager.OnsamonPerfect = true;
                    break;
                case SushiChat.ebi:
                    gameManager.OnebiPerfect = true;
                    break;
                case SushiChat.uni:
                    gameManager.OnuniPerfect = true;
                    break;
                case SushiChat.amaebi:
                    gameManager.OnamaebiPerfect = true;
                    break;
                case SushiChat.ikura:
                    gameManager.OnikuraPerfect = true;
                    break;
                case SushiChat.niku:
                    gameManager.OnnikuPerfect = true;
                    break;
                case SushiChat.tamago:
                    gameManager.OntamagoPerfect = true;
                    break;
                case SushiChat.tyawan:
                    gameManager.OntyawanPerfect = true;
                    break;
                case SushiChat.beel:
                    gameManager.OnbeelPerfect = true;
                    break;
            }
        }
    }

    // パーフェクト時のエフェクト処理
    public IEnumerator EfectPerfect()
    {
        // エフェクトを表示
        OnEffect(textSpawn.Great);

        // 効果音を再生
        SampleSoundManager.Instance.PlaySe(SeType.SE2);
        yield return new WaitForSeconds(0.1f);

        // 衝突したオブジェクトを削除
        if (collidedObject != null)
        {
            Destroy(collidedObject);
        }

        // 親オブジェクトを削除、親がいない場合は自身を削除
        if (transform.parent != null)
        {
            Destroy(transform.parent.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // オブジェクトを削除するメソッド
    public void DestroyObjects()
    {
        StartCoroutine(EfectPerfect());
    }

    // パーティクルエフェクトを表示
    public void OnEffect(ParticleSystem effect)
    {
        // パーティクルのインスタンスを作成
        ParticleSystem newParticle = Instantiate(effect);
        // パーティクルの発生場所を設定
        newParticle.transform.position = collidedObject.transform.position;
        // パーティクルを再生
        newParticle.Play();
        // パーティクルシステムを5秒後に削除
        Destroy(newParticle.gameObject, 5.0f);
    }

    // オブジェクトがトリガーから出たときの処理
    private void OnTriggerExit2D(Collider2D collision)
    {
        // 寿司の種類に応じてゲームマネージャーの状態をリセット
        if (sushi == SushiChat.maguro && collision.gameObject.tag == "hasi")
        {
            gameManager.OnmaguroPerfect = false;
        }
        else if (sushi == SushiChat.negitoro && collision.gameObject.tag == "hasi")
        {
            gameManager.OnnegitoroPerfect = false;
        }
        else if (sushi == SushiChat.ika && collision.gameObject.tag == "hasi")
        {
            gameManager.OnikaPerfect = false;
        }
        else if (sushi == SushiChat.samon && collision.gameObject.tag == "hasi")
        {
            gameManager.OnsamonPerfect = false;
        }
        else if (sushi == SushiChat.ebi && collision.gameObject.tag == "hasi")
        {
            gameManager.OnebiPerfect = false;
        }
        else if (sushi == SushiChat.uni && collision.gameObject.tag == "hasi")
        {
            gameManager.OnuniPerfect = false;
        }
        else if (sushi == SushiChat.amaebi && collision.gameObject.tag == "hasi")
        {
            gameManager.OnamaebiPerfect = false;
        }
        else if (sushi == SushiChat.ikura && collision.gameObject.tag == "hasi")
        {
            gameManager.OnikuraPerfect = false;
        }
        else if (sushi == SushiChat.niku && collision.gameObject.tag == "hasi")
        {
            gameManager.OnnikuPerfect = false;
        }
        else if (sushi == SushiChat.tamago && collision.gameObject.tag == "hasi")
        {
            gameManager.OntamagoPerfect = false;
        }
        else if (sushi == SushiChat.tyawan && collision.gameObject.tag == "hasi")
        {
            gameManager.OntyawanPerfect = false;
        }
        else if (sushi == SushiChat.beel && collision.gameObject.tag == "hasi")
        {
            gameManager.OnbeelPerfect = false;
        }
    }
}
