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




    public void HeroEffect_On(GameObject target)
    {

        GameObject effectHero = Instantiate(heroEffects[combatMgr.SaveSkill.Index]);
        effectHero.transform.position = target.transform.position + new Vector3(0, 0, -1);
        effectHero.transform.DOMove(effectHero.transform.position - new Vector3(-0.5f, 0f, 0f), 3f).SetLink(effectHero,LinkBehaviour.KillOnDestroy);
        Destroy(effectHero, 3f);



    }

    public void EnemyEffect_On(GameObject target)
    {
        GameObject effectEnemy = Instantiate(enemyEffects[0]);
        effectEnemy.transform.position = target.transform.position + new Vector3(0, 1, -1);
        Destroy(effectEnemy, 3f);

    }




}
