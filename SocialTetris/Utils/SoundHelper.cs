using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SocialTetris.Utils
{
    public class SoundHelper
    {
        public static MediaElement BackgroundSound()
        {
            Uri mp3File = new Uri("pack://application:,,,/Tetris.mp3", UriKind.Absolute); 
            MediaElement m = new MediaElement();
            m.Source = mp3File;
            m.LoadedBehavior = MediaState.Manual;
            return m; 

        }
    }
}
