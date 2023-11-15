using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
using System;

public class NotificationManager : MonoBehaviour
{
	public static NotificationManager Instance { get; private set; }

	private void Awake()
	{
		Instance = this;

		AndroidNotificationCenter.CancelAllNotifications();

		var notificationChannel = new AndroidNotificationChannel()
		{
			Id = "main_notif_channel",
			Name = "Main Channel",
			Description = "Main channel of my notifications",
			Importance = Importance.High
		};

		AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);

		CreateNotification("Volvé a jugar", "Ya pasó mucho tiempo", 20);
	}

	public int CreateNotification(string title, string text, float timeToSend)
	{
		var notification = new AndroidNotification()
		{
			Title = title,
			Text = text,
			LargeIcon = "reminder_large",
			SmallIcon = "reminder_small",
			FireTime = DateTime.Now.AddSeconds(timeToSend)
		};

		int id = AndroidNotificationCenter.SendNotification(notification, "main_notif_channel");
		return id;
	}

	public void CancelNotif(int notifId)
	{
		AndroidNotificationCenter.CancelScheduledNotification(notifId);
	}
}
