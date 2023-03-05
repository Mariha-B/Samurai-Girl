using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    // Start is called before the first frame update
   private void Start()
    {
        //Starts at 3 lives
        totalhealthBar.fillAmount = playerHealth.currentHealth /3 ;
    }

    // Update is called once per frame
    private void Update()
    { //Update current health
        currenthealthBar.fillAmount = playerHealth.currentHealth /3;

    }
}
