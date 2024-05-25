using System;
using System.Globalization;
using System.Text;

namespace PS4_Cheater {
    public partial class MemoryHelper {
        static string hex_to_string(byte[] bytes) {
            return BitConverter.ToString(bytes).Replace("-", "");
        }

        static string string_to_string(Byte[] value) {
            return Encoding.Default.GetString(value);
        }

        static string double_to_string(Byte[] value) {
            return BitConverter.ToDouble(value, 0).ToString();
        }
        static string float_to_string(Byte[] value) {
            return BitConverter.ToSingle(value, 0).ToString();
        }
        static string ulong_to_string(Byte[] value) {
            return BitConverter.ToUInt64(value, 0).ToString();
        }
        static string uint_to_string(Byte[] value) {
            return BitConverter.ToUInt32(value, 0).ToString();
        }
        static string uint16_to_string(Byte[] value) {
            return BitConverter.ToUInt16(value, 0).ToString();
        }
        static string uchar_to_string(Byte[] value) {
            return value[0].ToString();
        }
        static string double_to_hex_string(Byte[] value) {
            return BitConverter.ToUInt64(value, 0).ToString("X16");
        }
        static string float_to_hex_string(Byte[] value) {
            return BitConverter.ToUInt32(value, 0).ToString("X8");
        }
        static string ulong_to_hex_string(Byte[] value) {
            return BitConverter.ToUInt64(value, 0).ToString("X16");
        }
        static string uint_to_hex_string(Byte[] value) {
            return BitConverter.ToUInt32(value, 0).ToString("X8");
        }
        static string uint16_to_hex_string(Byte[] value) {
            return BitConverter.ToUInt16(value, 0).ToString("X4");
        }
        static string uchar_to_hex_string(Byte[] value) {
            return value[0].ToString("X2");
        }
        static string hex_to_hex_string(byte[] bytes) {
            return BitConverter.ToString(bytes).Replace("-", "");
        }

        static string string_to_hex_string(Byte[] value) {
            return BitConverter.ToString(value).Replace("-", "");
        }

        static byte[] string_to_double(string value) {
            return BitConverter.GetBytes(double.Parse(value));
        }
        static byte[] string_to_float(string value) {
            return BitConverter.GetBytes(float.Parse(value));
        }
        static byte[] string_to_8_bytes(string value) {
            return BitConverter.GetBytes(ulong.Parse(value));
        }

        static byte[] string_to_4_bytes(string value) {
            return BitConverter.GetBytes(uint.Parse(value));
        }

        static byte[] string_to_2_bytes(string value) {
            return BitConverter.GetBytes(UInt16.Parse(value));
        }
        static byte[] string_to_byte(string value) {
            return BitConverter.GetBytes(Byte.Parse(value));
        }
        public static byte[] string_to_hex_bytes(string hexString) {
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        static byte[] string_to_string_bytes(string hexString) {
            byte[] buffer = System.Text.Encoding.Default.GetBytes(hexString);
            return buffer;
        }

        static byte[] hex_string_to_double(string value) {
            return BitConverter.GetBytes(double.Parse(value, NumberStyles.HexNumber));
        }
        static byte[] hex_string_to_float(string value) {
            return BitConverter.GetBytes(float.Parse(value, NumberStyles.HexNumber));
        }
        static byte[] hex_string_to_8_bytes(string value) {
            return BitConverter.GetBytes(ulong.Parse(value, NumberStyles.HexNumber));
        }

        static byte[] hex_string_to_4_bytes(string value) {
            return BitConverter.GetBytes(uint.Parse(value, NumberStyles.HexNumber));
        }

        static byte[] hex_string_to_2_bytes(string value) {
            return BitConverter.GetBytes(UInt16.Parse(value, NumberStyles.HexNumber));
        }
        static byte[] hex_string_to_byte(string value) {
            return BitConverter.GetBytes(Byte.Parse(value, NumberStyles.HexNumber));
        }
    }
}
