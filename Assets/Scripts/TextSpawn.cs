using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSpawn : MonoBehaviour
{
    public List<GameObject> objectsToSpawn; // �X�|�[��������I�u�W�F�N�g�̃��X�g
    public List<float> spawnPositionX; // �X�|�[��������I�u�W�F�N�g�̃��X�g
    public GameObject secondObjectToSpawn; // 1�b��ɃX�|�[��������ʂ̃I�u�W�F�N�g
    public float minSpawnInterval = 2f; // �X�|�[���Ԋu�̍ŏ��l�i�b�j
    public float maxSpawnInterval = 4f; // �X�|�[���Ԋu�̍ő�l�i�b�j
    public float minX = -5f; // x���̍ŏ��l�i���[���h���W�j
    public float maxX = 5f; // x���̍ő�l�i���[���h���W�j
    public float yPos = 0f; // �Œ��y���ʒu�i���[���h���W�j
    public Transform parentTransform; // �X�|�[��������I�u�W�F�N�g�̐e��Transform
    public Vector3 secondObjectPosition; // 1�b��ɃX�|�[��������I�u�W�F�N�g�̃��[���h���W

    private GameObject oldestSpawnedObject; // ��ԌÂ��I�u�W�F�N�g���L�^���邽�߂̕ϐ�
    private GameObject secondOldestSpawnedObject; // ��ԌÂ�secondSpawnedObject���L�^���邽�߂̕ϐ�
    private GameObject oldestSecondSpawnedObject; // ��ԌÂ�1�b��ɃX�|�[������I�u�W�F�N�g
    private GameObject secondOldestSecondSpawnedObject; // ��ԖڂɌÂ�1�b��ɃX�|�[������I�u�W�F�N�g
    private int lastSpawnIndex = -1; // �O��̃X�|�[���ʒu�C���f�b�N�X
    private SushiChat currentSushiType;
    private bool oneStart = false;
    GameManager gameManager;
    [SerializeField]
    [Tooltip("����������G�t�F�N�g(�p�[�e�B�N��)")]
    public ParticleSystem Great;
    [SerializeField]
    [Tooltip("����������G�t�F�N�g(�p�[�e�B�N��)")]
    public ParticleSystem Good;
    [SerializeField]
    [Tooltip("����������G�t�F�N�g(�p�[�e�B�N��)")]
    public ParticleSystem Bad;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (gameManager.gameStart && !oneStart)
        {
            StartCoroutine(SpawnObjects());
            oneStart = true;
        }
        if (gameManager.gameStart)
        {
            // oldestSpawnedObject �� null �ɂȂ����ꍇ�AsecondOldestSpawnedObject �� oldestSpawnedObject �ɐݒ肷��
            if (oldestSpawnedObject == null)
            {
                oldestSpawnedObject = secondOldestSpawnedObject;
                secondOldestSpawnedObject = null;
            }

            // oldestSecondSpawnedObject �� null �ɂȂ����ꍇ�AsecondOldestSecondSpawnedObject �� oldestSecondSpawnedObject �ɐݒ肷��
            if (oldestSecondSpawnedObject == null)
            {
                oldestSecondSpawnedObject = secondOldestSecondSpawnedObject;
                secondOldestSecondSpawnedObject = null;
            }
        }
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
          
                SpawnRandomObject();
                // ���̃X�|�[���Ԋu�������_���ɐݒ�
                float nextSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
                yield return new WaitForSeconds(nextSpawnInterval);
          
        }
    }

    private void SpawnRandomObject()
    {
        if (!gameManager.gameFinish)
        {
            if (objectsToSpawn.Count == 0 || spawnPositionX.Count == 0)
            {
                Debug.LogWarning("No objects to spawn or no spawn positions defined.");
                return;
            }

            // ���X�g���烉���_���ȃI�u�W�F�N�g��I��
            GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Count)];

            // �X�|�[���ʒu�̌�₪1�����Ȃ��ꍇ�͂��̂܂܎g�p����
            if (spawnPositionX.Count == 1)
            {
                lastSpawnIndex = 0;
            }
            else
            {
                // �V�����ʒu���O��̈ʒu�Ɣ��Ȃ��悤�ɑI��
                int newIndex;
                int attempts = 0; // ���[�v�񐔂��J�E���g
                do
                {
                    newIndex = Random.Range(0, spawnPositionX.Count);
                    attempts++;
                } while (newIndex == lastSpawnIndex && attempts < 10);

                lastSpawnIndex = newIndex;
            }

            // �I�񂾈ʒu���g���ăX�|�[��
            float randomX = spawnPositionX[lastSpawnIndex];
            Vector3 spawnPosition = new Vector3(randomX, yPos, 0);

            // �I�u�W�F�N�g���X�|�[��
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity, parentTransform);

            // SushiChat�^�̃I�u�W�F�N�g�̐ݒ�
            ChatNort chatNort = spawnedObject.GetComponent<ChatNort>();
            if (chatNort != null)
            {
                currentSushiType = chatNort.selectedSushi;
                Debug.Log(currentSushiType);
            }

            // ��ԌÂ��I�u�W�F�N�g�Ƃ��ċL�^
            if (oldestSpawnedObject == null)
            {
                oldestSpawnedObject = spawnedObject;
            }
            else
            {
                secondOldestSpawnedObject = spawnedObject;
            }

            // 1�b��ɕʂ̃I�u�W�F�N�g���X�|�[��
            StartCoroutine(SpawnSecondObjectAfterDelay());
        }
    }
    private IEnumerator SpawnSecondObjectAfterDelay()
    {
        yield return new WaitForSeconds(1f);


        // �ʂ̃I�u�W�F�N�g���w�肳�ꂽ���W�ɃX�|�[��
        GameObject secondSpawnedObject = Instantiate(secondObjectToSpawn, secondObjectPosition, Quaternion.identity, parentTransform);

        WaribasiMove waribasi = secondSpawnedObject.GetComponent<WaribasiMove>();
        if(waribasi != null)
        {
            waribasi.selectedSushi = currentSushiType;
        }

        // ��ԌÂ�secondSpawnedObject�Ƃ��ċL�^
        if (oldestSecondSpawnedObject == null)
        {
            oldestSecondSpawnedObject = secondSpawnedObject;
        }
        else
        {
            secondOldestSecondSpawnedObject =  secondSpawnedObject;
        }
    }

    // �w�肵���I�u�W�F�N�g���폜���郁�\�b�h
    public void DestroyOldestSpawnedObject()
    {
        if (oldestSpawnedObject != null)
        {
            Destroy(oldestSpawnedObject);
            oldestSpawnedObject = secondOldestSpawnedObject; // ���ɌÂ��I�u�W�F�N�g����ԌÂ��I�u�W�F�N�g��
            secondOldestSpawnedObject = null; // ��ԖڂɌÂ��I�u�W�F�N�g�̓��Z�b�g
        }
    }



    // ��ԌÂ�1�b��ɃX�|�[������I�u�W�F�N�g���폜���郁�\�b�h
    public void DestroyOldestSecondSpawnedObject()
    {
        if (oldestSecondSpawnedObject != null)
        {
            Destroy(oldestSecondSpawnedObject);
            oldestSecondSpawnedObject = secondOldestSecondSpawnedObject; // ���ɌÂ��I�u�W�F�N�g����ԌÂ��I�u�W�F�N�g��
            secondOldestSecondSpawnedObject = null; // ��ԖڂɌÂ��I�u�W�F�N�g�̓��Z�b�g
        }
    }
  
}