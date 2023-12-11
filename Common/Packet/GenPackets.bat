START ../../PacketGenerator/bin/PacketGenerator.exe ../../PacketGenerator/PDL.xml
XCOPY /Y GenPackets.cs "../../DummyClient/Packet"
XCOPY /Y GenPackets.cs "../../Server/Packet"
XCOPY /Y ClientPacketManager.cs "../../DummyClient/Packet"
XCOPY /Y ServerPacketManager.cs "../../Server/Packet"



XCOPY /Y ClientPacketManager.cs "D:/LeeTaeSeop/Programing/Game Engine/Unity/PortPolio/Sutdy/Assets/005_Rookiss_GameServer/Packet"
XCOPY /Y GenPackets.cs "D:/LeeTaeSeop/Programing/Game Engine/Unity/PortPolio/Sutdy/Assets/005_Rookiss_GameServer/Packet"
