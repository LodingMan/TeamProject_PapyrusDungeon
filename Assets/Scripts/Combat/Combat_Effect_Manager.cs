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

    public bool isBuffSkill = false;



    public void HeroEffect_On(GameObject target)
    {
        for (int i = 0; i < buffSkillIndex.Count; i++)
        {
            if (combatMgr.SaveSkill.Index == buffSkillIndex[i])
            {
                isBuffSkill = true;
                break;
            }
        }

        if (!isBuffSkill)
        {
            GameObject effectHero = Instantiate(heroEffects[combatMgr.SaveSkill.Index]);
            effectHero.transform.position = target.transform.position + new Vector3(0, 0, -1);
            effectHero.transform.DOMove(effectHero.transform.position - new Vector3(-0.5f, 0f, 0f), 3f).SetLink(effectHero, LinkBehaviour.KillOnDestroy);
            Destroy(effectHero, 3f);
        }
        else
        {
            GameObject effectHero2 = Instantiate(heroEffects[combatMgr.SaveSkill.Index]);
            effectHero2.transform.position = target.transform.position + new Vector3(0, 0, -1);
            effectHero2.transform.DOMove(effectHero2.transform.position - new Vector3(-0.5f, 0f, 0f), 3f).SetLink(effectHero2, LinkBehaviour.KillOnDestroy);
            Destroy(effectHero2, 3f);
        }




    }

    public void EnemyEffect_On(GameObject target)
    {
        GameObject effectEnemy = Instantiate(enemyEffects[0]);
        effectEnemy.transform.position = target.transform.position + new Vector3(0, 1, -1);
        Destroy(effectEnemy, 3f);

    }




}
