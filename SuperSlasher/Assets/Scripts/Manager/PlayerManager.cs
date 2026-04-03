using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("체력")]
    public int maxPlayerHp = 100;
    public int currentPlayerHp;

    [Header("스킬")]
    public float skillGauge = 0.0f;
    public float maxSkillGauge = 50.0f;
    public bool isSkillReady = false;
    public SkillControll skillControll;

    void Start()
    {
        currentPlayerHp = maxPlayerHp;
        skillGauge = maxSkillGauge;
    }

    void Update()
    {
        ExcuteSkill();
        TakeDamage(0);
    }

    private void ExcuteSkill()
    {
        if (skillGauge <= 0)
            return;

        // if (Input.GetKeyDown(KeyCode.Q) && skillGauge >= skillData.coast)
        // {
        //     skillControll.RushSlash(0);
        //     skillGauge -= skillData.coast;
        // }
        // if (Input.GetKeyDown(KeyCode.E) && skillGauge >= skillData.coast)
        // {
        //     skillControll.ThrowsScythe(1);
        //     skillGauge -= skillData.coast;
        // }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            skillControll.RushSlash(0);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            skillControll.ThrowsScythe(1);
        }
    }

    public void TakeDamage(int damage)
    {
        currentPlayerHp -= damage;

        if (currentPlayerHp <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("사망");
        }
    }
}
