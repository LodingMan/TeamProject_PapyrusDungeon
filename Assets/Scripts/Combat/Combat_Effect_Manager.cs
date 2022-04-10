using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Combat_Effect_Manager : MonoBehaviour
{
    public Light HitLight;
    public e_CombatManager combatMgr;
    public List<GameObject> heroEffects = new List<GameObject>();
    public List<GameObject> enemyEffects = new List<GameObject>();
    public List<int> buffSkillIndex = new List<int>(); //버프스킬 확인
    public List<AudioClip> sfx = new List<AudioClip>(); //스킬 사운드
    public List<AudioClip> eSfx = new List<AudioClip>(); //적 스킬 사운드
    public AudioSource audioSource;

    public bool isBuffSkill = false;



    public void HeroEffect_On(GameObject hero, GameObject target)
    {

        foreach (var item in buffSkillIndex)
        {
            if (buffSkillIndex.Contains(combatMgr.SaveSkill.Index))
            {
                    isBuffSkill = true;
                    break;
                }
                else
                {
                    isBuffSkill = false;
                    break;
                }
            
        }


        if (!isBuffSkill)
        {
            GameObject effectHero = Instantiate(heroEffects[combatMgr.SaveSkill.Index]);
            effectHero.transform.position = target.transform.position + new Vector3(0, 0, -1);;
            audioSource.PlayOneShot(sfx[combatMgr.SaveSkill.Index]);
            effectHero.transform.DOMove(effectHero.transform.position - new Vector3(-0.8f, 0f, 0f), 3f).SetLink(effectHero, LinkBehaviour.KillOnDestroy);
            Destroy(effectHero, 3f);
        }
        else
        {
            GameObject effectHero2 = Instantiate(heroEffects[combatMgr.SaveSkill.Index]);
            effectHero2.transform.position = hero.transform.position + new Vector3(0, 0, -1);
            audioSource.PlayOneShot(sfx[combatMgr.SaveSkill.Index]);
            effectHero2.transform.DOMove(effectHero2.transform.position - new Vector3(-1.4f, 0f, 0f), 3f).SetLink(effectHero2, LinkBehaviour.KillOnDestroy);
            Destroy(effectHero2, 3f);
        }




    }

    public void EnemyEffect_On(GameObject target)
    {
        GameObject effectEnemy = Instantiate(enemyEffects[0]);
        effectEnemy.transform.position = target.transform.position + new Vector3(0, 1, -1);
        audioSource.PlayOneShot(eSfx[combatMgr.SaveSkill.Index]);
        Destroy(effectEnemy, 3f);

    }




}
