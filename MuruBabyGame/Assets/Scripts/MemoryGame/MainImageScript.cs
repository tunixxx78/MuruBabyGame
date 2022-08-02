using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainImageScript : MonoBehaviour
{
    [SerializeField] GameObject cardCover;
    [SerializeField] GameController gameController;
    int spriteId;

    private void OnMouseDown()
    {
        if (cardCover.activeSelf && gameController.canOpen)
        {
            cardCover.SetActive(false);
            gameController.ImageOpen(this);
        }
    }

    
    public int SpriteId
    {
        get { return spriteId; }
    }

    public void ChangeSprite(int id, Sprite image)
    {
        spriteId = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    public void Close()
    {
        cardCover.SetActive(true);
    }
}
