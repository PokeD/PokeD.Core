﻿using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.Remote.Authorization
{
    public class EncryptionRequestPacket : Packet
    {
        public string ServerId { get; set; }
        public byte[] PublicKey { get; set; }
        public byte[] VerificationToken { get; set; }

        public override int ID => (int) RemotePacketTypes.EncryptionRequestPacket;

        public override Packet ReadPacket(IPacketDataReader reader)
        {
            ServerId = reader.ReadString();
            var pkLength = reader.ReadVarInt();
            PublicKey = reader.ReadByteArray(pkLength);
            var vtLength = reader.ReadVarInt();
            VerificationToken = reader.ReadByteArray(vtLength);

            return this;
        }

        public override Packet WritePacket(IPacketStream stream)
        {
            stream.WriteString(ServerId);
            stream.WriteVarInt(PublicKey.Length);
            stream.WriteByteArray(PublicKey);
            stream.WriteVarInt(VerificationToken.Length);
            stream.WriteByteArray(VerificationToken);

            return this;
        }
    }
}