﻿using Aragas.Core.Data;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.Server
{
    public class ServerClosePacket : P3DPacket
    {
        public string Reason { get { return DataItems[0]; } set { DataItems[0] = value; } }


        public override VarInt ID => (int) GamePacketTypes.ServerClose;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            Reason = reader.Read(Reason);

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream writer)
        {
            writer.Write(Reason);

            return this;
        }
    }
}
