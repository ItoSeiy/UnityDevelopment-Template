namespace ISDevTemplate.Vibration
{
    public class CiOSVibration : IVibrationUnit
    {
        // デフォルト
        public int m_VibrationNumber = 1003;

        public void Play()
        {
            PlayVibration(1, m_VibrationNumber);
        }

        public void Cancel()
        {
        }

#if !UNITY_EDITOR && UNITY_IOS
        [DllImport("__Internal")]
        static extern void _PlayVibration (int vibrationCount,int vibrationNumber);
#endif

        private static void PlayVibration(int frequency, int vibrationNumber)
        {

#if !UNITY_EDITOR && UNITY_IOS
            _PlayVibration(frequency, vibrationNumber);
#endif
        }
    }
}
