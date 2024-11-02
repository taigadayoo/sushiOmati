using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiButton : MonoBehaviour
{
    TextSpawn textSpawn;
    public enum Sushi
    {
        maguro,
        negitoro,
        ika,
        samon,
        ebi,
        uni,
        amaebi,
        ikura,
        niku,
        tamago,
        tyawan,
        beel,
    }
    public float addTime = 8f;
    public float addNomalTime = 5f;
    public float minusTime = 3f;
    public int scoreAdd = 400;
    public int scoreNomalAdd = 200;
    [SerializeField]
    Sushi sushi;

    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        textSpawn = FindObjectOfType<TextSpawn>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnSushi()
    {
        foreach (Perfectbool perfectbool in Perfectbool.allPerfectbools)
        {
            if (perfectbool.gameManager.OnmaguroPerfect && perfectbool.sushi == SushiChat.maguro && sushi == Sushi.maguro)//��j�����ꂽ�̂��}�O���̎��̃p�[�t�F�N�g��������
            {
                Debug.Log("���� (maguro)");
                perfectbool.DestroyObjects();
                gameManager.AddTime(addTime);
                gameManager.AddScore(scoreAdd);
                break;
            }
            else if (perfectbool.gameManager.OnnegitoroPerfect && perfectbool.sushi == SushiChat.negitoro && sushi == Sushi.negitoro)//�ȉ���������l�̏���
            {
                Debug.Log("���� (negitoro)");
                perfectbool.DestroyObjects();
                gameManager.AddTime(addTime);
                gameManager.AddScore(scoreAdd);
                break;
            }
            else if (perfectbool.gameManager.OnikaPerfect && perfectbool.sushi == SushiChat.ika && sushi == Sushi.ika)
            {
                Debug.Log("���� (ika)");
                perfectbool.DestroyObjects();
                gameManager.AddTime(addTime);
                gameManager.AddScore(scoreAdd);
                break;
            }
            else if (perfectbool.gameManager.OnsamonPerfect && perfectbool.sushi == SushiChat.samon && sushi == Sushi.samon)
            {
                Debug.Log("���� (samon)");
                perfectbool.DestroyObjects();
                gameManager.AddTime(addTime);
                gameManager.AddScore(scoreAdd);
                break;
            }
            else if (perfectbool.gameManager.OnebiPerfect && perfectbool.sushi == SushiChat.ebi && sushi == Sushi.ebi)
            {
                Debug.Log("���� (ebi)");
                perfectbool.DestroyObjects();
                gameManager.AddTime(addTime);
                gameManager.AddScore(scoreAdd);
                break;
            }
            else if (perfectbool.gameManager.OnuniPerfect && perfectbool.sushi == SushiChat.uni && sushi == Sushi.uni)
            {
                Debug.Log("���� (uni)");
                perfectbool.DestroyObjects();
                gameManager.AddTime(addTime);
                gameManager.AddScore(scoreAdd);
                break;
            }
            else if (perfectbool.gameManager.OnamaebiPerfect && perfectbool.sushi == SushiChat.amaebi && sushi == Sushi.amaebi)
            {
                Debug.Log("���� (amaebi)");
                perfectbool.DestroyObjects();
                gameManager.AddTime(addTime);
                gameManager.AddScore(scoreAdd);
                break;
            }
            else if (perfectbool.gameManager.OnikuraPerfect && perfectbool.sushi == SushiChat.ikura && sushi == Sushi.ikura)
            {
                Debug.Log("���� (ikura)");
                perfectbool.DestroyObjects();
                gameManager.AddTime(addTime);
                gameManager.AddScore(scoreAdd);
                break;
            }
            else if (perfectbool.gameManager.OnnikuPerfect && perfectbool.sushi == SushiChat.niku && sushi == Sushi.niku)
            {
                Debug.Log("���� (niku)");
                perfectbool.DestroyObjects();
                gameManager.AddTime(addTime);
                gameManager.AddScore(scoreAdd);
                break;
            }
            else if (perfectbool.gameManager.OntamagoPerfect && perfectbool.sushi == SushiChat.tamago && sushi == Sushi.tamago)
            {
                Debug.Log("���� (tamago)");
                perfectbool.DestroyObjects();
                gameManager.AddTime(addTime);
                gameManager.AddScore(scoreAdd);
                break;
            }
            else if (perfectbool.gameManager.OntyawanPerfect && perfectbool.sushi ==  SushiChat.tyawan && sushi == Sushi.tyawan)
            {
                Debug.Log("���� (tyawan)");
                perfectbool.DestroyObjects();
                gameManager.AddTime(addTime);
                gameManager.AddScore(scoreAdd);
                break;
            }
            else if (perfectbool.gameManager.OnbeelPerfect && perfectbool.sushi ==  SushiChat.beel && sushi == Sushi.beel)
            {
                Debug.Log("���� (beel)");
                perfectbool.DestroyObjects();
                gameManager.AddTime(addTime);
                gameManager.AddScore(scoreAdd);
                break;
            }
            else
            {
                Debug.Log("�֌W�Ȃ��̉�����");
                //SampleSoundManager.Instance.PlaySe(SeType.SE4);
                gameManager.subtractTime(minusTime);
                break;
            }

        }
        foreach (Nomalbool nomalbool in Nomalbool.allNomalbools)
        {
            if (nomalbool.gameManager.OnmaguroNomal && nomalbool.sushi == SushiChat.maguro && sushi == Sushi.maguro)
            {
                Debug.Log("���� (maguro)");
                nomalbool.DestroyObjects();
                gameManager.AddTime(addNomalTime);
                gameManager.AddScore(scoreNomalAdd);
                break;
            }
            else if (nomalbool.gameManager.OnnegitoroNomal && nomalbool.sushi == SushiChat.negitoro && sushi == Sushi.negitoro)
            {
                Debug.Log("���� (negitoro)");
                nomalbool.DestroyObjects();
                gameManager.AddTime(addNomalTime);
                gameManager.AddScore(scoreNomalAdd);
                break;
            }
            else if (nomalbool.gameManager.OnikaNomal && nomalbool.sushi == SushiChat.ika && sushi == Sushi.ika)
            {
                Debug.Log("���� (ika)");
                nomalbool.DestroyObjects();
                gameManager.AddTime(addNomalTime);
                gameManager.AddScore(scoreNomalAdd);
                break;
            }
            else if (nomalbool.gameManager.OnsamonNomal && nomalbool.sushi == SushiChat.samon && sushi == Sushi.samon)
            {
                Debug.Log("���� (samon)");
                nomalbool.DestroyObjects();
                gameManager.AddTime(addNomalTime);
                gameManager.AddScore(scoreNomalAdd);
                break;
            }
            else if (nomalbool.gameManager.OnebiNomal && nomalbool.sushi == SushiChat.ebi && sushi == Sushi.ebi)
            {
                Debug.Log("���� (ebi)");
                nomalbool.DestroyObjects();
                gameManager.AddTime(addNomalTime);
                gameManager.AddScore(scoreNomalAdd);
                break;
            }
            else if (nomalbool.gameManager.OnuniNomal && nomalbool.sushi == SushiChat.uni && sushi == Sushi.uni)
            {
                Debug.Log("���� (uni)");
                nomalbool.DestroyObjects();
                gameManager.AddTime(addNomalTime);
                gameManager.AddScore(scoreNomalAdd);
                break;
            }
            else if (nomalbool.gameManager.OnamaebiNomal && nomalbool.sushi == SushiChat.amaebi && sushi == Sushi.amaebi)
            {
                Debug.Log("���� (amaebi)");
                nomalbool.DestroyObjects();
                gameManager.AddTime(addNomalTime);
                gameManager.AddScore(scoreNomalAdd);
                break;
            }
            else if (nomalbool.gameManager.OnikuraNomal && nomalbool.sushi == SushiChat.ikura && sushi == Sushi.ikura)
            {
                Debug.Log("���� (ikura)");
                nomalbool.DestroyObjects();
                gameManager.AddTime(addNomalTime);
                gameManager.AddScore(scoreNomalAdd);
                break;
            }
            else if (nomalbool.gameManager.OnnikuNomal && nomalbool.sushi == SushiChat.niku && sushi == Sushi.niku)
            {
                Debug.Log("���� (niku)");
                nomalbool.DestroyObjects();
                gameManager.AddTime(addNomalTime);
                gameManager.AddScore(scoreNomalAdd);
                break;
            }
            else if (nomalbool.gameManager.OntamagoNomal && nomalbool.sushi == SushiChat.tamago && sushi == Sushi.tamago)
            {
                Debug.Log("���� (tamago)");
                nomalbool.DestroyObjects();
                gameManager.AddTime(addNomalTime);
                gameManager.AddScore(scoreNomalAdd);
                break;
            }
            else if (nomalbool.gameManager.OntyawanNomal && nomalbool.sushi == SushiChat.tyawan && sushi == Sushi.tyawan)
            {
                Debug.Log("���� (tyawan)");
                nomalbool.DestroyObjects();
                gameManager.AddTime(addNomalTime);
                gameManager.AddScore(scoreNomalAdd);
                break;
            }
            else if (nomalbool.gameManager.OnbeelNomal && nomalbool.sushi == SushiChat.beel && sushi == Sushi.beel)
            {
                Debug.Log("���� (beel)");
                nomalbool.DestroyObjects();
                gameManager.AddTime(addNomalTime);
                gameManager.AddScore(scoreNomalAdd);
                break;
            }
          
        }
        foreach (Badbool badbool in Badbool.allBadbools)
        {
            if (badbool.gameManager.OnmaguroBad && badbool.sushi == SushiChat.maguro && sushi == Sushi.maguro)
            {
                Debug.Log("�_�� (maguro)");
                badbool.DestroyObjects();
                gameManager.subtractTime(minusTime);
                break;
            }
            else if (badbool.gameManager.OnnegitoroBad && badbool.sushi == SushiChat.negitoro && sushi == Sushi.negitoro)
            {
                Debug.Log("�_�� (negitoro)");
                badbool.DestroyObjects();
                gameManager.subtractTime(minusTime);
                break;
            }
            else if (badbool.gameManager.OnikaBad && badbool.sushi == SushiChat.ika && sushi == Sushi.ika)
            {
                Debug.Log("�_�� (ika)");
                badbool.DestroyObjects();
                gameManager.subtractTime(minusTime);
                break;
            }
            else if (badbool.gameManager.OnsamonBad && badbool.sushi == SushiChat.samon && sushi == Sushi.samon)
            {
                Debug.Log("�_�� (samon)");
                badbool.DestroyObjects();
                gameManager.subtractTime(minusTime);
                break;
            }
            else if (badbool.gameManager.OnebiBad && badbool.sushi == SushiChat.ebi && sushi == Sushi.ebi)
            {
                Debug.Log("�_�� (ebi)");
                badbool.DestroyObjects();
                gameManager.subtractTime(minusTime);
                break;
            }
            else if (badbool.gameManager.OnuniBad && badbool.sushi == SushiChat.uni && sushi == Sushi.uni)
            {
                Debug.Log("�_�� (uni)");
                badbool.DestroyObjects();
                gameManager.subtractTime(minusTime);
                break;
            }
            else if (badbool.gameManager.OnamaebiBad && badbool.sushi == SushiChat.amaebi && sushi == Sushi.amaebi)
            {
                Debug.Log("�_�� (amaebi)");
                badbool.DestroyObjects();
                gameManager.subtractTime(minusTime);
                break;
            }
            else if (badbool.gameManager.OnikuraBad && badbool.sushi == SushiChat.ikura && sushi == Sushi.ikura)
            {
                Debug.Log("�_�� (ikura)");
                badbool.DestroyObjects();
                gameManager.subtractTime(minusTime);
                break;
            }
            else if (badbool.gameManager.OnnikuNomal && badbool.sushi == SushiChat.niku && sushi == Sushi.niku)
            {
                Debug.Log("�_�� (niku)");
                badbool.DestroyObjects();
                gameManager.subtractTime(minusTime);
                break;
            }
            else if (badbool.gameManager.OntamagoBad && badbool.sushi == SushiChat.tamago && sushi == Sushi.tamago)
            {
                Debug.Log("�_�� (tamago)");
                badbool.DestroyObjects();
                gameManager.subtractTime(minusTime);
                break;
            }
            else if (badbool.gameManager.OntyawanBad && badbool.sushi == SushiChat.tyawan && sushi == Sushi.tyawan)
            {
                Debug.Log("�_�� (tyawan)");
                badbool.DestroyObjects();
                gameManager.subtractTime(minusTime);
                break;
            }
            else if (badbool.gameManager.OnbeelBad && badbool.sushi == SushiChat.beel && sushi == Sushi.beel)
            {
                Debug.Log("�_�� (beel)");
                badbool.DestroyObjects();
                gameManager.subtractTime(minusTime);
                break;
            }
          
        }
    }
}


