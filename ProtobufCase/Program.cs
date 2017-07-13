using System.IO;
using ProtoBuf;

namespace ProtobufCase
{
    [ProtoContract]
    class A
    {
        static A() { }

        [ProtoMember(1)]
        public int Value { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var stream = new MemoryStream())
            {
                var a = new A();
                Serializer.Serialize(stream, a);
                stream.Seek(0, SeekOrigin.Begin);
                var b = Serializer.Deserialize<A>(stream);
            }
        }
    }
}
