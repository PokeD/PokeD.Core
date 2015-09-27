﻿using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Status
{
    public class PlayerDatabaseListRequestPacket : ProtobufPacket
    {
        public override int ID => (int) SCONPacketTypes.PlayerDatabaseListRequest;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            return this;
        }
    }
}
