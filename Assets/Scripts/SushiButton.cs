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
            if (perfectbool.gameManager.OnmaguroPerfect && perfectbool.sushi == SushiChat.maguro && sushi == Sushi.maguro)//例）押されたのがマグロの時のパーフェクト処理判定
            {
                Debug.Log("完璧 (maguro)");
                perfectbool.DestroyObjects();
                gameManager.AddTime(addTime);
                gameManager.AddScore(scoreAdd);
                break;
            }
            else if (perfectbool.gameManager.OnnegitoroPerfect && perfectbool.sushi == SushiChat.negitoro && sushi == Sushi.negitoro)//以下からも同様の処理
            {
                Debug.Log("完璧 (negitoro)");
                perfectbool.DestroyObjects();
                gameManager.AddTime(addTime);
                gameManager.AddScore(scoreAdd);
                break;
            }
            else if (perfectbool.gameManager.OnikaPerfect && perfectbool.sushi == SushiChat.ika && sushi == Sushi.ika)
            {
                Debug.Log("完璧 (ika)");
                perfectbool.DestroyObjects();
                gameManager.AddTime(addTime);
                gameManager.AddScore(scoreAdd);
                break;
            }
            else if (perfectbool.gameManager.OnsamonPerfect && perfectbool.sushi == SushiChat.samon && sushi == Sushi.samon)
            {
                Debug.Log("完璧 (samon)");
                perfectbool.DestroyObjects();
                gameManager.AddTime(addTime);
                gameManager.AddScore(scoreAdd);
                break;
            }
            else if (perfectbool.gameManager.OnebiPerfect && perfectbool.sushi == SushiChat.ebi && sushi == Sushi.ebi)
            {
                Debug.Log("完璧 (ebi)");
                perfectbool.DestroyObjects();
                gameManager.AddTime(addTime);
                gameManager.AddScore(scoreAdd);
                break;
            }
            else if (perfectbool.gameManager.OnuniPerfect && perfectbool.sushi == SushiChat.uni && sushi == Sushi.uni)
            {
                Debug.Log("完璧 (uni)");
                perfectbool.DestroyObjects();
                gameManager.AddTime(addTime);
                gameManager.AddScore(scoreAdd);
                break;
            }
            else if (perfectbool.gameManager.OnamaebiPerfect && perfectbool.sushi == SushiChat.amaebi && sushi == Sushi.amaebi)
            {
                Debug.Log("完璧 (amaebi)");
                perfectbool.DestroyObjects();
                gameManager.AddTime(addTime);
                gameManager.AddScore(scoreAdd);
                break;
            }
            else if (perfectbool.gameManager.OnikuraPerfect && perfectbool.sushi == SushiChat.ikura && sushi == Sushi.ikura)
            {
                Debug.Log("完璧 (ikura)");
                perfectbool.DestroyObjects();
                gameManager.AddTime(addTime);
                gameManager.AddScore(scoreAdd);
                break;
            }
            else if (perfectbool.gameManager.OnnikuPerfect && perfectbool.sushi == SushiChat.niku && sushi == Sushi.niku)
            {
                Debug.Log("完璧 (niku)");
                perfectbool.DestroyObjects();
                gameManager.AddTime(addTime);
                gameManager.AddScore(scoreAdd);
                break;
            }
            else if (perfectbool.gameManager.OntamagoPerfect && perfectbool.sushi == SushiChat.tamago && sushi == Sushi.tamago)
            {
                Debug.Log("完璧 (tamago)");
                perfectbool.DestroyObjects();
                gameManager.AddTime(addTime);
                gameManager.AddScore(scoreAdd);
                break;
            }
            else if (perfectbool.gameManager.OntyawanPerfect && perfectbool.sushi ==  SushiChat.tyawan && sushi == Sushi.tyawan)
            {
                Debug.Log("完璧 (tyawan)");
                perfectbool.DestroyObjects();
                gameManager.AddTime(addTime);
                gameManager.AddScore(scoreAdd);
                break;
            }
            else if (perfectbool.gameManager.OnbeelPerfect && perfectbool.sushi ==  SushiChat.beel && sushi == Sushi.beel)
            {
                Debug.Log("完璧 (beel)");
                perfectbool.DestroyObjects();
                gameManager.AddTime(addTime);
                gameManager.AddScore(scoreAdd);
                break;
            }
            else
            {
                Debug.Log("関係ないの押すな");
                //SampleSoundManager.Instance.PlaySe(SeType.SE4);
                gameManager.subtractTime(minusTime);
                break;
            }

        }
        foreach (Nomalbool nomalbool in Nomalbool.allNomalbools)
        {
            if (nomalbool.gameManager.OnmaguroNomal && nomalbool.sushi == SushiChat.maguro && sushi == Sushi.maguro)
            {
                Debug.Log("普通 (maguro)");
                nomalbool.DestroyObjects();
                gameManager.AddTime(addNomalTime);
                gameManager.AddScore(scoreNomalAdd);
                break;
            }
            else if (nomalbool.gameManager.OnnegitoroNomal && nomalbool.sushi == SushiChat.negitoro && sushi == Sushi.negitoro)
            {
                Debug.Log("普通 (negitoro)");
                nomalbool.DestroyObjects();
                gameManager.AddTime(addNomalTime);
                gameManager.AddScore(scoreNomalAdd);
                break;
            }
            else if (nomalbool.gameManager.OnikaNomal && nomalbool.sushi == SushiChat.ika && sushi == Sushi.ika)
            {
                Debug.Log("普通 (ika)");
                nomalbool.DestroyObjects();
                gameManager.AddTime(addNomalTime);
                gameManager.AddScore(scoreNomalAdd);
                break;
            }
            else if (nomalbool.gameManager.OnsamonNomal && nomalbool.sushi == SushiChat.samon && sushi == Sushi.samon)
            {
                Debug.Log("普通 (samon)");
                nomalbool.DestroyObjects();
                gameManager.AddTime(addNomalTime);
                gameManager.AddScore(scoreNomalAdd);
                break;
            }
            else if (nomalbool.gameManager.OnebiNomal && nomalbool.sushi == SushiChat.ebi && sushi == Sushi.ebi)
            {
                Debug.Log("普通 (ebi)");
                nomalbool.DestroyObjects();
                gameManager.AddTime(addNomalTime);
                gameManager.AddScore(scoreNomalAdd);
                break;
            }
            else if (nomalbool.gameManager.OnuniNomal && nomalbool.sushi == SushiChat.uni && sushi == Sushi.uni)
            {
                Debug.Log("普通 (uni)");
                nomalbool.DestroyObjects();
                gameManager.AddTime(addNomalTime);
                gameManager.AddScore(scoreNomalAdd);
                break;
            }
            else if (nomalbool.gameManager.OnamaebiNomal && nomalbool.sushi == SushiChat.amaebi && sushi == Sushi.amaebi)
            {
                Debug.Log("普通 (amaebi)");
                nomalbool.DestroyObjects();
                gameManager.AddTime(addNomalTime);
                gameManager.AddScore(scoreNomalAdd);
                break;
            }
            else if (nomalbool.gameManager.OnikuraNomal && nomalbool.sushi == SushiChat.ikura && sushi == Sushi.ikura)
            {
                Debug.Log("普通 (ikura)");
                nomalbool.DestroyObjects();
                gameManager.AddTime(addNomalTime);
                gameManager.AddScore(scoreNomalAdd);
                break;
            }
            else if (nomalbool.gameManager.OnnikuNomal && nomalbool.sushi == SushiChat.niku && sushi == Sushi.niku)
            {
                Debug.Log("普通 (niku)");
                nomalbool.DestroyObjects();
                gameManager.AddTime(addNomalTime);
                gameManager.AddScore(scoreNomalAdd);
                break;
            }
            else if (nomalbool.gameManager.OntamagoNomal && nomalbool.sushi == SushiChat.tamago && sushi == Sushi.tamago)
            {
                Debug.Log("普通 (tamago)");
                nomalbool.DestroyObjects();
                gameManager.AddTime(addNomalTime);
                gameManager.AddScore(scoreNomalAdd);
                break;
            }
            else if (nomalbool.gameManager.OntyawanNomal && nomalbool.sushi == SushiChat.tyawan && sushi == Sushi.tyawan)
            {
                Debug.Log("普通 (tyawan)");
                nomalbool.DestroyObjects();
                gameManager.AddTime(addNomalTime);
                gameManager.AddScore(scoreNomalAdd);
                break;
            }
            else if (nomalbool.gameManager.OnbeelNomal && nomalbool.sushi == SushiChat.beel && sushi == Sushi.beel)
            {
                Debug.Log("普通 (beel)");
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
                Debug.Log("ダメ (maguro)");
                badbool.DestroyObjects();
                gameManager.subtractTime(minusTime);
                break;
            }
            else if (badbool.gameManager.OnnegitoroBad && badbool.sushi == SushiChat.negitoro && sushi == Sushi.negitoro)
            {
                Debug.Log("ダメ (negitoro)");
                badbool.DestroyObjects();
                gameManager.subtractTime(minusTime);
                break;
            }
            else if (badbool.gameManager.OnikaBad && badbool.sushi == SushiChat.ika && sushi == Sushi.ika)
            {
                Debug.Log("ダメ (ika)");
                badbool.DestroyObjects();
                gameManager.subtractTime(minusTime);
                break;
            }
            else if (badbool.gameManager.OnsamonBad && badbool.sushi == SushiChat.samon && sushi == Sushi.samon)
            {
                Debug.Log("ダメ (samon)");
                badbool.DestroyObjects();
                gameManager.subtractTime(minusTime);
                break;
            }
            else if (badbool.gameManager.OnebiBad && badbool.sushi == SushiChat.ebi && sushi == Sushi.ebi)
            {
                Debug.Log("ダメ (ebi)");
                badbool.DestroyObjects();
                gameManager.subtractTime(minusTime);
                break;
            }
            else if (badbool.gameManager.OnuniBad && badbool.sushi == SushiChat.uni && sushi == Sushi.uni)
            {
                Debug.Log("ダメ (uni)");
                badbool.DestroyObjects();
                gameManager.subtractTime(minusTime);
                break;
            }
            else if (badbool.gameManager.OnamaebiBad && badbool.sushi == SushiChat.amaebi && sushi == Sushi.amaebi)
            {
                Debug.Log("ダメ (amaebi)");
                badbool.DestroyObjects();
                gameManager.subtractTime(minusTime);
                break;
            }
            else if (badbool.gameManager.OnikuraBad && badbool.sushi == SushiChat.ikura && sushi == Sushi.ikura)
            {
                Debug.Log("ダメ (ikura)");
                badbool.DestroyObjects();
                gameManager.subtractTime(minusTime);
                break;
            }
            else if (badbool.gameManager.OnnikuNomal && badbool.sushi == SushiChat.niku && sushi == Sushi.niku)
            {
                Debug.Log("ダメ (niku)");
                badbool.DestroyObjects();
                gameManager.subtractTime(minusTime);
                break;
            }
            else if (badbool.gameManager.OntamagoBad && badbool.sushi == SushiChat.tamago && sushi == Sushi.tamago)
            {
                Debug.Log("ダメ (tamago)");
                badbool.DestroyObjects();
                gameManager.subtractTime(minusTime);
                break;
            }
            else if (badbool.gameManager.OntyawanBad && badbool.sushi == SushiChat.tyawan && sushi == Sushi.tyawan)
            {
                Debug.Log("ダメ (tyawan)");
                badbool.DestroyObjects();
                gameManager.subtractTime(minusTime);
                break;
            }
            else if (badbool.gameManager.OnbeelBad && badbool.sushi == SushiChat.beel && sushi == Sushi.beel)
            {
                Debug.Log("ダメ (beel)");
                badbool.DestroyObjects();
                gameManager.subtractTime(minusTime);
                break;
            }
          
        }
    }
}


