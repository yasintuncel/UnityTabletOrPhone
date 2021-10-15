using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts
{
    [RequireComponent(typeof(DeviceTypeDefiner))]
    public class DeviceLander : MonoBehaviour
    {
        private void Awake()
        {
            DeviceTypes deviceType = GetComponent<DeviceTypeDefiner>().GetDeviceType();

            switch (deviceType)
            {
                case DeviceTypes.PHONE:
                    SceneManager.LoadScene("PhoneScene");
                    break;
                case DeviceTypes.TABLET:
                    SceneManager.LoadScene("TabletScene");
                    break;
                default:
                    break;
            }
        }
    }
}