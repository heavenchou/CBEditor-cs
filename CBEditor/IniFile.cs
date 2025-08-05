using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;

namespace CBEditor
{
    public class IniFile
    {
        string FileName;

        // 這是輸入為 utf8 , 輸出是 ANSI
        // [DllImport("kernel32", CharSet = CharSet.Unicode)] 
        // static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);
        // [DllImport("kernel32", CharSet = CharSet.Unicode)]
        // static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);



        [DllImport("kernel32")]
        static extern long WritePrivateProfileString(string Section, string Key, byte[] Value, string FilePath);
        [DllImport("kernel32")]
        static extern int GetPrivateProfileString(string Section, string Key, byte[] Default, byte[] RetVal, int Size, string FilePath);

        public IniFile(string file)
        {
            FileName = file;
        }
        // 轉成 utf8
        private static byte[] u8(string s)
        {
            return null == s ? null : Encoding.GetEncoding("utf-8").GetBytes(s);
        }
        public string ReadString(string Section, string Key, string Default)
        {
            // ANSI 的版本
            //var RetVal = new StringBuilder(255);
            //GetPrivateProfileString(Section, Key, Default, RetVal, 255, FileName);
            //return RetVal.ToString();

            byte[] buffer = new byte[1024];
            int count = GetPrivateProfileString(Section, Key, u8(Default), buffer, 255, FileName);
            string result = Encoding.GetEncoding("utf-8").GetString(buffer, 0, count);
            
            // 移除換行符號和Tab但保留其他空白字元（包括全形空白）
            return result.Replace("\r\n", "").Replace("\r", "").Replace("\n", "").Replace("\t", "");
        }
        public int ReadInteger(string Section, string Key, int Default)
        {
            string s = ReadString(Section, Key, Default.ToString());
            return Convert.ToInt32(s);
        }
        public float ReadFloat(string Section, string Key, float Default)
        {
            string s = ReadString(Section, Key, Default.ToString());
            return (float)Convert.ToDouble(s);
        }
        public bool ReadBool(string Section, string Key, bool Default)
        {
            string s = ReadString(Section, Key, Default == true ? "1" : "0");
            return s == "1";
        }

        public void WriteString(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, u8(Value), FileName);
        }
        public void WriteInteger(string Section, string Key, int Value)
        {
            WritePrivateProfileString(Section, Key, u8(Value.ToString()), FileName);
        }
        public void WriteFloat(string Section, string Key, float Value)
        {
            WritePrivateProfileString(Section, Key, u8(Value.ToString()), FileName);
        }
        public void WriteBool(string Section, string Key, bool Value)
        {
            string b = Value == true ? "1" : "0";
            WritePrivateProfileString(Section, Key, u8(b), FileName);
        }

        public void DeleteKey(string Section , string Key)
        {
            WriteString(Section, Key, null);
        }

        public void DeleteSection(string Section)
        {
            WriteString(Section, null, null);
        }

        public bool KeyExists(string Section, string Key)
        {
            return ReadString(Section, Key, "").Length > 0;
        }
    }
}
