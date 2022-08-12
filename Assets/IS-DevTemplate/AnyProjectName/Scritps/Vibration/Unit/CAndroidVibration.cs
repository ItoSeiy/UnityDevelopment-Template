using UnityEngine;

namespace ISDevTemplate.Vibration
{
    public class CAndroidVibration : IVibrationUnit
	{
		private const long VIBRATION_TIME_MILLI_SECOND = 30;
		private const string VIBRATE_FUNCTION_NAME = "vibrate";
		private const string CANCEL_FUNCTION_NAME = "cancel";
		private long m_MilliSec = VIBRATION_TIME_MILLI_SECOND;


		private static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		private static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
		private static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");

		public void Play()
		{
			vibrator.Call(VIBRATE_FUNCTION_NAME, m_MilliSec);
		}

		public void Cancel()
		{
			vibrator.Call(CANCEL_FUNCTION_NAME);
		}

		public void SetValue(long milliSec)
		{
			m_MilliSec = milliSec;
		}
	}
}
