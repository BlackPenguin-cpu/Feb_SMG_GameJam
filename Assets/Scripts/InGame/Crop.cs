using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    FlowerType flower;
    [SerializeField] private int GrowValue;
    float GrowCooldown;

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
                        SpriteRenderer.sprite = TigerSprites[value - 1];
                        break;
                    case FlowerType.KANAITION:
                        SpriteRenderer.sprite = KanaitionSprites[value - 1];
                        break;
                    case FlowerType.ROSE:
                        SpriteRenderer.sprite = RoseSprites[value - 1];
                        break;
                }
            GrowValue = value;
        }
    }

    public bool Insect;
    [SerializeField] float InsectTimer;
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
    private void Update()
    {
        GrowCooldown -= Time.deltaTime;
        InsectManager();
    }
    void InsectManager()
    {
        if (GrowValue == 3)
        {
            if (Random.Range(1, 1000) == 1)
            {
                Insect = true;
            }
        }
        if (Insect)
        {
            if (InsectTimer > 3)
            {
                _GrowValue = 0;
            }
            InsectTimer += Time.deltaTime;
        }
    }

    public void Harvest()
    {
        GameManager.Instance._FlowerValue += Random.Range(1, 6);
        _GrowValue = 0;
    }
}
