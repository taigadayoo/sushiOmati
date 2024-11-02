using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perfectbool : MonoBehaviour
{
    // �ΏۂƂȂ���i�̃f�[�^
    [SerializeField]
    public SushiChat sushi;

    // WaribasiMove �R���|�[�l���g�̎Q��
    WaribasiMove waribasiMove;

    // �Q�[���}�l�[�W���[�̎Q��
    public GameManager gameManager;

    // �Փ˂����I�u�W�F�N�g��ێ�
    private GameObject collidedObject;

    // �S�C���X�^���X��ێ����郊�X�g
    public static List<Perfectbool> allPerfectbools = new List<Perfectbool>();

    // �e�L�X�g�\���p�̃X�N���v�g
    TextSpawn textSpawn;

    // Start is called before the first frame update
    void Start()
    {
        // GameManager�̃C���X�^���X���擾
        gameManager = FindObjectOfType<GameManager>();
        // ���̃C���X�^���X�����X�g�ɒǉ�
        allPerfectbools.Add(this);
        // TextSpawn�R���|�[�l���g���擾
        textSpawn = FindObjectOfType<TextSpawn>();
    }

    // �I�u�W�F�N�g���j�󂳂ꂽ���Ƀ��X�g����폜
    void OnDestroy()
    {
        allPerfectbools.Remove(this);
    }

    // �I�u�W�F�N�g���g���K�[�ɓ����Ă���Ԃ̏���
    private void OnTriggerStay2D(Collider2D collision)
    {
        // �Փ˂����I�u�W�F�N�g��WaribasiMove�R���|�[�l���g���擾
        waribasiMove = collision.GetComponent<WaribasiMove>();
        collidedObject = collision.gameObject;

        // ���i����v���A�^�O�� "hasi" �̏ꍇ
        if (waribasiMove != null && sushi == waribasiMove.selectedSushi && collision.gameObject.tag == "hasi")
        {
            // ���i�̎�ނɉ����ăQ�[���}�l�[�W���[�̏�Ԃ��X�V
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

    // �p�[�t�F�N�g���̃G�t�F�N�g����
    public IEnumerator EfectPerfect()
    {
        // �G�t�F�N�g��\��
        OnEffect(textSpawn.Great);

        // ���ʉ����Đ�
        SampleSoundManager.Instance.PlaySe(SeType.SE2);
        yield return new WaitForSeconds(0.1f);

        // �Փ˂����I�u�W�F�N�g���폜
        if (collidedObject != null)
        {
            Destroy(collidedObject);
        }

        // �e�I�u�W�F�N�g���폜�A�e�����Ȃ��ꍇ�͎��g���폜
        if (transform.parent != null)
        {
            Destroy(transform.parent.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // �I�u�W�F�N�g���폜���郁�\�b�h
    public void DestroyObjects()
    {
        StartCoroutine(EfectPerfect());
    }

    // �p�[�e�B�N���G�t�F�N�g��\��
    public void OnEffect(ParticleSystem effect)
    {
        // �p�[�e�B�N���̃C���X�^���X���쐬
        ParticleSystem newParticle = Instantiate(effect);
        // �p�[�e�B�N���̔����ꏊ��ݒ�
        newParticle.transform.position = collidedObject.transform.position;
        // �p�[�e�B�N�����Đ�
        newParticle.Play();
        // �p�[�e�B�N���V�X�e����5�b��ɍ폜
        Destroy(newParticle.gameObject, 5.0f);
    }

    // �I�u�W�F�N�g���g���K�[����o���Ƃ��̏���
    private void OnTriggerExit2D(Collider2D collision)
    {
        // ���i�̎�ނɉ����ăQ�[���}�l�[�W���[�̏�Ԃ����Z�b�g
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
