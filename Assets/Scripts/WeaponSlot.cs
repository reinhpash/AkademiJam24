using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    public string description;
    public TextMeshProUGUI descriptionText;
    public GameObject weaponPrefab;
    public bool isGun = false;

    private void Start()
    {
        descriptionText.SetText(description);
    }

    public void SelectWeapon()
    {
        var p = GameObject.FindGameObjectWithTag("Player");
        Transform point = null;
        if (isGun)
        {
            point = p.GetComponent<PlayerAttack>().GetRandomPos();
        }

        var obj = Instantiate(weaponPrefab, point != null ? point : p.transform);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;
        GameObject.FindObjectOfType<WeaponUIManager>().HideUI();
    }

}
