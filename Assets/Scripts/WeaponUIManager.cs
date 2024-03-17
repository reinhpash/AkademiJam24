using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUIManager : MonoBehaviour
{
    public Transform slotParent;
    public List<WeaponSlot> slots = new List<WeaponSlot>();
    private List<WeaponSlot> m_CurrentSlots = new List<WeaponSlot>();
    private int slotCount = 3;
    int lastIndex = 0;
    int currentIndex = 0;
    int attempts = 0;

    public void ShowUI()
    {
        Time.timeScale = 0f;
        for (int i = 0; i < slotCount; i++)
        {
            currentIndex = Random.Range(0, slots.Count);

            while (lastIndex == currentIndex && attempts < 10)
            {
                currentIndex = Random.Range(0, slots.Count);
                attempts++;
            }

            if (attempts >= 10 && lastIndex == currentIndex)
            {
                currentIndex++;
            }

            lastIndex = currentIndex;
            try
            {
                var obj = Instantiate(slots[currentIndex], slotParent);
                m_CurrentSlots.Add(obj);
            }
            catch
            {
                var obj = Instantiate(slots[0], slotParent);
                m_CurrentSlots.Add(obj);
            }

        }

        slotParent.gameObject.SetActive(true);
    }

    public void HideUI()
    {
        Time.timeScale = 1f;
        for (int i = 0; i < m_CurrentSlots.Count; i++)
        {
            Destroy(m_CurrentSlots[i].gameObject);
        }

        m_CurrentSlots.Clear();

        slotParent.gameObject.SetActive(false);
    }

    public void OnSelectWeapon()
    {
        HideUI();
    }

}
