using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaribasiMove : MonoBehaviour
{
    // �I�u�W�F�N�g�̈ړ����x
    public float speed = 5f;

    // �I�����ꂽ���i�̃f�[�^
    public SushiChat selectedSushi;

    // Start is called before the first frame update
    void Start()
    {
        // �I�����ꂽ���i���f�o�b�O���O�ɏo��
        Debug.Log(selectedSushi);
    }

    // Update is called once per frame
    void Update()
    {
        // �I�u�W�F�N�g���E�����Ɉړ�������
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // ���̃I�u�W�F�N�g���Z��̒��ōŌ�ɔz�u����
        transform.SetAsLastSibling();
    }
}
