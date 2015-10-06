﻿using Aragas.Core.Data;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Authorization
{
    public class EncryptionRequestPacket : ProtobufPacket
    {
        public byte[] PublicKey;
        public byte[] VerificationToken;

        public override VarInt ID => (int) SCONPacketTypes.EncryptionRequest;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            PublicKey = reader.Read(PublicKey);
            VerificationToken = reader.Read(VerificationToken);

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.Write(PublicKey);
            stream.Write(VerificationToken);

            return this;
        }
    }
}
