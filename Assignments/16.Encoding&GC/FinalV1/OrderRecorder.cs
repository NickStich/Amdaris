using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalV1
{
    class OrderRecorder
    {
        public static void RecordOrderInCart(string pathOfTheFile, string order)
        {
            //using (FileStream fileStream = new FileStream(pathOfTheFile, FileMode.Open))
            //{
            //    var bytesOfOrder = Encoding.ASCII.GetBytes(order);
            //    var numberOfBytesOfOrder = Encoding.ASCII.GetByteCount(order);

            //    fileStream.Write(bytesOfOrder, 0, numberOfBytesOfOrder);
            //}

            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(pathOfTheFile, FileMode.Open);

                var bytesOfOrder = Encoding.ASCII.GetBytes(order);
                var numberOfBytesOfOrder = Encoding.ASCII.GetByteCount(order);

                fileStream.Write(bytesOfOrder, 0, numberOfBytesOfOrder);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Dispose();
                }
            }

        }
    }
}
