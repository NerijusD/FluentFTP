using System.IO;
using System.IO.Compression;

namespace FluentFTP.Helpers
{
    public class FtpGzip
    {
        public static byte[] Decompress(byte[] data)
        {
            using (var input = new MemoryStream(data))
            {
                using (var output = new MemoryStream())
                {
                    using (var deflateStream = new DeflateStream(input, CompressionMode.Decompress))
                    {
                        deflateStream.CopyTo(output);
                    }
                    return output.ToArray();
                }
            }
        }

        public static byte[] Compress(byte[] data)
        {
            using (var input = new MemoryStream(data))
            {
                using (var output = new MemoryStream())
                {
                    using (var deflateStream = new DeflateStream(input, CompressionMode.Compress))
                    {
                        deflateStream.CopyTo(output);
                    }
                    return output.ToArray();
                }
            }
        }
    }
}
