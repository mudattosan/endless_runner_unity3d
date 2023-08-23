using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : Singleton<ShopManager>
{
    public ShopSkill[] skills;

    public override void Awake()
    {
        MakeSingleton(true);
    }
    private void Start()
    {
        if(skills == null || skills.Length <= 0)
        {
            return;
        }
        
        for (int i = 0; i < skills.Length; i++)
        {
            var skill = skills[i];

            if(skill != null)
            {
                if(i == 0)
                {
                    Pref.SetBool(PrefConst.SKILL_PEFIX + i , true); // skill_0
                }
                else
                {
                    // skill_1, skill_2 ...
                    if(!PlayerPrefs.HasKey(PrefConst.SKILL_PEFIX + i))
                    {
                        Pref.SetBool(PrefConst.SKILL_PEFIX + i, false);
                    }
                }
            }
        }
    }
}
[System.Serializable]
public class ShopSkill
{
    public int price;
    public Sprite VFXImage;
    public GameObject SkillPb;
}
