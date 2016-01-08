﻿using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.PokeD.Trade
{
    public class TradeAcceptPacket : PokeDPacket
    {
        public VarInt DestinationID { get; set; }


        public override VarInt ID => (int) PokeDPacketTypes.TradeAccept;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            DestinationID = reader.Read(DestinationID);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            writer.Write(DestinationID);

            return this;
        }
    }
}
