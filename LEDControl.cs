namespace DPUruNet
{
class LEDControl
    {

        /*For 5160 and 5100 module
            LED Main is the background light.
            LED REJECT is the surface red light.
            LED ACCEPT is the surface green light.
            LED FINGER_DETECT is the runner (side) blue lights
        */
        public enum LED { MAIN=1, REJECT=4, ACCEPT=8, FINGER_DETECT=16};  
        public enum LED_CMD { OFF=0, ON };
        public enum LED_MODE { AUTO = 1, CLIENT }; //CLIENT mode allows the client application to override default LED behavior
        

        [DllImport("dpfpdd.dll")]
        private static extern int dpfpdd_led_config(IntPtr devHandle, LED led, LED_MODE led_mode, IntPtr reserved);

        [DllImport("dpfpdd.dll")]
        private static extern int dpfpdd_led_ctrl(IntPtr devHandle, LED led_id, LED_CMD led_cmd);

        //Must be called to get device handle to control the LEDs (this must be coupled with a ReleaseReaderHandle)
        public static IntPtr GetReaderHandle(DPUruNet.Reader reader)
        {
            //We must use reflection here to get the private device handle
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            FieldInfo field =   reader.GetType().GetField("m_handle", flags);
            System.Runtime.InteropServices.SafeHandle privateHandle = (System.Runtime.InteropServices.SafeHandle)field.GetValue(reader);
            Boolean bSuccess = false;

            if (privateHandle != null)
                privateHandle.DangerousAddRef(ref bSuccess);   //increment the reference counter for the reader\device handle
               
            if (bSuccess) return privateHandle.DangerousGetHandle(); //return the handle to the caller
            
            else return IntPtr.Zero;
        }

        //Must be called before controlling the LEDs.  
        public static int Configure(IntPtr devHandle, LED led, LED_MODE mode)
        {
            return dpfpdd_led_config(devHandle, led, mode, IntPtr.Zero);
        }

        //Allows the changing of the LED state
        public static int Toggle(IntPtr devHandle, LED led, LED_CMD command)
        {
            return dpfpdd_led_ctrl(devHandle, led, command);
        }

        //Release the device handle counter.  Must be called for every GetReaderHandle to prevent resource leak.
        public static void ReleaseReaderHandle(DPUruNet.Reader reader)
        {
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            FieldInfo field = reader.GetType().GetField("m_handle", flags);
            System.Runtime.InteropServices.SafeHandle privateHandle = (System.Runtime.InteropServices.SafeHandle)field.GetValue(reader);
            if (privateHandle != null && !privateHandle.IsInvalid && !privateHandle.IsClosed)
            {
                privateHandle.DangerousRelease();    //decrement the device handle counter so the reader can be freed     
            } 
        }

    }
}
