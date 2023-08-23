using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSkillUI : MonoBehaviour
{
    public Text priceText;
    public Image SkillVFXImage;
    public Button btn;

    public void UpdateUI(ShopSkill skill,int shopSkillId)
    {
        if (skill == null) return;

        if (SkillVFXImage)
        {
            SkillVFXImage.sprite = skill.VFXImage;
        }
        bool isUnlocked = Pref.GetBool(PrefConst.SKILL_PEFIX + shopSkillId);

        if (isUnlocked)
        {
            if(shopSkillId == Pref.CurSkillId)
            {
                if (priceText)
                    priceText.text = "Active";
            }
            else
            {
                if (priceText)
                    priceText.text = "OWNER";
            }
        } else
        {
            if (priceText)
                priceText.text = skill.price.ToString();
        }
    }
}
