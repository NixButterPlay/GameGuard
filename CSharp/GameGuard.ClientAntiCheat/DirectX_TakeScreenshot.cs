using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Direct3D11;
using SharpDX; //SharpDX to Take Screenshot from RustClient :D
using SharpDX.DXGI;
using System.Drawing;
using System.Drawing.Imaging;
using ScreenCapturerNS;

namespace GameGuard.ClientAntiCheat
{ 
    public class DirectXTakeScreenshot
    {
        public void StartCapAndStopCap()
        {
            ScreenCapturer.PreserveBitmap = true;
            ScreenCapturer.StartCapture();
            if (ScreenCapturer.IsActive)
            {
                ScreenCapturer.StopCapture();
            }
        }
    }

}
    
        
