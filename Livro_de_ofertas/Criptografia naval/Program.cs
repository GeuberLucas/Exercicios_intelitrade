using System;
using System.Collections.Generic;
using System.Text;

namespace Criptografia_naval
{
    class Program
    {
        static void Main(string[] args)
        {
            var mensagem = "10010110 11110111 01010110 00000001 00010111 00100110 01010111 00000001 00010111 01110110 01010111 00110110 11110111 11010111 01010111 00000011";
            var arrbit = mensagem.Split(" ");
            StringBuilder response = new StringBuilder();
            for(var i=0;i< arrbit.Length; i++)
            {
                List<Byte> listByte = new List<byte>();
                var splitIndex =new StringBuilder().Append( arrbit[i]);
                splitIndex[6] = splitIndex[6] == '0' ? '1' : '0';
                splitIndex[7] = splitIndex[7] == '0' ? '1' : '0';
                arrbit[i] = $"{splitIndex[4]}{splitIndex[5]}{splitIndex[6]}{splitIndex[7]}{splitIndex[0]}{splitIndex[1]}{splitIndex[2]}{splitIndex[3]}";
                listByte.Add(Convert.ToByte(arrbit[i], 2));
                response.Append(Encoding.ASCII.GetString(listByte.ToArray()));
            }

            Console.WriteLine(response);
        }
    }
}
