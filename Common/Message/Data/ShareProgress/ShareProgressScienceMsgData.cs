﻿using Lidgren.Network;
using LunaCommon.Message.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunaCommon.Message.Data.ShareProgress
{
    /// <summary>
    /// Data packet for sending science changes between clients.
    /// </summary>
    public class ShareProgressScienceMsgData : ShareProgressBaseMsgData
    {
        /// <inheritdoc />
        internal ShareProgressScienceMsgData() { }
        public override ShareProgressMessageType ShareProgressMessageType => ShareProgressMessageType.ScienceUpdate;

        public float Science;
        public string Reason;

        public override string ClassName { get; } = nameof(ShareProgressScienceMsgData);

        internal override void InternalSerialize(NetOutgoingMessage lidgrenMsg)
        {
            base.InternalSerialize(lidgrenMsg);

            lidgrenMsg.Write(Science);
            lidgrenMsg.Write(Reason);
        }

        internal override void InternalDeserialize(NetIncomingMessage lidgrenMsg)
        {
            base.InternalDeserialize(lidgrenMsg);

            Science = lidgrenMsg.ReadFloat();
            Reason = lidgrenMsg.ReadString();
        }

        internal override int InternalGetMessageSize()
        {
            return base.InternalGetMessageSize() + sizeof(float);
        }
    }
}
