using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    FlowerType flower;
    [SerializeField] private int GrowValue;
    float GrowCooldown;

    int _MaxGrowValue
    {
        get
        {
            return flower switch
            {
                FlowerType.TIGER => TigerSprites.Count,
                FlowerType.KANAITION => KanaitionSprites.Count,
                FlowerType.ROSE => RoseSprites.Count,
            };
        }
    }

    public bool _IsMaxGrow => _GrowValue >= _MaxGrowValue;

    public int _GrowValue
    {
        get { return GrowValue; }
        set
        {
            if (GrowCooldown > 0)
            {
                return;
            }
            if (GrowValue < value)
            {
                GrowCooldown = 1;
            }
            if (value == 0) SpriteRenderer.sprite = null;
            else
                switch (flower)
                {
                    case FlowerType.TIGER:
                        if (value - 1 >= 0 && value - 1 < TigerSprites.Count)
                        {
                            if (SpriteRenderer.sprite != TigerSprites[value - 1])
                            {
                                Audio.Instance.PlayGrowSound(_GrowValue);
                            }

                            SpriteRenderer.sprite = TigerSprites[value - 1];
                        }

                        break;
                    case FlowerType.KANAITION:
                        if (value - 1 >= 0 && value - 1 < KanaitionSprites.Count)
                        {
                            if (SpriteRenderer.sprite != KanaitionSprites[value - 1])
                            {
                                Audio.Instance.PlayGrowSound(_GrowValue);
                            }

                            SpriteRenderer.sprite = KanaitionSprites[value - 1];
                        }

                        break;
                    case FlowerType.ROSE:
                        if (value - 1 >= 0 && value - 1 < RoseSprites.Count)
                        {
                            if (SpriteRenderer.sprite != RoseSprites[value - 1])
                            {
                                Audio.Instance.PlayGrowSound(_GrowValue);
                            }

                            SpriteRenderer.sprite = RoseSprites[value - 1];
                        }

                        break;
                }
            GrowValue = value;
        }
    }

    public bool Insect;
    [SerializeField] float InsectTimer;
    SpriteRenderer SpriteRenderer;
    GameObject InsectObj;

    [Header("꽃들 스프라이트들")]
    [SerializeField] List<Sprite> TigerSprites;
    [SerializeField] List<Sprite> KanaitionSprites;
    [SerializeField] List<Sprite> RoseSprites;
    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        flower = GameManager.Instance.FlowerType;
    }
    private void Update()
    {
        GrowCooldown -= Time.deltaTime;
        InsectManager();
    }
    void InsectManager()
    {
        if (_GrowValue == 3)
        {
            if (Random.Range(1, 1000) == 1)
            {
                Audio.Instance.PlayBugBuzzSound();
                Insect = true;
            }
        }
        if (Insect)
        {
            InsectObj.SetActive(true);
            if (InsectTimer > 3)
            {
                _GrowValue = 0;
            }
            InsectTimer += Time.deltaTime;
        }
        else InsectObj.SetActive(false);
    }

    public void Harvest()
    {
        GameManager.Instance._FlowerValue += Random.Range(1, 6);
        _GrowValue = 0;
        Audio.Instance.PlayHarvestFlowerSound();
    }
}
