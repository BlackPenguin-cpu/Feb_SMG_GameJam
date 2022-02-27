using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    FlowerType flower;
    [SerializeField] private int GrowValue;
    float GrowCooldown;

    [SerializeField]
    GameObject[] puffPrefabList;
    
    [SerializeField]
    GameObject harvestEffectPrefab;
    
    [SerializeField]
    GameObject harvestEffect2Prefab;

    int _MaxGrowValue
    {
        get
        {
            return flower switch
            {
                FlowerType.TIGER => TigerSprites.Count,
                FlowerType.CARNATION => KanaitionSprites.Count,
                FlowerType.ROSE => RoseSprites.Count,
                _ => 0,
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
                                var puff = Instantiate(puffPrefabList[value - 1]);
                                puff.transform.position = transform.position;
                            }

                            SpriteRenderer.sprite = TigerSprites[value - 1];
                        }

                        break;
                    case FlowerType.CARNATION:
                        if (value - 1 >= 0 && value - 1 < KanaitionSprites.Count)
                        {
                            if (SpriteRenderer.sprite != KanaitionSprites[value - 1])
                            {
                                Audio.Instance.PlayGrowSound(_GrowValue);
                                var puff = Instantiate(puffPrefabList[value - 1]);
                                puff.transform.position = transform.position;
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
                                var puff = Instantiate(puffPrefabList[value - 1]);
                                puff.transform.position = transform.position;
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
    [SerializeField] GameObject InsectObj;
    [SerializeField] List<Sprite> ChatBallons;
    [SerializeField] GameObject ChatBallonObj;

    [Header("꽃들 스프라이트들")]
    [SerializeField] List<Sprite> TigerSprites;
    [SerializeField] List<Sprite> KanaitionSprites;
    [SerializeField] List<Sprite> RoseSprites;
    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        flower = GameManager.FlowerType;
    }
    private void Update()
    {
        GrowCooldown -= Time.deltaTime;
        InsectManager();
        BallonManager();
    }
    void BallonManager()
    {
        if (Insect)
        {
            ChatBallonObj.SetActive(true);
            ChatBallonObj.GetComponent<SpriteRenderer>().sprite = ChatBallons[0];
        }
        else if(GrowValue >= 4)
        {
            ChatBallonObj.SetActive(true);
            ChatBallonObj.GetComponent<SpriteRenderer>().sprite = ChatBallons[1];
        }
        else if(GrowCooldown <= 0 && GrowValue != 0)
        {
            ChatBallonObj.SetActive(true);
            ChatBallonObj.GetComponent<SpriteRenderer>().sprite = ChatBallons[2];
        }
        else
        {
            ChatBallonObj.SetActive(false);
        }
    }
    void InsectManager()
    {
        if (_GrowValue == 3)
        {
            if (Random.Range(1, (int)(600000 * Time.deltaTime)) == 1 )
            {
                Audio.Instance.PlayBugBuzzSound();
                Insect = true;
            }
        }
        if (Insect)
        {
            if (InsectObj != null)
            {
                InsectObj.SetActive(true);
            }
            
            if (InsectTimer > 3)
            {
                _GrowValue = 0;
                Insect = false;
            }
            
            InsectTimer += Time.deltaTime;
        }
        else if (InsectObj != null)
        {
            InsectObj.SetActive(false);
        }
    }
    public void OnClick()
    {
        if (Insect)
        {
            Audio.Instance.PlayBugDeathSound();
            Insect = false;
        }
        else if(GrowValue >= 4)
        {
            Harvest();
        }
    }


    public void Harvest()
    {
        GameManager.Instance._FlowerValue += Random.Range(1, 6);
        _GrowValue = 0;
        Audio.Instance.PlayHarvestFlowerSound();
        
        var harvestEffect = Instantiate(harvestEffectPrefab);
        var pos = transform.position;
        pos.y += 1.0f;
        harvestEffect.transform.position = pos;
        
        var harvest2Effect = Instantiate(harvestEffect2Prefab);
        var pos2 = transform.position;
        pos2.y += 2.0f;
        harvest2Effect.transform.position = pos2;
    }
}
