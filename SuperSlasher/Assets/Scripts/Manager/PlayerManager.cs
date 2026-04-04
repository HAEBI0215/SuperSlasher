using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("체력")]
    public int maxPlayerHp = 100;
    public int currentPlayerHp;

    public SkillControll skillControll;
    public PlayerMove playerMove;

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
