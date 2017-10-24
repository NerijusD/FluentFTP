using System.IO;
using System.IO.Compression;

namespace FluentFTP.Helpers
{
    public class FtpGzip
    {
        public static byte[] Decompress(byte[] data)
        {
	        byte[] buffer = new byte[4 * 1024]; // 4k is traditional choice

			using (var input = new MemoryStream(data))
            {
                using (var output = new MemoryStream())
                {
					using (var deflateStream = new DeflateStream(input, CompressionMode.Decompress))
					{
						int read;
						while ((read = deflateStream.Read(buffer, 0, buffer.Length)) > 0)
						{
							output.Write(buffer, 0, read);
						}
                    }
                    return output.ToArray();
                }
            }
        }

        public static byte[] Compress(byte[] data)
        {
	        byte[] buffer = new byte[4 * 1024]; // 4k is traditional choice

			using (var input = new MemoryStream(data))
            {
                using (var output = new MemoryStream())
                {
                    using (var deflateStream = new DeflateStream(input, CompressionMode.Compress))
                    {
	                    int read;
	                    while ((read = deflateStream.Read(buffer, 0, buffer.Length)) > 0)
	                    {
		                    output.Write(buffer, 0, read);
	                    }
                    }
                    return output.ToArray();
                }
            }
        }
    }
}
