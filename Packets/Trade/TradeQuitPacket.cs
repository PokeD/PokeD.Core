﻿using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.Trade
{
    public class TradeQuitPacket : P3DPacket
    {
        public VarInt DestinationPlayerID { get { return VarInt.Parse(DataItems[0] == string.Empty ? 0.ToString() : DataItems[0], CultureInfo); } set { DataItems[0] = value.ToString(CultureInfo); } }


        public override VarInt ID => (int) GamePacketTypes.TradeQuit;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            if (reader.IsServer)
                DestinationPlayerID = reader.Read(DestinationPlayerID);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            if (!writer.IsServer)
                writer.Write(DestinationPlayerID);

            return this;
        }
    }
}
