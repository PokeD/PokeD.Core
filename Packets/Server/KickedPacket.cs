﻿using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.Server
{
    public class KickedPacket : P3DPacket
    {
        public string Reason { get { return DataItems[0]; } set { DataItems[0] = value; } }


        public override int ID => (int) PlayerPacketTypes.Kicked;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            Reason = reader.ReadString();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream writer)
        {
            writer.WriteString(Reason);

            return this;
        }
    }
}
