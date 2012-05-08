using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlohaGenerator.Senders;

namespace AlohaGenerator.Controls
{
    public abstract class SettingControlBase : UserControl
    {
        public abstract ConnectionInfo ConnectInfo {get;}
    }
}
