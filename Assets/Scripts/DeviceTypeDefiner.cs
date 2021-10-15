using UnityEngine;

namespace Scripts
{
    public enum DeviceTypes
    {
        PHONE,
        TABLET
    }
    public class DeviceTypeDefiner : MonoBehaviour
    {
        private float DeviceDiagonalSizeInInches()
        {
            float screenWidth = Screen.width / Screen.dpi;
            float screenHeight = Screen.height / Screen.dpi;
            float diagonalInches = Mathf.Sqrt(Mathf.Pow(screenWidth, 2) + Mathf.Pow(screenHeight, 2));

            return diagonalInches;
        }
        public DeviceTypes GetDeviceType()
        {
#if UNITY_IOS
    bool deviceIsIpad = UnityEngine.iOS.Device.generation.ToString().Contains("iPad");
            if (deviceIsIpad)
            {
                return ENUM_Device_Type.Tablet;
            }
            bool deviceIsIphone = UnityEngine.iOS.Device.generation.ToString().Contains("iPhone");
            if (deviceIsIphone)
            {
                return ENUM_Device_Type.Phone;
            }
#elif UNITY_ANDROID
            float aspectRatio = Mathf.Max(Screen.width, Screen.height) / Mathf.Min(Screen.width, Screen.height);
            bool isTablet = (DeviceDiagonalSizeInInches() > 6.5f && aspectRatio < 2f);

            if (isTablet)
            {
                return DeviceTypes.TABLET;
            }
            else
            {
                return DeviceTypes.PHONE;
            }
#endif
        }
    }
}