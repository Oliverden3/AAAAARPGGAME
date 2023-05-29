using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StaminaFill : MonoBehaviour
{
    GameObject attack;
    bool isAttacking;
    bool isUpdating;
    float countUp;
    float goal;
    [SerializeField] private Image _staminaSprite;
    // Start is called before the first frame update
    void Start(){
        attack = GameObject.Find("MainAttack");
        isUpdating = false;
    }
    void Update()
    {
      /*  isAttacking = attack.GetComponent<DamageField>().isAttacking;
        if(isAttacking == true && isUpdating == false){
            isUpdating = true;
            updateStamina();
        }*/
        
    }
    public void updateStamina(){
    StartCoroutine(StartCounter());
    }
    private IEnumerator StartCounter()
    {
         goal = 2f;
         countUp = 0f;
         for (int i=0; i < 2000; i++) 
         {
             while (countUp < goal)
             {
                 countUp += Time.smoothDeltaTime;
                 _staminaSprite.fillAmount = countUp/2;
                 Debug.Log(_staminaSprite.fillAmount);
                 yield return null;
             }
         }
     }
}
