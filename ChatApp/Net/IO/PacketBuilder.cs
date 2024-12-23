using System;
using System.IO;
using System.Text;


namespace ChatClient.Net.IO
{
    class PacketBuilder
    {
        MemoryStream _ms;
        public PacketBuilder()
        {
            _ms = new MemoryStream();
        }

        public void WrteOpCode(byte opcode)
        {
            _ms.WriteByte(opcode);
        }

        public void WriteMassage(string msg)
        {
            var msgLength = msg.Length;
            _ms.Write(BitConverter.GetBytes(msgLength));
            _ms.Write(Encoding.ASCII.GetBytes(msg));
        }

        public byte[] GetPoketBytes()
        {
            return _ms.ToArray();
        }
    }
}
