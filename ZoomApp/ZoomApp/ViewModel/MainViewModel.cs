using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ZoomApp.Common;
using ZoomApp.Services;

namespace ZoomApp.ViewModel
{
   public class MainViewModel : BindableObject
    {
    

        public string MeetId { set; get; }
        public string MeetPassword { set; get; }

        IZoomService zoomService;
        public MainViewModel()
        {
            zoomService = DependencyService.Get<IZoomService>();
            zoomService.InitZoomLib(Constants.AppKey,Constants.AppSecret);
        }

        ICommand joinMeetingCommand { set; get; }
        public ICommand JoinMeetingCommand => joinMeetingCommand = joinMeetingCommand ?? new Command(JoinMeeting);

        private void JoinMeeting(object obj)
        {
            if (!zoomService.IsInitialized())
            {
                return;
            }
            zoomService.JoinMeeting(MeetId, MeetPassword);
        }
    }
}
