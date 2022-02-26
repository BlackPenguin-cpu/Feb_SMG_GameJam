using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    FlowerType flower;
    private int GrowValue;

    public int _GrowValue
    {
        get { return GrowValue; }
        set
        {
            switch (flower)
            {
                case FlowerType.TIGER:
                    SpriteRenderer.sprite = TigerSprites[value];
                    break;
                case FlowerType.KANAITION:
                    SpriteRenderer.sprite = KanaitionSprites[value];
                    break;
                case FlowerType.ROSE:
                    SpriteRenderer.sprite = RoseSprites[value];
                    break;
            }
            GrowValue = value;
        }
    }

    public bool Insect;
    SpriteRenderer SpriteRenderer;
 
    [Header("꽃 스프라이트들")]
    [SerializeField] List<Sprite> TigerSprites;
    [SerializeField] List<Sprite> KanaitionSprites;
    [SerializeField] List<Sprite> RoseSprites;
    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        flower = GameManager.Instance.FlowerType;
    }
    public void Harvest()
    {
        GameManager.Instance._FlowerValue += Random.Range(1,6);
        _GrowValue = 0;
    }
}
