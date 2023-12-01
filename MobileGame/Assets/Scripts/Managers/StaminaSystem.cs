using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StaminaSystem : MonoBehaviour
{
    [SerializeField] int maxStamina = 10;

    [SerializeField] float timeToRecharge = 10f;

    int currentStamina;
    int notifId;

    DateTime nextStaminaTime;
    DateTime lastStaminaTime;

    [SerializeField] TextMeshProUGUI staminaText = null;
    [SerializeField] TextMeshProUGUI timerText = null;

    bool recharging;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("CurrentStamina"))
        {
            currentStamina = maxStamina;
            Save();
        }

        Load();

        Debug.Log(nextStaminaTime.ToString());
        UpdateStaminaUI();
        UpdateTimerUI();

        SendNotification();

        StartCoroutine(StaminaRecharging());
    }

    IEnumerator StaminaRecharging()
    {
        recharging = true;
        while (currentStamina < maxStamina)
        {
            DateTime currentTime = DateTime.Now;
            DateTime nextTime = nextStaminaTime;

            bool staminaAdd = false;

            while (currentTime > nextTime)
            {
                if (currentStamina >= maxStamina)
                    break;

                staminaAdd = true;
                currentStamina += 1;

                DateTime timeToAdd = nextTime;

                if (lastStaminaTime > nextTime)
                    timeToAdd = lastStaminaTime;

                nextTime = AddDuration(timeToAdd, timeToRecharge);

            }

            if (staminaAdd)
            {
                lastStaminaTime = DateTime.Now;
                nextStaminaTime = nextTime;
            }
            Save();
            UpdateStaminaUI();
            UpdateTimerUI();
            yield return new WaitForEndOfFrame();
        }
        recharging = false;
    }

    DateTime AddDuration(DateTime dateTime, float timeToAdd)
    {
        return dateTime.AddSeconds(timeToAdd);
    }

    public void UseStamina(int staminaToUse)
    {
        if (currentStamina - staminaToUse < 0)
        {
            Debug.LogError("No tengo suficiente stamina");
            return;
        }

        currentStamina -= staminaToUse;
        UpdateStaminaUI();
        if (!recharging)
        {
            nextStaminaTime = AddDuration(DateTime.Now, timeToRecharge);
            StartCoroutine(StaminaRecharging());
        }
        SendNotification();
        Save();
    }

    public void RechargeStamina(int staminaToAdd)
    {
        int rechargedStamina = currentStamina += staminaToAdd;
        UpdateStaminaUI();
        Save();
        if (rechargedStamina >= maxStamina)
		{
            rechargedStamina = maxStamina;
            UpdateTimerUI();
		}

        SendNotification();

    }

    void UpdateStaminaUI()
    {
        staminaText.text = currentStamina.ToString() + "/" + maxStamina.ToString();
    }

    void UpdateTimerUI()
    {
        if (currentStamina >= maxStamina)
        {
            timerText.text = "";
            return;
        }

        var timer = nextStaminaTime - DateTime.Now;

        timerText.text = timer.Minutes.ToString("00") + ":" + timer.Seconds.ToString("00");
    }

    void Save()
    {
        PlayerPrefs.SetInt("CurrentStamina", currentStamina);
        PlayerPrefs.SetString("LastStaminaTime", lastStaminaTime.ToString());
        PlayerPrefs.SetString("NextStaminaTime", nextStaminaTime.ToString());
    }

    void Load()
    {
        currentStamina = PlayerPrefs.GetInt("CurrentStamina");
        lastStaminaTime = StringToDateTime(PlayerPrefs.GetString("LastStaminaTime"));
        nextStaminaTime = StringToDateTime(PlayerPrefs.GetString("NextStaminaTime"));
    }

    DateTime StringToDateTime(string date)
    {
        if (string.IsNullOrEmpty(date))
            return DateTime.Now;
        else
            return DateTime.Parse(date);
    }

    void SendNotification()
    {
        NotificationManager.Instance.CancelNotif(notifId);

        if (currentStamina >= maxStamina) return;

        var timer = (nextStaminaTime - DateTime.Now).Seconds;
        float timeToSend = (maxStamina - currentStamina - 1) * timeToRecharge + timer;
        notifId = NotificationManager.Instance.CreateNotification("Ya tenés toda la Stamina", "Podés volver a jugar", timeToSend);
    }
}
