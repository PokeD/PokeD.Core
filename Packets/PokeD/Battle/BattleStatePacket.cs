﻿using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

using PokeD.Core.Data.PokeD.Battle;
using PokeD.Core.Extensions;

namespace PokeD.Core.Packets.PokeD.Battle
{
    /// <summary>
    /// From Server
    /// </summary>
    public class BattleStatePacket : PokeDPacket
    {
        public BattleState BattleState { get; set; }


        public override VarInt ID => (int) PokeDPacketTypes.BattleState;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            BattleState = reader.Read(BattleState);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            //writer.Write(BattleState);

            return this;
        }
    }
}