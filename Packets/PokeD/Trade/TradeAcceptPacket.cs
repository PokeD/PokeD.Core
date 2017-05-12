﻿using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.PokeD.Trade
{
    public class TradeAcceptPacket : PokeDPacket
    {
        public VarInt DestinationID { get; set; }


        public override VarInt ID => PokeDPacketTypes.TradeAccept;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            DestinationID = reader.Read(DestinationID);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream writer)
        {
            writer.Write(DestinationID);

            return this;
        }
    }
}
