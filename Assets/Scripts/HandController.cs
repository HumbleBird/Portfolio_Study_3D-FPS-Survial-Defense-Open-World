using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : CloseWeaponController
{
    // Ȱ��ȭ ����.
    public static bool isActiveate = false;

    void Update()
    {
        if (isActiveate)
            TryAttack();
    }

    protected override IEnumerator HitCoroutin()
    {
        while (isSwing)
        {
            if (CheckObject())
            {
                isSwing = false;
                Debug.Log(hitInfo.transform.name);
            }
            yield return null;
        }
    }
    public override void CloseWeaponChange(CloseWeapon _closeWeapon)
    {
        base.CloseWeaponChange(_closeWeapon);
        isActiveate = true;
    }

}

