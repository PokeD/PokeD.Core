﻿using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Status
{
    public class BanListRequestPacket : SCONPacket
    {
        public override VarInt ID => SCONPacketTypes.BanListRequest;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream stream)
        {
            return this;
        }
    }
}
