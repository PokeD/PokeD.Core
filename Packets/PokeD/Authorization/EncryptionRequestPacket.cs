﻿using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.PokeD.Authorization
{
    public class EncryptionRequestPacket : PokeDPacket
    {
        public byte[] PublicKey;
        public byte[] VerificationToken;


        public override VarInt ID => PokeDPacketTypes.EncryptionRequest;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            PublicKey = reader.Read(PublicKey);
            VerificationToken = reader.Read(VerificationToken);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(PublicKey);
            stream.Write(VerificationToken);

            return this;
        }
    }
}
