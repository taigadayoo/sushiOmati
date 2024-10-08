using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Badbool : MonoBehaviour
{
    WaribasiMove waribasiMove;

    [SerializeField]
   public SushiChat sushi;

   public GameManager gameManager;
    // Start is called before the first frame update
    private GameObject collidedObject;
    // Start is called before the first frame update

    TextSpawn textSpawn;

    public static List<Badbool> allBadbools = new List<Badbool>(); // �S�C���X�^���X��ێ����郊�X�g

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        allBadbools.Add(this); // �C���X�^���X�����X�g�ɒǉ�
        textSpawn = FindObjectOfType<TextSpawn>();
    }

    void OnDestroy()
    {
        allBadbools.Remove(this); // �I�u�W�F�N�g���j�󂳂ꂽ���Ƀ��X�g����폜
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
                    gameManager.OnmaguroBad = true;
                    break;
                case SushiChat.negitoro:
                    gameManager.OnnegitoroBad = true;
                    break;
                case SushiChat.ika:
                    gameManager.OnikaBad = true;
                    break;
                case SushiChat.samon:
                    gameManager.OnsamonBad = true;
                    break;
                case SushiChat.ebi:
                    gameManager.OnebiBad = true;
                    break;
                case SushiChat.uni:
                    gameManager.OnuniBad = true;
                    break;
                case SushiChat.amaebi:
                    gameManager.OnamaebiBad = true;
                    break;
                case SushiChat.ikura:
                    gameManager.OnikuraBad = true;
                    break;
                case SushiChat.niku:
                    gameManager.OnnikuBad = true;
                    break;
                case SushiChat.tamago:
                    gameManager.OntamagoBad = true;
                    break;
                case SushiChat.tyawan:
                    gameManager.OntyawanBad = true;
                    break;
                case SushiChat.beel:
                    gameManager.OnbeelBad = true;
                    break;
            }
        }
    }

    public IEnumerator EfectBad()
    {
        OnEffect(textSpawn.Bad);
        SampleSoundManager.Instance.PlaySe(SeType.SE4);
        yield return new WaitForSeconds(0.1f);

        if (collidedObject != null)
        {
            Destroy(collidedObject);
        }
        if (transform.parent != null)
        {
            Destroy(transform.parent.gameObject);  // �e�I�u�W�F�N�g���폜
        }
        else
        {
            Destroy(gameObject);  // �e�����Ȃ��ꍇ�͎��g���폜
        }
    }
    public void DestroyObjects()
    {
        StartCoroutine(EfectBad());
    }
    public void OnEffect(ParticleSystem effect)
    {

        ParticleSystem newParticle = Instantiate(effect);

        // �p�[�e�B�N���̔����ꏊ�����̃X�N���v�g���A�^�b�`���Ă���GameObject�̏ꏊ�ɂ���B
        newParticle.transform.position = collidedObject.transform.position;
        // �p�[�e�B�N���𔭐�������B
        newParticle.Play();
        // �C���X�^���X�������p�[�e�B�N���V�X�e����GameObject��5�b��ɍ폜����B(�C��)
        // ����������newParticle�����ɂ���ƃR���|�[�l���g�����폜����Ȃ��B
        Destroy(newParticle.gameObject, 5.0f);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (sushi == SushiChat.maguro && collision.gameObject.tag == "hasi")
        {
            gameManager.OnmaguroBad = false;
        }
        else if (sushi == SushiChat.negitoro && collision.gameObject.tag == "hasi")
        {
            gameManager.OnnegitoroBad = false;
        }
        else if (sushi == SushiChat.ika && collision.gameObject.tag == "hasi")
        {
            gameManager.OnikaBad = false;
        }
        else if (sushi == SushiChat.samon && collision.gameObject.tag == "hasi")
        {
            gameManager.OnsamonBad = false;
        }
        else if (sushi == SushiChat.ebi && collision.gameObject.tag == "hasi")
        {
            gameManager.OnebiBad = false;
        }
        else if (sushi == SushiChat.uni && collision.gameObject.tag == "hasi")
        {
            gameManager.OnuniBad = false;
        }
        else if (sushi == SushiChat.amaebi && collision.gameObject.tag == "hasi")
        {
            gameManager.OnamaebiBad = false;
        }
        else if (sushi == SushiChat.ikura && collision.gameObject.tag == "hasi")
        {
            gameManager.OnikuraBad = false;
        }
        else if (sushi == SushiChat.niku && collision.gameObject.tag == "hasi")
        {
            gameManager.OnnikuBad = false;
        }
        else if (sushi == SushiChat.tamago && collision.gameObject.tag == "hasi")
        {
            gameManager.OntamagoBad = false;
        }
        else if (sushi == SushiChat.tyawan && collision.gameObject.tag == "hasi")
        {
            gameManager.OntyawanBad = false;
        }
        else if (sushi == SushiChat.beel && collision.gameObject.tag == "hasi")
        {
            gameManager.OnbeelBad = false;
        }
    }
}
