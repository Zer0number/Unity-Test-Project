using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class WeaponSwitch : MonoBehaviour
{
    public int selectedWeapon = 0;
    public TextMeshProUGUI AmmoInfo;

    InputAction weaponSwitch;

    void Start()
    {
        weaponSwitch = new InputAction("Scroll", binding: "<mouse>/scroll");
        weaponSwitch.Enable();

        SelectWeapon();
    }

    void Update()
    {
        Weapon currentWeapon = FindObjectOfType<Weapon>();
        AmmoInfo.text = currentWeapon.currentAmmo + "/" + currentWeapon.maxAmmo;

        float scrollValue = weaponSwitch.ReadValue<Vector2>().y;
        int previousSelected = selectedWeapon;

        if(scrollValue > 0){
            selectedWeapon++;
            if(selectedWeapon == 3)
                selectedWeapon = 0;
        }
        else if(scrollValue < 0){
            selectedWeapon--;
            if(selectedWeapon == -1)
                selectedWeapon = 2;
        }

        if(previousSelected != selectedWeapon)
            SelectWeapon();
    }

    private void SelectWeapon(){
        foreach(Transform weapon in transform){
            weapon.gameObject.SetActive(false);
        }
        transform.GetChild(selectedWeapon).gameObject.SetActive(true);
    }
}
