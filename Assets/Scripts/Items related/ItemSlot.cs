using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour // Youtube:https://www.youtube.com/watch?v=0wKB_rxtqh4&list=PLSR2vNOypvs6eIxvTu-rYjw2Eyw57nZrU
{
    public Image iconImage;

    public void SetItem(Sprite icon)
    {
        iconImage.sprite = icon;
        iconImage.color = new Color(1f, 1f, 1f, 1f);
    }

    public void ClearItem()
    {
        iconImage.sprite = null;
        iconImage.color = new Color(1f, 1f, 1f, 0f);
    }

    public bool IsEmpty()
    {
        return iconImage.sprite == null;
    }
}
