using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatNort : MonoBehaviour
{
    // �I�����ꂽ���i��ێ����邽�߂̃t�B�[���h
    [SerializeField]
    public SushiChat selectedSushi;

    // ���݂̎��i��ێ����邽�߂̃t�B�[���h
    public SushiChat currentSushi;
    // GameManager�̃C���X�^���X��ێ����邽�߂̃t�B�[���h
    GameManager gameManager;

    // Start���\�b�h�̓Q�[���I�u�W�F�N�g���L���ɂȂ����Ƃ��ɌĂяo�����
    void Start()
    {
        // ���݂̎��i��I�����ꂽ���i�ŏ�����
        currentSushi = selectedSushi;
        // GameManager�̃C���X�^���X���擾
        gameManager = FindObjectOfType<GameManager>();
        // DestroyChat�R���[�`�����J�n
        StartCoroutine(DestroyChat());
    }

    // ���i�`���b�g����莞�Ԍ�ɍ폜���邽�߂̃R���[�`��
    IEnumerator DestroyChat()
    {
        // 7�b�ԑҋ@
        yield return new WaitForSeconds(7f);
        // ���̃Q�[���I�u�W�F�N�g���폜
        Destroy(this.gameObject);
    }
}
