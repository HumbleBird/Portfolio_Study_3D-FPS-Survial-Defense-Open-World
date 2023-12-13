using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    // ���� �ߺ� ��ü ���� ����.
    public static bool isChangeWeapon = false; // ���� �ڿ�, Ŭ���� ���� = ���� ����

    // ���� ����� ���� ������ �ִϸ��̼�
    public static Transform currentWeapon;
    public static Animator currentWeaponAnim;

    // ���� ������ Ÿ��
    [SerializeField]
    private string currentWeaponType;

    // ���� ��ü ������, ���� ��ü�� ������ ���� ����
    [SerializeField]
    private float changeWeaponDelayTime;
    [SerializeField]
    private float changeWeaponEndDelayTime;

    // ���� ������ ���� ����
    [SerializeField]
    private Gun[] guns;
    [SerializeField]
    private CloseWeapon[] hands;
    [SerializeField]
    private CloseWeapon[] axes;
    [SerializeField]
    private CloseWeapon[] pickaxes;

    // ���� �������� ���� ���� ������ �����ϵ��� ����
    private Dictionary<string, Gun> gunDirctionary = new Dictionary<string, Gun>();
    private Dictionary<string, CloseWeapon> handDirctionary = new Dictionary<string, CloseWeapon>();
    private Dictionary<string, CloseWeapon> axeDirctionary = new Dictionary<string, CloseWeapon>();
    private Dictionary<string, CloseWeapon> pickaxeDirctionary = new Dictionary<string, CloseWeapon>();

    // �ʿ��� ������Ʈ
    [SerializeField]
    private GunController theGunController;
    [SerializeField]
    private HandController theHandController;
    [SerializeField]
    private AxeController theAxeController;    
    [SerializeField]
    private PickaxeController thePickaxeController;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            gunDirctionary.Add(guns[i].gunName, guns[i]);
        }

        for (int i = 0; i < hands.Length; i++)
        {
            handDirctionary.Add(hands[i].closeWeaponName, hands[i]);
        }

        for (int i = 0; i < axes.Length; i++)
        {
            axeDirctionary.Add(axes[i].closeWeaponName, axes[i]);
        }
        for (int i = 0; i < pickaxes.Length; i++)
        {
            pickaxeDirctionary.Add(pickaxes[i].closeWeaponName, pickaxes[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isChangeWeapon)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                StartCoroutine(ChangeWeaponCoroutine("HAND", "�Ǽ�"));
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                StartCoroutine(ChangeWeaponCoroutine("GUN", "SubMachineGun1"));
            else if (Input.GetKeyDown(KeyCode.Alpha3))
                StartCoroutine(ChangeWeaponCoroutine("AXE", "Axe"));
            else if (Input.GetKeyDown(KeyCode.Alpha4))
                StartCoroutine(ChangeWeaponCoroutine("PICKAXE", "Pickaxe"));

        }
    }

    public IEnumerator ChangeWeaponCoroutine(string _type, string _name)
    {
        isChangeWeapon = true;
        currentWeaponAnim.SetTrigger("Weapon_Out");

        yield return new WaitForSeconds(changeWeaponDelayTime);

        CancelPreWeaponAction();
        WeaponChange(_type, _name);

        yield return new WaitForSeconds(changeWeaponEndDelayTime);

        currentWeaponType = _type;
        isChangeWeapon = false;
    }

    // ���� ��� �Լ�
    private void CancelPreWeaponAction()
    {
        switch (currentWeaponType)
        {
            case "GUN":
                theGunController.CancelFineSight();
                theGunController.CancelReload();
                GunController.isActiveate = false;
                break;
            case "HAND":
                HandController.isActiveate = false;
                break;
            case "AXE":
                AxeController.isActiveate = false;
                break;
            case "PICKAXE":
                PickaxeController.isActiveate = false;
                break;

        }
    }

    // ���� ��ü �Լ�
    private void WeaponChange(string _type, string _name)
    {
        if(_type == "GUN")       
            theGunController.GunChange(gunDirctionary[_name]);       
        else if (_type == "HAND")      
            theHandController.CloseWeaponChange(handDirctionary[_name]);
        else if (_type == "AXE")
            theAxeController.CloseWeaponChange(axeDirctionary[_name]);
        else if (_type == "PICKAXE")
            thePickaxeController.CloseWeaponChange(pickaxeDirctionary[_name]);
    }
}