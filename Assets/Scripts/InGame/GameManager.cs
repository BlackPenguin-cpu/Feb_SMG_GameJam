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

    [SerializeField] Camera Cam;
    [SerializeField] RectTransform MouseIconParentRt;

    [Header("���� �ٱ��� ����")]
    public FlowerType FlowerType;
    void Clear()
    {
        Debug.Log("�̰��!!! ���� ������ ġŲ�̴�!");
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "InGame")
        {
            MouseIconChange();
            OnInteraction();
        }
        if (Input.GetMouseButtonDown(0))
        {
            interaction = Interaction.NONE;
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
                                CropState.Harvest();
                            }
                            break;
                        case Interaction.NET:
                            if (CropState.Insect)
                            {
                                Audio.Instance.PlayBugDeathSound();
                                CropState.Insect = false;
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
    ///������Ʈ ��ư�� ���� ��ũ��Ʈ
    ///</summary>
    public void IconClick(int value)
    {
        interaction = (Interaction)value;
        Audio.Instance.PlayButtonClick();
    }
    ///<summary>
    ///���콺 �������� �ٲ��ش�
    ///</summary>
    void MouseIconChange()
    {
        switch (interaction)
        {
            case Interaction.NONE:
                Cursor.visible = true;
                MouseIcon.gameObject.SetActive(false);
                break;
            case Interaction.SCISSORS:
            case Interaction.NET:
            case Interaction.WATERING:
            case Interaction.PLANT:
                Cursor.visible = false;
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
