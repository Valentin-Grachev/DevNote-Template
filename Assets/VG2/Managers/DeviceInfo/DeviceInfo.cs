using VG2.Internal;


namespace VG2
{
    public enum ControlType { Desktop, Mobile }

    public class DeviceInfo : Manager
    {
        private static DeviceInfo instance;
        private static DeviceInfoService service => instance.supportedService as DeviceInfoService;

        protected override string managerName => "Device Definer";

        protected override void OnInitialized()
        {
            instance = this;
            Log(Core.Message.Initialized(managerName));
        }


        public static ControlType ControlType => service.GetDeviceType();


    }
}


