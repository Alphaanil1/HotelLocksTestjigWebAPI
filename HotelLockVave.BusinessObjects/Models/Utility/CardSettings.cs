
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLockVave.BusinessObjects.Models.Utility
{
    public static class CardSettings
    {

        public static ushort Crc16CcittXModem(byte[] bytes)
        {
            if (bytes == null) return 0;

            const ushort poly = 4129;
            ushort[] table = new ushort[256];
            ushort initialValue = 0x0000;
            ushort temp, a;
            ushort crc = initialValue;
            for (int i = 0; i < table.Length; ++i)
            {
                temp = 0;
                a = (ushort)(i << 8);
                for (int j = 0; j < 8; ++j)
                {
                    if (((temp ^ a) & 0x8000) != 0)
                        temp = (ushort)((temp << 1) ^ poly);
                    else
                        temp <<= 1;
                    a <<= 1;
                }
                table[i] = temp;
            }
            for (int i = 0; i < bytes.Length; ++i)
            {
                crc = (ushort)((crc << 8) ^ table[((crc >> 8) ^ (0xff & bytes[i]))]);
            }
            return crc;
        }

        public static string CalculateCRCC(string strcardDetails)
        {
            string asciinput = strcardDetails;  // FrameSubString;

            // Convert string to byte 
            Encoding ascii = Encoding.ASCII;
            Byte[] asciibytes = ascii.GetBytes(asciinput);

            string asci = Crc16CcittXModem(asciibytes).ToString("x2", CultureInfo.InvariantCulture);
            string CCRC_Code = asci.ToUpper(CultureInfo.CurrentCulture);

            //Append 0 to CRCC Code lenght is < 4.
            int Length1 = CCRC_Code.Length;
            int j11 = 0;
            if (Length1 <= 4)
            {
                for (int i = 0; i < (4 - Length1); i++)
                {
                    CCRC_Code = '0' + CCRC_Code;
                    j11++;
                }
            }
            return CCRC_Code;
        }
        public static string CalculateCRCCOfHex(string strcardDetails)
        {
            // Convert hexstring to byte
            Byte[] bytes = HexToBytes(strcardDetails);
            string asci = Crc16CcittXModem(bytes).ToString("x2", CultureInfo.InvariantCulture);
            string CCRC_Code = asci.ToUpper(CultureInfo.CurrentCulture);

            //Append 0 to CRCC Code lenght is < 4.
            int Length1 = CCRC_Code.Length;
            int j11 = 0;
            if (Length1 <= 4)
            {
                for (int i = 0; i < (4 - Length1); i++)
                {
                    CCRC_Code = '0' + CCRC_Code;
                    j11++;
                }
            }
            return CCRC_Code;
        }
        static byte[] HexToBytes(string input)
        {
            byte[] result = new byte[input.Length / 2];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Convert.ToByte(input.Substring(2 * i, 2), 16);
            }
            return result;
        }
        //public string CalculateCRCCInHex(string strcardDetails)
        //{           
        //    string asciinput = strcardDetails;  // FrameSubString;

        //    // Convert string to byte             
        //    Encoding ascii = Encoding.ASCII;
        //    Byte[] asciibytes = ascii.GetBytes(asciinput);

        //    string asci = Crc16CcittXModem(asciibytes).ToString("x2");
        //    string CCRC_Code = asci.ToUpper();

        //    //Append 0 to CRCC Code lenght is < 4.
        //    int Length1 = CCRC_Code.Length;
        //    int j11 = 0;
        //    if (Length1 <= 4)
        //    {
        //        for (int i = 0; i < (4 - Length1); i++)
        //        {
        //            CCRC_Code = '0' + CCRC_Code;
        //            j11++;
        //        }
        //    }           

        //    return CCRC_Code;
        //}

        //    public string ReadData()
        //    {
        //        string tmpStr;
        //        int indx;

        //        validATS = false;
        //        ClearBuffers();
        //        SendBuff[0] = 0xFF;
        //        SendBuff[1] = 0xCA;

        //        //if (cbIso14443A.Checked)
        //        //{

        //            SendBuff[2] = 0x01;
        //        //}

        //        //else
        //        //{

        //        //    SendBuff[2] = 0x00;

        //        //}

        //        SendBuff[3] = 0x00;
        //        SendBuff[4] = 0x00;

        //        SendLen = SendBuff[4] + 5;
        //        RecvLen = 0xFF;

        //        retCode = SendAPDUandDisplay(3);

        //        if (retCode != SCARD_S_SUCCESS)
        //        {
        //            return "fail";
        //        }


        //        // Interpret and display return values
        //        tmpStr = "";
        //        if (validATS)
        //        {
        //            //if (cbIso14443A.Checked)
        //            //{
        //               tmpStr = "UID: ";
        //            //}

        //            for (indx = 0; indx <= (RecvLen - 3); indx++)
        //            {

        //                tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);

        //            }
        //            //displayOut(3, 0, tmpStr.Trim());               
        //        }
        //        return tmpStr;
        //    }
        //}


        //public class Crc16
        //{
        //    const ushort polynomial = 0xA001;
        //    ushort[] table = new ushort[256];

        //    //public ushort ComputeChecksum(byte[] bytes)
        //    //{
        //    //    ushort crc = 0;
        //    //    for (int i = 0; i < bytes.Length; ++i)
        //    //    {
        //    //        byte index = (byte)(crc ^ bytes[i]);
        //    //        crc = (ushort)((crc >> 8) ^ table[index]);
        //    //    }
        //    //    return crc;
        //    //}

        //    //public byte[] ComputeChecksumBytes(byte[] bytes)
        //    //{
        //    //    ushort crc = ComputeChecksum(bytes);
        //    //    return new byte[] { (byte)(crc >> 8), (byte)(crc & 0x00ff) };
        //    //}

        //    //public Crc16()
        //    //{
        //    //    ushort value;
        //    //    ushort temp;
        //    //    for (ushort i = 0; i < table.Length; ++i)
        //    //    {
        //    //        value = 0xffff;
        //    //        temp = i;
        //    //        for (byte j = 0; j < 8; ++j)
        //    //        {
        //    //            if (((value ^ temp) & 0x0001) != 0)
        //    //            {
        //    //                value = (ushort)((value >> 1) ^ polynomial);
        //    //            }
        //    //            else
        //    //            {
        //    //                value >>= 1;
        //    //            }
        //    //            temp >>= 1;
        //    //        }
        //    //        table[i] = value;
        //    //    }
        //    //}

        //    //public ushort ComputeCRC16(byte[] data)
        //    //{
        //    //    ushort crc = 0xffff;
        //    //    for (int i = 0; i < data.Length; i++)
        //    //    {
        //    //        crc = (ushort)(crc ^ data[i]);
        //    //        for (int j = 0; j < 8; j++)
        //    //        {
        //    //            if ((crc & 0x0001) != 0)
        //    //                crc = (ushort)((crc >> 1) ^ 0xa001);
        //    //            else
        //    //                crc = (ushort)(crc >> 1);
        //    //        }
        //    //    }
        //    //    return crc;
        //    //}


        //}

    }
}
