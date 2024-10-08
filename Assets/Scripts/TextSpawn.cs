using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSpawn : MonoBehaviour
{
    public List<GameObject> objectsToSpawn; // スポーンさせるオブジェクトのリスト
    public List<float> spawnPositionX; // スポーンさせるオブジェクトのリスト
    public GameObject secondObjectToSpawn; // 1秒後にスポーンさせる別のオブジェクト
    public float minSpawnInterval = 2f; // スポーン間隔の最小値（秒）
    public float maxSpawnInterval = 4f; // スポーン間隔の最大値（秒）
    public float minX = -5f; // x軸の最小値（ワールド座標）
    public float maxX = 5f; // x軸の最大値（ワールド座標）
    public float yPos = 0f; // 固定のy軸位置（ワールド座標）
    public Transform parentTransform; // スポーンさせるオブジェクトの親のTransform
    public Vector3 secondObjectPosition; // 1秒後にスポーンさせるオブジェクトのワールド座標

    private GameObject oldestSpawnedObject; // 一番古いオブジェクトを記録するための変数
    private GameObject secondOldestSpawnedObject; // 一番古いsecondSpawnedObjectを記録するための変数
    private GameObject oldestSecondSpawnedObject; // 一番古い1秒後にスポーンするオブジェクト
    private GameObject secondOldestSecondSpawnedObject; // 二番目に古い1秒後にスポーンするオブジェクト
    private int lastSpawnIndex = -1; // 前回のスポーン位置インデックス
    private SushiChat currentSushiType;
    private bool oneStart = false;
    GameManager gameManager;
    [SerializeField]
    [Tooltip("発生させるエフェクト(パーティクル)")]
    public ParticleSystem Great;
    [SerializeField]
    [Tooltip("発生させるエフェクト(パーティクル)")]
    public ParticleSystem Good;
    [SerializeField]
    [Tooltip("発生させるエフェクト(パーティクル)")]
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
            // oldestSpawnedObject が null になった場合、secondOldestSpawnedObject を oldestSpawnedObject に設定する
            if (oldestSpawnedObject == null)
            {
                oldestSpawnedObject = secondOldestSpawnedObject;
                secondOldestSpawnedObject = null;
            }

            // oldestSecondSpawnedObject が null になった場合、secondOldestSecondSpawnedObject を oldestSecondSpawnedObject に設定する
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
                // 次のスポーン間隔をランダムに設定
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

            // リストからランダムなオブジェクトを選択
            GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Count)];

            // スポーン位置の候補が1つしかない場合はそのまま使用する
            if (spawnPositionX.Count == 1)
            {
                lastSpawnIndex = 0;
            }
            else
            {
                // 新しい位置が前回の位置と被らないように選択
                int newIndex;
                int attempts = 0; // ループ回数をカウント
                do
                {
                    newIndex = Random.Range(0, spawnPositionX.Count);
                    attempts++;
                } while (newIndex == lastSpawnIndex && attempts < 10);

                lastSpawnIndex = newIndex;
            }

            // 選んだ位置を使ってスポーン
            float randomX = spawnPositionX[lastSpawnIndex];
            Vector3 spawnPosition = new Vector3(randomX, yPos, 0);

            // オブジェクトをスポーン
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity, parentTransform);

            // SushiChat型のオブジェクトの設定
            ChatNort chatNort = spawnedObject.GetComponent<ChatNort>();
            if (chatNort != null)
            {
                currentSushiType = chatNort.selectedSushi;
                Debug.Log(currentSushiType);
            }

            // 一番古いオブジェクトとして記録
            if (oldestSpawnedObject == null)
            {
                oldestSpawnedObject = spawnedObject;
            }
            else
            {
                secondOldestSpawnedObject = spawnedObject;
            }

            // 1秒後に別のオブジェクトをスポーン
            StartCoroutine(SpawnSecondObjectAfterDelay());
        }
    }
    private IEnumerator SpawnSecondObjectAfterDelay()
    {
        yield return new WaitForSeconds(1f);


        // 別のオブジェクトを指定された座標にスポーン
        GameObject secondSpawnedObject = Instantiate(secondObjectToSpawn, secondObjectPosition, Quaternion.identity, parentTransform);

        WaribasiMove waribasi = secondSpawnedObject.GetComponent<WaribasiMove>();
        if(waribasi != null)
        {
            waribasi.selectedSushi = currentSushiType;
        }

        // 一番古いsecondSpawnedObjectとして記録
        if (oldestSecondSpawnedObject == null)
        {
            oldestSecondSpawnedObject = secondSpawnedObject;
        }
        else
        {
            secondOldestSecondSpawnedObject =  secondSpawnedObject;
        }
    }

    // 指定したオブジェクトを削除するメソッド
    public void DestroyOldestSpawnedObject()
    {
        if (oldestSpawnedObject != null)
        {
            Destroy(oldestSpawnedObject);
            oldestSpawnedObject = secondOldestSpawnedObject; // 次に古いオブジェクトを一番古いオブジェクトに
            secondOldestSpawnedObject = null; // 二番目に古いオブジェクトはリセット
        }
    }



    // 一番古い1秒後にスポーンするオブジェクトを削除するメソッド
    public void DestroyOldestSecondSpawnedObject()
    {
        if (oldestSecondSpawnedObject != null)
        {
            Destroy(oldestSecondSpawnedObject);
            oldestSecondSpawnedObject = secondOldestSecondSpawnedObject; // 次に古いオブジェクトを一番古いオブジェクトに
            secondOldestSecondSpawnedObject = null; // 二番目に古いオブジェクトはリセット
        }
    }
  
}