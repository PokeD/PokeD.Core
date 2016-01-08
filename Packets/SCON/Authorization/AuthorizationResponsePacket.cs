﻿using System;

using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Authorization
{
    [Flags]
    public enum AuthorizationStatus
    {
        EncryprionEnabled = 1
    }

    public class AuthorizationResponsePacket : SCONPacket
    {
        public AuthorizationStatus AuthorizationStatus { get; set; }

        public override VarInt ID => (int) SCONPacketTypes.AuthorizationResponse;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            AuthorizationStatus = (AuthorizationStatus) reader.Read((byte) AuthorizationStatus);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream stream)
        {
            stream.Write((byte) AuthorizationStatus);

            return this;
        }
    }
}