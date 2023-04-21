using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{
    public Animator characterAnimator;
    public Animator damageAnimator;
    public DamageIndicator damageIndicator;

    //damage canvas prefab
    public GameObject damagePrefab;

    public CharacterData characterData;

    public GameObject playerCam;
    public GameObject enemyCam;

    public trackswitcher playerSwitch;
    public trackswitcher enemySwitch;

    public Coroutine characterBaseLoop;
    public Coroutine attackQueue = null;
    public Coroutine enemyAttackBehaviour;

    [HideInInspector]
    public CharacterControl cachedTarget;

    [HideInInspector]
    public AbilityData lastAbilityUsed;

    private void Awake()
    {
        characterData._charCont = this;
        characterAnimator = GetComponent<Animator>();
        damageAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        characterData.Init();

        //Debug Function
        /*if(characterData.characterTeam == CharacterTeam.Friendly)
        characterData._target = targetData.characterData;*/

        characterBaseLoop = StartCoroutine(characterData.CharacterLoop());

        // enemyAttackBehaviour = StartCoroutine(AttackRandomFriendlyCharacter());
    }

    public void ClearAttackQueue()
    {
        if (attackQueue != null)
        {
            StopCoroutine(attackQueue);
            attackQueue = null;
        }
        
    }

    public void AttackAnimation()
    {
        characterAnimator.Play("Attack", 0);
    }

    public void LimitBurstAnimation()
    {
        characterAnimator.Play("Limit", 0);
    }

    public void AttakedAnimation()
    {
        characterAnimator.Play("Attacked", 0);
    }

    public void AbilityAnimation()
    {
        characterAnimator.Play("Ability", 0);
    }

    public void SpawnParticleOnTarget()
    {
        if (lastAbilityUsed.attackParticle != null && lastAbilityUsed.type == AbilityType.Ranged)
        {
            GameObject tmpParticle = Instantiate(lastAbilityUsed.attackParticle);
            tmpParticle.transform.position = new Vector3(cachedTarget.transform.position.x, cachedTarget.transform.position.y +1, cachedTarget.transform.position.z);

            ParticleSystem particleComponent = tmpParticle.GetComponent<ParticleSystem>();

            Destroy(tmpParticle, particleComponent.main.duration);
        } 
    }

    public void AttackingTarget()
    {
        characterData.characterState = CharacterState.Attacking;
        characterData._target.SaveCharacterState();
        characterData._target.characterState = CharacterState.Attacked;
    }

    public void FinishedAttackingTarget()
    {
        switch (characterData.attackSelected.output)
        {
            case AbilityOutput.Damage:
                characterData._target.Damage(characterData.attackSelected.abValue);
                break;
            case AbilityOutput.Heal:
                characterData._target.Heal(characterData.attackSelected.abValue);
                break;
        }

        Vector3 targetPosition = characterData._target._charCont.transform.position;
       
        GameObject dmgPrefab = Instantiate(damagePrefab);//, characterData._target._charCont.transform.position);
        dmgPrefab.transform.position = new Vector3(targetPosition.x, targetPosition.y + 2, targetPosition.z);
        dmgPrefab.transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);

        Text dmgText = dmgPrefab.GetComponentInChildren<Text>();
        dmgText.text = characterData.attackSelected.abValue.ToString();

        Animator dmgAnimation = dmgPrefab.GetComponent<Animator>();
        DamageIndicator dmgIndicator = dmgPrefab.AddComponent<DamageIndicator>();

        dmgPrefab.SetActive(true);
        dmgAnimation.Play("damageAnimation");


        //damageText.transform.LookAt(2 * damageText.transform.position - Camera.main.transform.position);
        //damageIndicator.SetDamageGraphicPosition(characterData._target._charCont, characterData.attackSelected.abValue.ToString());

        characterData._target = null;
        characterData.characterState = CharacterState.Idle;
    }

    public IEnumerator AttackRandomFriendlyCharacter()
    {
        if (characterData.characterTeam == CharacterTeam.Enemy)
        {
            while (characterData.IsAlive)
            {
                yield return new WaitUntil(() => characterData.IsReadyForAction);
                
                //Select a random friendly target.
                while (characterData._target == null || characterData._target.characterState == CharacterState.Died)
                {
                        if (BattleManager.Instance.FriendlyCharacterAlive && characterData.characterState == CharacterState.GoingAttack)
                        {
                            playerCam.gameObject.SetActive(true);
                            enemyCam.gameObject.SetActive(false);
                            characterData._target = BattleManager.Instance.RandomFriendlyCharacter.characterData;
                            yield return null;
                        }  
                        else
                        {
                            yield break;
                        }

                    yield return null;
                }
                
                yield return characterData.QueueAttack(characterData.basicAttack);

                //This code will be executed whenever the queue attack has been finished.

                yield return null;

            }

        }
    }

    public void StopAll()
    {
        if (characterBaseLoop != null)
        {
            StopCoroutine(characterBaseLoop); 
        }

        if (attackQueue != null)
        {
           StopCoroutine(attackQueue);
        }

        if (enemyAttackBehaviour != null)
        {
            StopCoroutine(enemyAttackBehaviour);
        }

        characterBaseLoop = null;
        characterBaseLoop = null;
        enemyAttackBehaviour = null;
        characterData.characterState = CharacterState.Finish;
    }

}
