using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopDialog : Dialog
{
    public Transform gridRoot;
    public ShopSkillUI skillUIPb;
    public GameObject alertPanel;

    public override void Show(bool isShow)
    {
        base.Show(isShow);

        UpdateUI();
    }
    private void UpdateUI()
    {
        var skills = ShopManager.Ins.skills;

        if (skills == null || skills.Length <= 0 || !gridRoot || !skillUIPb) return;

        ClearChilds();

        for(int i = 0; i < skills.Length; i++)
        {
            int idx = i;

            var skill = skills[i];

            if(skill != null)
            {
                var skillUIClone = Instantiate(skillUIPb, Vector3.zero, Quaternion.identity);

                skillUIClone.transform.SetParent(gridRoot);

                skillUIClone.transform.localScale = Vector3.one;

                skillUIClone.transform.localPosition = Vector3.zero;

                skillUIClone.UpdateUI(skill, idx);

                if (skillUIClone.btn)
                {
                    skillUIClone.btn.onClick.RemoveAllListeners();
                    skillUIClone.btn.onClick.AddListener(() => SkillEvent(skill, idx));
                }
            }
        }
    }

    void SkillEvent(ShopSkill skill, int shopSkillId)
    {
        if (skill == null) return;

        bool isUnlocked = Pref.GetBool(PrefConst.SKILL_PEFIX + shopSkillId);

        if (isUnlocked)
        {
            if (shopSkillId == Pref.CurSkillId) return;

            Pref.CurSkillId = shopSkillId;

            UpdateUI();
        }
        else
        {
            if(Pref.Coins >= skill.price)
            {
                Pref.Coins -= skill.price;

                Pref.SetBool(PrefConst.SKILL_PEFIX + shopSkillId, true);

                Pref.CurSkillId = shopSkillId;

                GUIManager.Ins.UpdateCoins();

                UpdateUI();
            } else
            {
                Debug.Log("You don't have enough coins!");
                AlertNoEnoughCoin();
            }
        }
    }

    public void ClearChilds()
    {
        if (!gridRoot || gridRoot.childCount <= 0) return;

        for(int i =0; i<gridRoot.childCount; i++)
        {
            var child = gridRoot.GetChild(i);
            if (child)
                Destroy(child.gameObject);
        }
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void AlertNoEnoughCoin()
    {
        alertPanel.SetActive(true);
    }
    public void CloseAlert()
    {
        alertPanel.SetActive(false);
    }

}
