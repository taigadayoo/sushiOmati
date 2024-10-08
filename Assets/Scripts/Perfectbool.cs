using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perfectbool : MonoBehaviour
{
   
    [SerializeField]
   public SushiChat sushi;

    WaribasiMove waribasiMove;
  public  GameManager gameManager;

    private GameObject collidedObject;
    // Start is called before the first frame update

    public static List<Perfectbool> allPerfectbools = new List<Perfectbool>(); // 全インスタンスを保持するリスト

    TextSpawn textSpawn;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        allPerfectbools.Add(this); // インスタンスをリストに追加
        textSpawn = FindObjectOfType<TextSpawn>();
    }

    void OnDestroy()
    {
        allPerfectbools.Remove(this); // オブジェクトが破壊された時にリストから削除
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
    public IEnumerator EfectPerfect()
    {
        OnEffect(textSpawn.Great);

        SampleSoundManager.Instance.PlaySe(SeType.SE2);
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
  public void  DestroyObjects()
    {
        StartCoroutine(EfectPerfect());
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
