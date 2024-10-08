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
            // ���X�g���烉���_���ɃX�v���C�g��I��
            int randomIndex = Random.Range(0, sprites.Count);
            Sprite randomSprite = sprites[randomIndex];

            // �I�������X�v���C�g��K�p
            spriteRenderer.sprite = randomSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
