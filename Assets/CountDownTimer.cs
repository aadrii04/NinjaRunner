using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] TMP_Text countdownText;
    [SerializeField] GameObject bg;
    [SerializeField] float countdownTime = 3f;

    private void Start()
    {
        bg.SetActive(true);
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        while (countdownTime > 0)
        {
            countdownText.text = Mathf.Ceil(countdownTime).ToString();
            
            yield return new WaitForSeconds(1f);

            countdownTime--;
        }
        bg.SetActive(false);

        PlayerController.instance.StartPlayerMovement();
        EnemyController.instance.StartEnemyMovement();

        countdownText.text = "";
    }
}
