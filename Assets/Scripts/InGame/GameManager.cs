using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    [SerializeField] Text FlowersValueUI;

    public Interaction interaction;
    [SerializeField] List<Sprite> InteracitonSprites;
    [SerializeField] Image MouseIcon;
    [SerializeField] List<Image> ClickButton;

    [SerializeField] Camera Cam;
    [SerializeField] RectTransform MouseIconParentRt;

    [Header("게임 바깥쪽 변수")]
    public FlowerType FlowerType;
    void Clear()
    {
        switch (FlowerType)
        {
            case FlowerType.TIGER:
                SceneManager.LoadScene("Ending1");
                break;
            case FlowerType.KANAITION:
                SceneManager.LoadScene("Ending2");
                break;
            case FlowerType.ROSE:
                break;
            default:
                break;
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "InGame")
        {
            MouseIconChange();
            OnInteraction();
            ButtonOutLine();
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (interaction == Interaction.NONE)
            {
                Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D[] obj = Physics2D.RaycastAll(mousepos, Vector3.forward);
                foreach (RaycastHit2D hit in obj)
                {
                    GameObject crop = hit.collider.gameObject;
                    if (crop.GetComponent<Crop>())
                    {
                        crop.GetComponent<Crop>().OnClick();
                    }
                }
            }
            else interaction = Interaction.NONE;
        }
    }
    void ButtonOutLine()
    {
        if (interaction == Interaction.WATERING)
        {
            ClickButton[0].material = Resources.Load<Material>("OutLine");
            ClickButton[1].material = null;
        }
        else if (interaction == Interaction.PLANT)
        {
            ClickButton[0].material = null;
            ClickButton[1].material = Resources.Load<Material>("OutLine");
        }
        else
        {
            ClickButton[0].material = null;
            ClickButton[1].material = null;
        }
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
                            if (CropState._GrowValue >= 4)
                            {
                                //CropState.Harvest();
                            }
                            break;
                        case Interaction.NET:
                            if (CropState.Insect)
                            {
                                //Audio.Instance.PlayBugDeathSound();
                                //CropState.Insect = false;
                            }
                            break;
                        case Interaction.WATERING:
                            if (!CropState.Insect && CropState._GrowValue > 0 && CropState._IsMaxGrow == false)
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
        Audio.Instance.PlayButtonClick();
    }
    ///<summary>
    ///마우스 아이콘을 바꿔준다
    ///</summary>
    void MouseIconChange()
    {
        switch (interaction)
        {
            case Interaction.NONE:
                if (Application.isEditor == false)
                {
                    Cursor.visible = true;
                }

                MouseIcon.gameObject.SetActive(false);
                break;
            case Interaction.SCISSORS:
            case Interaction.NET:
            case Interaction.WATERING:
            case Interaction.PLANT:
                if (Application.isEditor == false)
                {
                    Cursor.visible = false;
                }

                MouseIcon.sprite = InteracitonSprites[(int)interaction - 1];
                MouseIcon.gameObject.SetActive(true);
                MouseIcon.transform.position = Input.mousePosition;

                RectTransformUtility.ScreenPointToLocalPointInRectangle(MouseIconParentRt, Input.mousePosition, Cam,
                    out var localPoint);

                //var mouseLocalPos = MouseIcon.transform.localPosition;
                //mouseLocalPos.z = 0;
                MouseIcon.transform.localPosition = localPoint;
                break;
        }
    }
}
