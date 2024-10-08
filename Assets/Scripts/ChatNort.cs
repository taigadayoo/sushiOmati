using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatNort : MonoBehaviour
{
    [SerializeField]
   public SushiChat selectedSushi;

   public SushiChat currentSushi;
    GameManager gameManager;

 
    // Start is called before the first frame update

    void Start()
    {
        currentSushi = selectedSushi;
      gameManager =   FindObjectOfType<GameManager>();
        StartCoroutine(DestroyChat());

      
    }

 
  IEnumerator DestroyChat()
    {
      yield return new WaitForSeconds(7f);

        Destroy(this.gameObject);
    }
}
