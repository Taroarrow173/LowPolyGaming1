using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    
    public GameObject WHolder;
    public GameObject IHolder;
    public GameObject[] Weapons;
    public Image[] Images;

    private void Start()
    {
        WHolder = GameObject.Find("WeaponHolder");
        IHolder = GameObject.Find("ImageHolder");

        int i = 0;
        foreach (Transform weapon in WHolder.transform)
        {

            Weapons[i] = WHolder.transform.GetChild(i).gameObject;
            Images[i] = IHolder.transform.GetChild(i).GetComponent<Image>();
            i++;
        }
    }
    private void Update()
    {
        int i2 = 0;
        foreach (Transform weapon in IHolder.transform)
        {
            int _sWeapon = WHolder.GetComponent<WeaponSwitching>().selectedWeapon;
            if (WHolder.transform.GetChild(i2).gameObject.activeSelf == true)
            {
                Images[i2].color = new Color32(255, 255, 255, 255);
            }
            else
            {
                Images[i2].color = new Color32(255, 255, 255, 85);
            }
            i2++;
        }
    }
}