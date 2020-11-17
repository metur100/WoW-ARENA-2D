﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageReductionNum : MonoBehaviour
{
    public Image damageRed;
    public Animator animator;
    public FrostBall frostBallDamage = new FrostBall();
    public FireBall fireBallDamage = new FireBall();
    public BulletHunter bulletHunterDamage = new BulletHunter();
    public MeleePrefabHolyKnight meleeAttackDamageHolyKnight = new MeleePrefabHolyKnight();
    public MeleePrefabHolyKnightNum meleeAttackDamageHolyKnightNum = new MeleePrefabHolyKnightNum();
    public MeleePrefabKnight meleeAttackDamage = new MeleePrefabKnight();
    public int damageReductionFrostB = 0;
    public int damageReductionFireB = 0;
    public int damageReductionBulletHunt = 0;
    public int damageReductionMeleeAttackHolyKnight = 0;
    public int damageReductionMeleeAttackHolyKnightNum = 0;
    public int damageReductionMeleeAttack = 0;
    public int damageReductionMeleeAttackNum = 0;
    public int normalFrostBDmg = -20;
    public int normalFireBDmg = -50;
    public int normalBulletDamage = -10;
    public int normalMeleeAttackDamageHolyKnight = -20;
    public int normalMeleeAttackDamageHolyKnightNum = -20;
    public int normalMeleeAttackDamage = -20;
    public int normalMeleeAttackDamageNum = -20;
    private float dmgReductionDuration = 1f;
    private bool isCooldownDmgRed = false;
    private float DmgRedCooldown = 2f;
    private bool isBlock = false;
    //Start is called before the first frame update
    void Start()
    {
        damageRed.fillAmount = 0;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad3) && isCooldownDmgRed == false)
        {
            isCooldownDmgRed = true;
            damageRed.fillAmount = 1;
            StartCoroutine(DamageReductionDurationFrostB());
            FindObjectOfType<AudioManager>().Play("BlockedKnight");
        }
        if (isCooldownDmgRed)
        {
            damageRed.fillAmount -= 1 / DmgRedCooldown * Time.deltaTime;
            if (damageRed.fillAmount <= 0)
            {
                damageRed.fillAmount = 0;
                isCooldownDmgRed = false;
            }
        }
    }
    IEnumerator DamageReductionDurationFrostB()
    {
        frostBallDamage.damageDoneFrostB = damageReductionFrostB;
        fireBallDamage.damageDoneFireB = damageReductionFireB;
        bulletHunterDamage.damageDoneBullet = damageReductionBulletHunt;
        meleeAttackDamageHolyKnight.damageDoneMeleeAttack = damageReductionMeleeAttackHolyKnight;
        meleeAttackDamage.damageDoneMeleeAttack = damageReductionMeleeAttack;
        meleeAttackDamageHolyKnightNum.damageDoneMeleeAttack = damageReductionMeleeAttackHolyKnightNum;
        isBlock = true;
        animator.SetBool("IsBlock", isBlock);
        yield return new WaitForSeconds(dmgReductionDuration);
        isBlock = false;
        animator.SetBool("IsBlock", isBlock);
        frostBallDamage.damageDoneFrostB = normalFrostBDmg;
        fireBallDamage.damageDoneFireB = normalFireBDmg;
        bulletHunterDamage.damageDoneBullet = normalBulletDamage;
        meleeAttackDamageHolyKnight.damageDoneMeleeAttack = normalMeleeAttackDamageHolyKnight;
        meleeAttackDamage.damageDoneMeleeAttack = normalMeleeAttackDamage;
        meleeAttackDamageHolyKnightNum.damageDoneMeleeAttack = normalMeleeAttackDamageHolyKnightNum;
    }
}