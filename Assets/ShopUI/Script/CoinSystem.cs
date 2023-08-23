using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSystem : Singleton<CoinSystem>
{
    public static GameObject pl_Skill;
    public override void Awake()
    {
        MakeSingleton(true);
    }
    public override void Start()
    {
        base.Start();

        if(!PlayerPrefs.HasKey(PrefConst.COIN_KEY))
        {
            Pref.Coins = 500;
        }
        // ActiveSkill();
        pl_Skill = ShopManager.Ins.skills[Pref.CurSkillId].SkillPb;

        GUIManager.Ins.UpdateCoins();
    }

    /*public void ActiveSkill()
    {
        if(pl_Skill)
        {
            Destroy(pl_Skill.gameObject);
        }
        var newSkillPb = ShopManager.Ins.skills[Pref.CurSkillId].SkillPb;
        if (newSkillPb)
            pl_Skill = Instantiate(newSkillPb);
        Debug.Log(pl_Skill);
    } */

}
