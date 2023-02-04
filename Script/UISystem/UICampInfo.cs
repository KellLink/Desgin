using System;
using Script.CampSystem;
using Script.Tools;
using UnityEngine;
using UnityEngine.UI;

public class UICampInfo : IUISystem
{
    private Image _campIcon;
    private Text _campName;
    private Text _campLevel;
    private Text _weaponLevel;
    private Button _campUpgradeButton;
    private Button _campWeaponUpgradeButton;
    private Button _trainButton;
    private Button _canelTrainButton;
    private Text _aliveCount;
    private Text _trainCount;
    private Text _trainTime;
    private ICamp _camp;

    public override void Init()
    {
        base.Init();
        // UnityToolkit.AttackChildren().;
        GameObject canvas = UIToolKits.GetCanvas();
        _rootUI = UnityToolkit.FindInChildren(canvas, "CampInfoUI");

        _campIcon = UIToolKits.FindChild<Image>(_rootUI, "CampIcon");
        _campName = UIToolKits.FindChild<Text>(_rootUI, "CampName");
        _campLevel = UIToolKits.FindChild<Text>(_rootUI, "CampLevel");
        _weaponLevel = UIToolKits.FindChild<Text>(_rootUI, "WeaponLevel").GetComponent<Text>();
        _campUpgradeButton = UIToolKits.FindChild<Button>(_rootUI, "UpgradeCampButton");
        _campWeaponUpgradeButton = UIToolKits.FindChild<Button>(_rootUI, "UpgradeWeaponButton");
        _trainButton = UIToolKits.FindChild<Button>(_rootUI, "TrainButton");
        _canelTrainButton = UIToolKits.FindChild<Button>(_rootUI, "CanelTrainButton");
        _aliveCount = UIToolKits.FindChild<Text>(_rootUI, "AliveCount");
        _trainCount = UIToolKits.FindChild<Text>(_rootUI, "TrainCount");
        _trainTime = UIToolKits.FindChild<Text>(_rootUI, "TrainTime");

        _trainButton.onClick.AddListener(OnTrainButtonClick);
        _canelTrainButton.onClick.AddListener(OnCanelTrainButtonClick);
        
        _campUpgradeButton.onClick.AddListener(OnCampUpgradeButtonClick);
        _campWeaponUpgradeButton.onClick.AddListener(OnWeaponUpgradeButtonOnClick);
        Hide();
    }

    public override void Update()
    {
        ShowTrainingInfo();
    }

    public override void End()
    {
    }

    public void ShowCampInfo(ICamp camp)
    {
        _camp = camp;
        _campIcon.sprite = FactoryManager.AssetFactory.LoadSpite(camp.IconSpite);
        _campName.text = camp.Name;
        _campLevel.text = "兵营等级：" + camp.Level.ToString();
        _weaponLevel.text = "武器等级：" + camp.WeaponTypeLevel.ToString();
        ShowTrainingInfo();
        Show();
    }

    public void ShowTrainingInfo()
    {
        if (_camp==null)
        {
            return; 
        }
        _trainCount.text = "正在训练："+_camp.GetTrainCount().ToString();
        _trainTime.text = "训练时间："+_camp.GetTrainRemainingTime().ToString("0.00");

        if (_camp.GetTrainCount()==0)
        {
            _canelTrainButton.interactable = false;
        }
        else
        {
            _canelTrainButton.interactable = true;
        }
    }

    private String GetWeaponTypeString(WeaponType type)
    {
        String weaponString = String.Empty;
        switch (type)
        {
            case WeaponType.Gun:
                weaponString = "手枪";
                break;
            case WeaponType.Rifle:
                weaponString = "步枪";
                break;
            case WeaponType.Rocket:
                weaponString = "火箭筒";
                break;
            default:
                weaponString = "未知";
                break;
        }

        return "武器等级："+weaponString;
    }

    public void OnTrainButtonClick()
    {
        //TODO 能量》生产
        _camp.Train();
    }

    public void OnCanelTrainButtonClick()
    {
        //TODO 
        _camp.CancelTrainCommand();
    }

    public void OnCampUpgradeButtonClick()
    {
        //TODO 
        int energy = _camp.CampUpgradeEnergyCost;
        if (energy<0)
        {
            Debug.Log("Cannot Upgrade Camp");
            return;
        }
        _camp.UpgradeCamp();
        ShowCampInfo(_camp);
    }

    public void OnWeaponUpgradeButtonOnClick()
    {
        int energy = _camp.WeaponUpgradeEnergyCost;
        if (energy<0)
        {
            Debug.Log("Cannot Upgrade Weapon");
            return;
        }
        _camp.UpgradeWeapon();
        ShowCampInfo(_camp);
    }
}