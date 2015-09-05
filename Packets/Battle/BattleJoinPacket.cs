﻿using PokeD.Core.Interfaces;
using PokeD.Core.IO;

namespace PokeD.Core.Packets.Battle
{
    public class BattleJoinPacket : IPacket
    {
        public int DestinationPlayerID { get { return int.Parse(DataItems[0], CultureInfo); } set { DataItems[0] = value.ToString(CultureInfo); } }


        public override int ID => (int) PlayerPacketTypes.BattleJoin;

        public override IPacket ReadPacket(IPokeDataReader reader)
        {
            DestinationPlayerID = reader.ReadVarInt();

            return this;
        }

        public override IPacket WritePacket(IPokeStream writer)
        {
            writer.WriteVarInt(DestinationPlayerID);

            return this;
        }
    }
}
