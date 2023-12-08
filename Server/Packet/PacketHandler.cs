﻿using Server;
using ServerCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

class PacketHandler
{
    public static void C_ChatHandler(PacketSession session, IPacket packet)
    {
        C_Chat chatPacket = packet as C_Chat;
        ClientSession clientSession = session as ClientSession;

        if (clientSession.Room == null)
            return;

        clientSession.Room.Broadcast(clientSession, chatPacket.chat);


    }

    public static void TestHandler(PacketSession session, IPacket packet)
    {
        
    }
}
