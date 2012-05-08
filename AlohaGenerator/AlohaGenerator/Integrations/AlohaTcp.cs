using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlohaGenerator.Integrations
{
    class AlohaTcp : IntegrationBase
    {
        #region IntegrationBase Implementation

        public override string DisplayName
        {
            get { return "Aloha TCP"; }
        }

        public override Type ControlType
        {
            get { return typeof (AlohaSerialControl); }
        }

        public override Type SenderType
        {
            get { return typeof (SerialSender); }
        }

        public override Type GeneratorType
        {
            get { return typeof (AlohaMessageGenerator); }
        }

        #endregion
    }
}
