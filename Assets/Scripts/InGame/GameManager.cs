using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public enum Interaction
{
    NONE,
    SCISSORS,
    NET,
    WATERING,
    PLANT
}

[System.Serializable]
public enum FlowerType
{
    TIGER,
    KANAITION,
    ROSE
}
public class GameManager : Singleton<GameManager>
{
    private int FlowersValue;
    public int _FlowerValue
    {
        get { return FlowersValue; }
        set
        {
            FlowersValueUI.text = value + " / 100";

            if (value >= 100)
            {
                Clear();
            }
            FlowersValue = value;
        }
    }
    [SerializeField] TextMeshProUGUI FlowersValueUI;

    public Interaction interaction;
    [SerializeField] List<Sprite> InteracitonSprites;
    [SerializeField] GameObject MouseIcon;

    [Header("게임 바깥쪽 변수")]
    public FlowerType FlowerType;
    void Clear()
    {
        Debug.Log("이겼닭!!! 오늘 저녁은 치킨이닭!");
    }

    void Update()
    {
        MouseIconChange();
        if (Input.GetMouseButtonUp(0))
        {
            interaction = Interaction.NONE;
        }
        OnInteraction();
    }

    void OnInteraction()
    {

        if (interaction != Interaction.NONE)
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D[] obj = Physics2D.RaycastAll(mousepos, Vector3.forward);
            foreach (RaycastHit2D hit in obj)
            {
                GameObject crop = hit.collider.gameObject;
                if (crop.GetComponent<Crop>())
                {
                    Crop CropState = crop.GetComponent<Crop>();
                    switch (interaction)
                    {
                        case Interaction.SCISSORS:
                            if(CropState._GrowValue == 4)
                            {
                                CropState.Harvest();
                            }
                            break;
                        case Interaction.NET:
                            if (CropState.Insect)
                            {
                                CropState.Insect = false;
                            }
                            break;
                        case Interaction.WATERING:
                            if (!CropState.Insect && CropState._GrowValue > 0)
                            {
                                CropState._GrowValue++;
                            }
                            break;
                        case Interaction.PLANT:
                            if (!CropState.Insect && CropState._GrowValue == 0)
                            {
                                CropState._GrowValue++;
                            }
                            break;
                    }
                }
            }
        }
    }

    ///<summary>
    ///오브젝트 버튼에 넣을 스크립트
    ///</summary>
    public void IconClick(int value)
    {
        interaction = (Interaction)value;
    }
    ///<summary>
    ///마우스 아이콘을 바꿔준다
    ///</summary>
    void MouseIconChange()
    {
        switch (interaction)
        {
            case Interaction.NONE:
                break;
            case Interaction.SCISSORS:
                break;
            case Interaction.NET:
                break;
            case Interaction.WATERING:
                break;
            case Interaction.PLANT:
                break;
            default:
                break;
        }
    }
}
