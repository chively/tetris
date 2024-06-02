using UnityEngine;
using UnityEngine.UI;

public partial class Stage : MonoBehaviour
{
    public Image itemIcon; // 아이템 아이콘을 표시할 UI 이미지
    public Sprite doubleScoreSprite; // 점수 두배 아이템 스프라이트
    public Sprite clearRowsSprite; // 줄 제거 아이템 스프라이트

    private enum ItemType
    {
        None,
        DoubleScore,
        ClearRows
    }

    private ItemType currentItem = ItemType.None;
    private float doubleScoreEndTime = 0f;

    void GrantItem()
    {
        Debug.Log("grantItem활성화");
        // 랜덤하게 아이템 부여
        if (Random.Range(0, 2) == 0)
        {
            currentItem = ItemType.DoubleScore;
            itemIcon.sprite = doubleScoreSprite;
        } else {
            currentItem = ItemType.ClearRows;
            itemIcon.sprite = clearRowsSprite;
        }
        itemIcon.enabled = true; // 아이템 아이콘 표시
        Debug.Log("item icon 나옴");
    }

    void UseItem()
    {
        if (currentItem == ItemType.None) return;

        switch (currentItem)
        {
            case ItemType.DoubleScore:
                Debug.Log("2배 아이템 발동 시작");
                itemActived = true;
                doubleScoreEndTime = Time.time + 30f; // 30초간 점수 두배

                // 슬라이더 세팅
                doubleTimeSlider.maxValue = 30f;
                doubleTimeSlider.value = 30f;
                doubleTimeSlider.gameObject.SetActive(true);
                sliderText.gameObject.SetActive(true);


                break;

            case ItemType.ClearRows:
                Debug.Log("5줄 제거");
                ClearBottomRows(5); // 하단 5줄 제거
                break;
        }

        itemIcon.enabled = false; // 아이템 아이콘 숨기기
    }

    void ClearBottomRows(int rows)
    {
        for (int y = 0; y < rows; y++)
        {
            var column = boardNode.Find(y.ToString());
            if (column != null)
            {
                foreach (Transform tile in column)
                {
                    Destroy(tile.gameObject);
                }
                column.DetachChildren();
            }
        }
        ClearRows();
    }
}
