using Xamarin.Forms;
using Olive.Droid.DS;
using Olive.FunzioniComuni;
using Olive.Model;
using Android.Media;

[assembly: Dependency(typeof(IAudio_android))]

namespace Olive.Droid.DS
{
    public class IAudio_android : IAudio
    {
        public IAudio_android()
        {
        }

        public void PlayAudioFile(string fileName)
        {
            var fx = ManageData.getValue("PlaySound");
            if (fx.SettingValue != "False")
            {
                var player = new MediaPlayer();
                var fd = global::Android.App.Application.Context.Assets.OpenFd(fileName);

                player.Prepared += (s, e) =>
                {
                    player.Start();
                };

                player.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
                player.Prepare();
            }

        }
    }
}





