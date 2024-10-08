using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nomalbool : MonoBehaviour
{
    WaribasiMove waribasiMove;

    [SerializeField]
  public  SushiChat sushi;

  public  GameManager gameManager;
    // Start is called before the first frame update
    private GameObject collidedObject;
    // Start is called before the first frame update

    TextSpawn textSpawn;
    public static List<Nomalbool> allNomalbools = new List<Nomalbool>(); // 全インスタンスを保持するリスト

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        allNomalbools.Add(this); // インスタンスをリストに追加
        textSpawn = FindObjectOfType<TextSpawn>();
    }

    void OnDestroy()
    {
        allNomalbools.Remove(this); // オブジェクトが破壊された時にリストから削除
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        waribasiMove = collision.GetComponent<WaribasiMove>();
        collidedObject = collision.gameObject;

        if (waribasiMove != null && sushi == waribasiMove.selectedSushi && collision.gameObject.tag == "hasi")
        {
            switch (sushi)
            {
                case SushiChat.maguro:
                    gameManager.OnmaguroNomal = true;
                    break;
                case SushiChat.negitoro:
                    gameManager.OnnegitoroNomal = true;
                    break;
                case SushiChat.ika:
                    gameManager.OnikaNomal = true;
                    break;
                case SushiChat.samon:
                    gameManager.OnsamonNomal = true;
                    break;
                case SushiChat.ebi:
                    gameManager.OnebiNomal = true;
                    break;
                case SushiChat.uni:
                    gameManager.OnuniNomal = true;
                    break;
                case SushiChat.amaebi:
                    gameManager.OnamaebiNomal = true;
                    break;
                case SushiChat.ikura:
                    gameManager.OnikuraNomal = true;
                    break;
                case SushiChat.niku:
                    gameManager.OnnikuNomal = true;
                    break;
                case SushiChat.tamago:
                    gameManager.OntamagoNomal = true;
                    break;
                case SushiChat.tyawan:
                    gameManager.OntyawanNomal = true;
                    break;
                case SushiChat.beel:
                    gameManager.OnbeelNomal = true;
                    break;
            }
        }
    }

    public IEnumerator EfectNomal()
    {
        OnEffect(textSpawn.Good);
        SampleSoundManager.Instance.PlaySe(SeType.SE3);
        yield return new WaitForSeconds(0.1f);

        if (collidedObject != null)
        {
            Destroy(collidedObject);
        }
        if (transform.parent != null)
        {
            Destroy(transform.parent.gameObject);  // 親オブジェクトを削除
        }
        else
        {
            Destroy(gameObject);  // 親がいない場合は自身を削除
        }
    }
    public void DestroyObjects()
    {
        StartCoroutine(EfectNomal());
    }
    public void OnEffect(ParticleSystem effect)
    {

        ParticleSystem newParticle = Instantiate(effect);

        // パーティクルの発生場所をこのスクリプトをアタッチしているGameObjectの場所にする。
        newParticle.transform.position = collidedObject.transform.position;
        // パーティクルを発生させる。
        newParticle.Play();
        // インスタンス化したパーティクルシステムのGameObjectを5秒後に削除する。(任意)
        // ※第一引数をnewParticleだけにするとコンポーネントしか削除されない。
        Destroy(newParticle.gameObject, 5.0f);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (sushi == SushiChat.maguro && collision.gameObject.tag == "hasi")
        {
            gameManager.OnmaguroNomal = false;
        }
        else if (sushi == SushiChat.negitoro && collision.gameObject.tag == "hasi")
        {
            gameManager.OnnegitoroNomal = false;
        }
        else if (sushi == SushiChat.ika && collision.gameObject.tag == "hasi")
        {
            gameManager.OnikaNomal = false;
        }
        else if (sushi == SushiChat.samon && collision.gameObject.tag == "hasi")
        {
            gameManager.OnsamonNomal = false;
        }
        else if (sushi == SushiChat.ebi && collision.gameObject.tag == "hasi")
        {
            gameManager.OnebiNomal = false;
        }
        else if (sushi == SushiChat.uni && collision.gameObject.tag == "hasi")
        {
            gameManager.OnuniNomal = false;
        }
        else if (sushi == SushiChat.amaebi && collision.gameObject.tag == "hasi")
        {
            gameManager.OnamaebiNomal = false;
        }
        else if (sushi == SushiChat.ikura && collision.gameObject.tag == "hasi")
        {
            gameManager.OnikuraNomal = false;
        }
        else if (sushi == SushiChat.niku && collision.gameObject.tag == "hasi")
        {
            gameManager.OnnikuNomal = false;
        }
        else if (sushi == SushiChat.tamago && collision.gameObject.tag == "hasi")
        {
            gameManager.OntamagoNomal = false;
        }
        else if (sushi == SushiChat.tyawan && collision.gameObject.tag == "hasi")
        {
            gameManager.OntyawanNomal = false;
        }
        else if (sushi == SushiChat.beel && collision.gameObject.tag == "hasi")
        {
            gameManager.OnbeelNomal = false;
        }
    }
}
