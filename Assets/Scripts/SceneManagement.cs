using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] private string titleName;

    [SerializeField] private string GameName;
    [SerializeField] private Color fadeColor;
    [SerializeField] private float fadeSpeed;

    public enum Scene
    {
        title,
        game
    }
    [SerializeField]
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        if(scene == Scene.title)
        {
            SampleSoundManager.Instance.PlayBgm(BgmType.BGM1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Ontitle()
    {
        Initiate.Fade(titleName, fadeColor, fadeSpeed);
        SampleSoundManager.Instance.PlaySe(SeType.SE9);
        SampleSoundManager.Instance.StopBgm();
    }
    public void Onretry()
    {
        Initiate.Fade(GameName, fadeColor, fadeSpeed);
        SampleSoundManager.Instance.PlaySe(SeType.SE9);
        SampleSoundManager.Instance.StopBgm();
    }
    public void Onretry2()
    {
        Initiate.Fade(GameName, fadeColor, fadeSpeed);
        SampleSoundManager.Instance.PlaySe(SeType.SE1);
        SampleSoundManager.Instance.StopBgm();
    }
}
