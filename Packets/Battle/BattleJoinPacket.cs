﻿using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.Battle
{
    public class BattleJoinPacket : P3DPacket
    {
        public int DestinationPlayerID { get { return int.Parse(DataItems[0], CultureInfo); } set { DataItems[0] = value.ToString(CultureInfo); } }


        public override int ID => (int) GamePacketTypes.BattleJoin;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            if (reader.IsServer)
                DestinationPlayerID = reader.ReadVarInt();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream writer)
        {
            if (!writer.IsServer)
                writer.WriteVarInt(DestinationPlayerID);

            return this;
        }
    }
}
