using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class GameManager : MonoBehaviour
{
    public bool Onmaguro = false;
    public bool Onnegitoro = false;
    public bool Onika = false;
    public bool Onsamon = false;
    public bool Onebi = false;
    public bool Onuni = false;
    public bool Onamaebi = false;
    public bool Onikura = false;
    public bool Onniku = false;
    public bool Ontamago = false;
    public bool Ontyawan = false;
    public bool Onbeel = false;

    public bool OnmaguroPerfect = false;
    public bool OnnegitoroPerfect = false;
    public bool OnikaPerfect = false;
    public bool OnsamonPerfect = false;
    public bool OnebiPerfect = false;
    public bool OnuniPerfect = false;
    public bool OnamaebiPerfect = false;
    public bool OnikuraPerfect = false;
    public bool OnnikuPerfect = false;
    public bool OntamagoPerfect = false;
    public bool OntyawanPerfect = false;
    public bool OnbeelPerfect = false;

    public bool OnmaguroNomal = false;
    public bool OnnegitoroNomal = false;
    public bool OnikaNomal = false;
    public bool OnsamonNomal = false;
    public bool OnebiNomal = false;
    public bool OnuniNomal = false;
    public bool OnamaebiNomal = false;
    public bool OnikuraNomal = false;
    public bool OnnikuNomal = false;
    public bool OntamagoNomal = false;
    public bool OntyawanNomal = false;
    public bool OnbeelNomal = false;

    public bool OnmaguroBad = false;
    public bool OnnegitoroBad = false;
    public bool OnikaBad = false;
    public bool OnsamonBad = false;
    public bool OnebiBad = false;
    public bool OnuniBad = false;
    public bool OnamaebiBad = false;
    public bool OnikuraBad = false;
    public bool OnnikuBad = false;
    public bool OntamagoBad = false;
    public bool OntyawanBad = false;
    public bool OnbeelBad = false;

    public Text countdownText; // �J�E���g�_�E����\������Text�R���|�[�l���g
    public int countdownStartValue = 3; // �J�E���g�_�E���̊J�n�l
    public float countdownInterval = 1f; // �J�E���g�_�E���̊Ԋu�i�b�j
    public bool gameStart = false;

    public Text timerText; // �^�C�}�[�̕\���pText�R���|�[�l���g
    public float startTime = 30f; // �^�C�}�[�̊J�n���ԁi�b�j

    private float currentTime;
    private bool isTimerRunning = false;
    public GameObject sokomade;

    public Text scoreText;
    public Text lastScore;
    // ���݂̃X�R�A
    private int score = 0;
    public GameObject scorePanel;
    public RectTransform rectTransform;

    public bool gameFinish = false;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartCountdown());
        currentTime = startTime;
        UpdateScoreText();
        SampleSoundManager.Instance.PlayBgm(BgmType.BGM2);
    }

    // Update is called once per frame
    void Update()
    {
      lastScore.text = score.ToString() + "�~";
        if (isTimerRunning)
        {
            // �^�C�}�[��0�ȏ�̂Ƃ��J�E���g�_�E��
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                UpdateTimerText();
            }
            else if(currentTime <= 0)
            {
                // �^�C�}�[��0�ɂȂ������~
                currentTime = 0;
                isTimerRunning = false;
                UpdateTimerText();
                StartCoroutine(scoreAnim());
                gameFinish = true;
            }
        }
    }
    private IEnumerator StartCountdown()
    {
        int countdownValue = countdownStartValue;

        while (countdownValue > 0)
        {
            SampleSoundManager.Instance.PlaySe(SeType.SE6);
            countdownText.text = countdownValue.ToString(); // ������Text�ɕ\��
            yield return new WaitForSeconds(countdownInterval); // �w�肵���Ԋu�ҋ@
            countdownValue--; // �J�E���g�����炷
        }

        // �J�E���g�_�E���I����ɁuGo!�v��uStart!�v�Ȃǂ̃��b�Z�[�W��\��
        countdownText.text = "�n��!";
        SampleSoundManager.Instance.PlaySe(SeType.SE7);
        // �K�v�ɉ����āA���̌�ɑ��̃A�N�V������ǉ��ł��܂�
        yield return new WaitForSeconds(1f);

        Destroy(countdownText);
        StartCoroutine(StartTimer());
        gameStart = true;
    }
    private IEnumerator StartTimer()
    {
        isTimerRunning = true;
        yield return null; // �����Ƀ^�C�}�[���J�n
    }

    private void UpdateTimerText()
    {
        // �b�������̂܂ܕ\��
        int seconds = Mathf.CeilToInt(currentTime);
        timerText.text = seconds.ToString();
    }

    // ���Ԃ����Z����֐�
    public void AddTime(float additionalTime)
    {
        currentTime += additionalTime;
        // �^�C�}�[�����Z��ɍēx���삷��悤��
        if (currentTime > 0 && !isTimerRunning)
        {
            isTimerRunning = true;
        }
        UpdateTimerText();
    }
    public void subtractTime(float subtractTime)
    {
        currentTime -= subtractTime;
        // �^�C�}�[��0�����ɂȂ�Ȃ��悤�ɂ���
        if (currentTime < 0)
        {
            currentTime = 0;
            //isTimerRunning = false;
        }
        UpdateTimerText();
    }
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        scoreText.text = score.ToString() + "�~" ;
    }
    IEnumerator scoreAnim()
    {
        sokomade.SetActive(true);
        SampleSoundManager.Instance.PlaySe(SeType.SE5);
        yield return new WaitForSeconds(1.5f);
        SampleSoundManager.Instance.PlaySe(SeType.SE8);
        rectTransform.DOAnchorPos(new Vector2(0f, 0f), 1f);
    }
}
