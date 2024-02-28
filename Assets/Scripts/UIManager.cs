using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public int maxHearts = 4;
    public Transform heartsParent;

    public Sprite fullHeartSprite;

    public Sprite emptyHeartSprite;


    // Update the hearts based on the player's current health
    public void UpdateHearts(int currentHealth)
    {
        int fullHearts = currentHealth / 1;

        for (int i = 0; i < Mathf.Min(maxHearts, heartsParent.childCount); i++)
        {
            if (i < fullHearts)
            {
                heartsParent.GetChild(i).GetComponent<Image>().sprite = fullHeartSprite;
            }
            else
            {
                heartsParent.GetChild(i).GetComponent<Image>().sprite = emptyHeartSprite;
            }
        }
    }

}
