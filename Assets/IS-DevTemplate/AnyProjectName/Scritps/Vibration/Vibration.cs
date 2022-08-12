using UnityEngine;

namespace ISDevTemplate.Vibration
{
    public static class Vibration
    {
        private static readonly IVibrationUnit m_Unit =
#if UNITY_ANDROID && !UNITY_EDITOR
        new CAndroidVibration();
#elif UNITY_IOS && !UNITY_EDITOR
        new CiOSVibration();
#else
    null;
#endif

        public static void Play()
        {
            if (m_Unit != null && SystemInfo.supportsVibration)
                m_Unit.Play();
        }

        public static void SetVibrationNumber(int number)
        {
#if UNITY_IOS && !UNITY_EDITOR
        var ios = m_Unit as CiOSVibration;
        ios.m_VibrationNumber = number;
#endif

#if UNITY_ANDROID && !UNITY_EDITOR
		var android = m_Unit as CAndroidVibration;
		android.SetValue(number);
#endif
        }
    }
}
