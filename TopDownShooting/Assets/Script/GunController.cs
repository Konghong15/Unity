using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform mWeapoHold;
    public Gun mStartingGun;
    Gun mEquippedGun;

    void Start()
    {
        if (mStartingGun != null)
        {
            EquipGun(mStartingGun);
        }
    }

    public void EquipGun(Gun gun)
    {
        if (mEquippedGun != null)
        {
            Destroy(mEquippedGun.gameObject);
        }

        mEquippedGun = Instantiate(gun, mWeapoHold.position, mWeapoHold.rotation) as Gun; // as Gun Çüº¯È¯
        mEquippedGun.transform.parent = mWeapoHold;
    }

    public void Shoot()
    {
        if (mEquippedGun != null)
        {
            mEquippedGun.Shoot();
        }
    }
}
