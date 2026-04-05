using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("체력")]
    public int maxPlayerHp = 100;
    public int currentPlayerHp;

    [Header("스킬 키")]
    public KeyCode rushSlashKey = KeyCode.Q;
    public KeyCode throwScytheKey = KeyCode.E;
    public KeyCode ultKey = KeyCode.R;

    public SkillControll skillControll;

    void Start()
    {
        currentPlayerHp = maxPlayerHp;
    }

    void Update()
    {
        ExcuteSkill();
        TakeDamage(0);
    }

    private void ExcuteSkill()
    {
        if (skillControll == null)
        {
            return;
        }

        if (Input.GetKeyDown(rushSlashKey))
        {
            skillControll.RushSlash(0);
        }

        if (Input.GetKeyDown(throwScytheKey))
        {
            skillControll.ThrowsScythe(1);
        }

        if (Input.GetKeyDown(ultKey))
        {
            skillControll.ULT(2);
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
