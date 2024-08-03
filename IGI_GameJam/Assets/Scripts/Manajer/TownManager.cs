using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TownManager : MonoBehaviour
{

    [SerializeField] TownSO townSO;
    [SerializeField] Stats PlayerSO;
    [SerializeField] AttackSO[] AttackCombo;
    [Header("LevelUp Town SetUp")]
    [SerializeField] Sprite LevelUp;
    [SerializeField] Image[] HospitalLevel;
    [SerializeField] Image[] ResearchLevel;
    [SerializeField] Image[] CulinaryLevel;
    [SerializeField] Image[] MilitaryLevel;
    [SerializeField] Image[] AgricultureLevel;
    [SerializeField] TMP_Text Description;

    /*
    [Header("Description Town SetUp")]
    
    [TextArea(3, 10)]
    public string HospitalDescription;
    [TextArea(3, 10)]
    public string ResearchDescription;
    [TextArea(3, 10)]
    public string CulinaryDescription;
    [TextArea(3, 10)]
    public string MilitaryDescription;
    [TextArea(3, 10)]
    public string AgricultureDescription;
    */
    private void Start()
    {
        //hospital setup
        for(int i = 0; i< townSO.HospitalsLevel; i++)
        {
            HospitalLevel[i].sprite = LevelUp;
        }
        //Research setup
        for (int i = 0; i < townSO.ResearchLevel; i++)
        {
            ResearchLevel[i].sprite = LevelUp;
        }
        //Culinary SetUp
        for (int i = 0; i < townSO.CulinaryLevel; i++)
        {
            CulinaryLevel[i].sprite = LevelUp;
        }
        //Military SetUp
        for (int i = 0; i < townSO.MilitaryLevel; i++)
        {
            MilitaryLevel[i].sprite = LevelUp;
        }
        //Agriculture SetUp
        for (int i = 0; i < townSO.AgricultureLevel; i++)
        {
            AgricultureLevel[i].sprite = LevelUp;
        }


    }

    #region Description

    public void DescriptionTown(string DescriptionTxt)
    {
        Description.text = DescriptionTxt;
    }

    #endregion

    #region Upgrade
    public void UpgradeHospital()
    {
       if(townSO.HospitalsLevel == 1)
       {
            if (CurrencyManager.instance.CheckCurrency(200))
            {
                CurrencyManager.instance.MinusCurrency(200);
                townSO.HospitalsLevel++;
                HospitalLevel[townSO.HospitalsLevel - 1].sprite = LevelUp;
            }
       }
       else if (townSO.HospitalsLevel == 2)
        {
            if (CurrencyManager.instance.CheckCurrency(400))
            {
                CurrencyManager.instance.MinusCurrency(400);
                townSO.HospitalsLevel++;
                HospitalLevel[townSO.HospitalsLevel - 1].sprite = LevelUp;
            }
        }
        else if (townSO.HospitalsLevel == 3)
        {
            if (CurrencyManager.instance.CheckCurrency(600))
            {
                CurrencyManager.instance.MinusCurrency(600);
                townSO.HospitalsLevel++;
                HospitalLevel[townSO.HospitalsLevel - 1].sprite = LevelUp;
            }
        }

    }

    public void UpgradeResearch()
    {
        if (townSO.ResearchLevel == 1)
        {
            if (CurrencyManager.instance.CheckCurrency(200))
            {
                CurrencyManager.instance.MinusCurrency(200);
                townSO.ResearchLevel++;
                ResearchLevel[townSO.ResearchLevel - 1].sprite = LevelUp;
            }
        }
        else if(townSO.ResearchLevel == 2)
        {
            if (CurrencyManager.instance.CheckCurrency(400))
            {
                CurrencyManager.instance.MinusCurrency(400);
                townSO.ResearchLevel++;
                ResearchLevel[townSO.ResearchLevel - 1].sprite = LevelUp;
            }
        }
        else if(townSO.ResearchLevel == 3)
        {
            if (CurrencyManager.instance.CheckCurrency(600))
            {
                CurrencyManager.instance.MinusCurrency(600);
                townSO.ResearchLevel++;
                ResearchLevel[townSO.ResearchLevel - 1].sprite = LevelUp;
            }
        }

    }

    public void UpgradeCulinary()
    {
        if (townSO.CulinaryLevel == 1)
        {
            if (CurrencyManager.instance.CheckCurrency(200))
            {
                CurrencyManager.instance.MinusCurrency(200);
                townSO.CulinaryLevel++;
                CulinaryLevel[townSO.CulinaryLevel - 1].sprite = LevelUp;
            }
        }
        else if(townSO.CulinaryLevel == 2)
        {
            if (CurrencyManager.instance.CheckCurrency(400))
            {
                CurrencyManager.instance.MinusCurrency(400);
                townSO.CulinaryLevel++;
                CulinaryLevel[townSO.CulinaryLevel - 1].sprite = LevelUp;
            }
        }
        else if(townSO.CulinaryLevel == 3)
        {
            if (CurrencyManager.instance.CheckCurrency(600))
            {
                CurrencyManager.instance.MinusCurrency(600);
                townSO.CulinaryLevel++;
                CulinaryLevel[townSO.CulinaryLevel - 1].sprite = LevelUp;
            }
        }

    }

    public void UpgradeMilitary()
    {
        if (townSO.MilitaryLevel == 1)
        {
            if (CurrencyManager.instance.CheckCurrency(200))
            {
                CurrencyManager.instance.MinusCurrency(200);
                townSO.MilitaryLevel++;
                MilitaryLevel[townSO.MilitaryLevel - 1].sprite = LevelUp;
            }
        }
        else if(townSO.MilitaryLevel == 2)
        {
            if (CurrencyManager.instance.CheckCurrency(400))
            {
                CurrencyManager.instance.MinusCurrency(400);
                townSO.MilitaryLevel++;
                MilitaryLevel[townSO.MilitaryLevel - 1].sprite = LevelUp;
            }
        }
        else if(townSO.MilitaryLevel == 3)
        {
            if (CurrencyManager.instance.CheckCurrency(600))
            {
                CurrencyManager.instance.MinusCurrency(600);
                townSO.MilitaryLevel++;
                MilitaryLevel[townSO.MilitaryLevel - 1].sprite = LevelUp;
            }
        }
    }

    public void UpgradeAgriCulture()
    {
        if (townSO.AgricultureLevel == 1)
        {
            if (CurrencyManager.instance.CheckCurrency(200))
            {
                CurrencyManager.instance.MinusCurrency(200);
                townSO.AgricultureLevel++;
                AgricultureLevel[townSO.AgricultureLevel- 1].sprite = LevelUp;
            }
        }
        else if(townSO.AgricultureLevel == 2)
        {
            if (CurrencyManager.instance.CheckCurrency(400))
            {
                CurrencyManager.instance.MinusCurrency(400);
                townSO.AgricultureLevel++;
                AgricultureLevel[townSO.AgricultureLevel - 1].sprite = LevelUp;
            }
        }
        else if(townSO.AgricultureLevel == 3)
        {
            if (CurrencyManager.instance.CheckCurrency(600))
            {
                CurrencyManager.instance.MinusCurrency(600);
                townSO.AgricultureLevel++;
                AgricultureLevel[townSO.AgricultureLevel - 1].sprite = LevelUp;
            }
        }
    }

    #endregion

    public void setPlayer()
    {
        SetPlayerHealth();
        SetPlayerAttack();
        SetPlayerDefense();
        SetPlayerEnergyBar();
        SetPlayerEnergyRegen();
    }

    public void SetPlayerHealth()
    {
        if (townSO.HospitalsLevel == 1) PlayerSO.HP = 100;
        else if (townSO.HospitalsLevel == 2) PlayerSO.HP = 120;
        else if (townSO.HospitalsLevel == 3) PlayerSO.HP = 150;
        else if (townSO.HospitalsLevel == 4) PlayerSO.HP = 200;
    }

    public void SetPlayerEnergyBar()
    {
        if (townSO.ResearchLevel == 1) PlayerSO.EnergyBar = 100;
        else if (townSO.ResearchLevel == 2) PlayerSO.EnergyBar = 110;
        else if (townSO.ResearchLevel == 3) PlayerSO.EnergyBar = 125;
        else if (townSO.ResearchLevel == 4) PlayerSO.EnergyBar = 150;
    }

    public void SetPlayerAttack()
    {
        if (townSO.CulinaryLevel == 1)
        {
            AttackCombo[0].damage = 4;
            AttackCombo[1].damage = 5;
            AttackCombo[2].damage = 9;
        }
        else if (townSO.ResearchLevel == 2)
        {
            AttackCombo[0].damage = 6;
            AttackCombo[1].damage = 8;
            AttackCombo[2].damage = 11;
        }
        else if (townSO.ResearchLevel == 3)
        {
            AttackCombo[0].damage = 8;
            AttackCombo[1].damage = 10;
            AttackCombo[2].damage = 12;
        }
        else if (townSO.ResearchLevel == 4)
        {
            AttackCombo[0].damage = 9;
            AttackCombo[1].damage = 11;
            AttackCombo[2].damage = 15;
        }
    }

    public void SetPlayerDefense()
    {
        if (townSO.MilitaryLevel == 1) PlayerSO.Defense = 0;
        else if (townSO.MilitaryLevel == 2) PlayerSO.Defense = 1;
        else if (townSO.MilitaryLevel == 3) PlayerSO.Defense = 2;
        else if (townSO.MilitaryLevel == 4) PlayerSO.Defense = 3;
    }

    public void SetPlayerEnergyRegen()
    {
        if (townSO.AgricultureLevel == 1) PlayerSO.EnergyRegeneration = 0;
        else if (townSO.AgricultureLevel == 2) PlayerSO.EnergyRegeneration = 1;
        else if (townSO.AgricultureLevel == 3) PlayerSO.EnergyRegeneration = 2;
        else if (townSO.AgricultureLevel == 4) PlayerSO.EnergyRegeneration = 3;
    }

}
