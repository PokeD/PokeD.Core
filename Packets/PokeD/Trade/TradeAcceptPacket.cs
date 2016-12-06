﻿using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.PokeD.Trade
{
    public class TradeAcceptPacket : PokeDPacket
    {
        public VarInt DestinationId { get; set; }


        public override VarInt ID => PokeDPacketTypes.TradeAccept;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            DestinationId = reader.Read(DestinationId);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream writer)
        {
            writer.Write(DestinationId);

            return this;
        }
    }
}
