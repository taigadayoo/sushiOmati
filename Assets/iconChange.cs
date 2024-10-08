using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iconChange : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();

    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (sprites.Count > 0)
        {
            // リストからランダムにスプライトを選択
            int randomIndex = Random.Range(0, sprites.Count);
            Sprite randomSprite = sprites[randomIndex];

            // 選択したスプライトを適用
            spriteRenderer.sprite = randomSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
