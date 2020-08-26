using Foundation;
using ObjCRuntime;
using System.Collections.Generic;
using System.Linq;
using ZoomApp.Common;
using ZoomApp.iOS.Services;
using ZoomApp.Services;
using Zoomios;

[assembly: Xamarin.Forms.Dependency(typeof(ZoomService))]
namespace ZoomApp.iOS.ZoomUtil
{
    public class ZoomService : IZoomService
    {
        MobileRTC mobileRTC;
        MobileRTCAuthService authService;
        public ZoomService()
        {
            mobileRTC = MobileRTC.SharedRTC;
        }

        public void InitZoomLib(string appKey, string appSecret)
        {
            mobileRTC.Initialize(new MobileRTCSDKInitContext
            {
                EnableLog = true,
                Domain = Common.Constants.Doomain
            });

            authService = mobileRTC.GetAuthService();
            if(authService != null)
            {
                authService.ClientKey = appKey;
                authService.ClientSecret = appSecret;
                authService.SdkAuth();
            }
        }

        public bool IsInitialized()
        {
            return mobileRTC?.IsRTCAuthorized() ?? false;
        }

        public void JoinMeeting(string meetingID, string meetingPassword)
        {
            if (IsInitialized())
            {
                var meetingService = mobileRTC.GetMeetingService();
                var ParamDict = new Dictionary<string, string>
                {
                    {Zoomios.Constants.kMeetingParam_Username,"Ham tube" },
                    {Zoomios.Constants.kMeetingParam_MeetingNumber,meetingID },
                    {Zoomios.Constants.kMeetingParam_MeetingPassword,meetingPassword }

                };

                var meetingParam = NSDictionary.FromObjectsAndKeys(ParamDict.Values.ToArray(), ParamDict.Keys.ToArray());
                var meetingJoinResponse = meetingService.JoinMeetingWithDictionary(meetingParam);
            }
        }
    }
}