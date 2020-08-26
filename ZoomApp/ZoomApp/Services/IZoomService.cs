using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZoomApp.Services
{
    public interface IZoomService
    {
        bool IsInitialized();
        void InitZoomLib(string appKey, string appSecret);
        void JoinMeeting(string meetingID, string meetingPassword);
      //  bool LoginToZoom(string email, string password, bool rememberMe = true);
    }
}
