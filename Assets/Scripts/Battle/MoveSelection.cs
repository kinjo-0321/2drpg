using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class MoveSelection : MonoBehaviour
{
    //�A�N�V����UI�̊Ǘ�
    //��������or�ɂ���̂ǂ����I�𒆂���c�����ĊǗ�
    [SerializeField] RectTransform movesParent;
    [SerializeField] SelectableText moveTextPrefab;
    List<SelectableText> selectableTexts = new List<SelectableText> ();

    int selectedIndex;

    public int SelectedIndex { get => selectedIndex; }

    public void Init(List<Move> moves)
    {
        //selectableTexts = GetComponentsInChildren<SelectableText>();
        SetMovesUISize(moves);
    }

    void SetMovesUISize(List<Move> moves)
    {
        Vector2 uiSize = movesParent.sizeDelta;
        uiSize.y = 17 + 50 * moves.Count;
        movesParent.sizeDelta = uiSize;

        for (int i = 0; i < moves.Count; i++)
        {
            SelectableText moveText = Instantiate(moveTextPrefab, movesParent);
            moveText.SetText(moves[i].Base.Name);
            selectableTexts.Add(moveText);
        }
    }

    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedIndex++;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedIndex--;
        }

        selectedIndex = Mathf.Clamp(selectedIndex, 0, selectableTexts.Count - 1);

        for (int i = 0; i < selectableTexts.Count; i++)
        {


            if (selectedIndex == i)
            {
                selectableTexts[i].SetSelectedColor(true);
            }
            else
            {
                selectableTexts[i].SetSelectedColor(false);
            }
        }
    }

    public void Open()
    {
        selectedIndex = 0;
        gameObject.SetActive(true);
    }

    public  void Close()
    {
        gameObject.SetActive(false);
    }

    public void DeleteMoveTexts()
    {
        foreach(var text in selectableTexts)
        {
            Destroy(text.gameObject);
        }
        selectableTexts.Clear();    
    }
}