class Program
{
    static void Main(string[] args)
    {
        ArraySegment<byte> packetBuffer = new ArraySegment<byte>(new byte[1024], 0, 1024);
        int writePos = 0;
        int readPos = 0;

        const ushort gameStartProtocol = 1234;

        int[] data = new int[3] { 10, 20, 30 }; // Data Field

        // 직렬화 

        // 프로토콜
        Array.Copy(BitConverter.GetBytes(gameStartProtocol), 0, packetBuffer.Array, packetBuffer.Offset + writePos, sizeof(ushort));
        writePos += sizeof(ushort);
        // 패킷 길이. (헤더 + 데이터 필드)
        Array.Copy(BitConverter.GetBytes(4 + data.Length * sizeof(int)), 0, packetBuffer.Array, packetBuffer.Offset + writePos, sizeof(ushort));
        writePos += sizeof(ushort);
        // 데이터 필드
        Array.Copy(BitConverter.GetBytes(data[0]), 0, packetBuffer.Array, packetBuffer.Offset + writePos, sizeof(int));
        writePos += sizeof(int);
        Array.Copy(BitConverter.GetBytes(data[1]), 0, packetBuffer.Array, packetBuffer.Offset + writePos, sizeof(int));
        writePos += sizeof(int);
        Array.Copy(BitConverter.GetBytes(data[2]), 0, packetBuffer.Array, packetBuffer.Offset + writePos, sizeof(int));
        writePos += sizeof(int);

        //역직렬화.

        //프로토콜
        ushort protocolID = BitConverter.ToUInt16(packetBuffer.Array, readPos);
        readPos += sizeof(ushort);
        ushort packetLen = BitConverter.ToUInt16(packetBuffer.Array, readPos);
        readPos += sizeof(ushort);

        int data1 = BitConverter.ToInt32(packetBuffer.Array, readPos);
        readPos += sizeof(int);
        int data2 = BitConverter.ToInt32(packetBuffer.Array, readPos);
        readPos += sizeof(int);
        int data3 = BitConverter.ToInt32(packetBuffer.Array, readPos);
        readPos += sizeof(int);

        Console.WriteLine($"프로토콜 : {protocolID} 패킷 길이 : {packetLen}");
        Console.WriteLine($"데이터 : {data1},{data2},{data3}");

    }
}