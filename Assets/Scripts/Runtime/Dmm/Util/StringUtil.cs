﻿using System;

namespace Dmm.Util
{
    public class StringUtil
    {
        public static bool AreEqual(string str1, string str2)
        {
            if (str1 == null || str2 == null)
                return false;

            return str1.Equals(str2);
        }

        /// <summary>
        /// 检查是否是汉字名
        /// </summary>
        /// <returns></returns>
        public static bool CheckIsChineseName(string name)
        {
            name = name.Trim();
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            //汉字验证
            if (!CheckStringChinese(name))
            {
                return false;
            }

            //名字长度验证
            if (name.Length <= 1 || name.Length >= 6)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 用ASCII码范围判断字符是不是汉字，汉字的ASCII码大于127
        /// </summary>
        /// <returns></returns>
        public static bool CheckStringChinese(string text)
        {
            for (var i = 0; i < text.Length; i++)
            {
                if ((int) text[i] <= 127)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 身份证验证
        /// </summary>
        /// <param name="Id">身份证号</param>
        /// <returns></returns>
        public static bool CheckIDCard(string Id)
        {
            Id = Id.Trim();
            if (Id.Length == 18)
            {
                bool check = CheckIDCard18(Id);
                return check;
            }
            else if (Id.Length == 15)
            {
                bool check = CheckIDCard15(Id);
                return check;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 15位身份证验证
        /// </summary>
        /// <param name="Id">身份证号</param>
        /// <returns></returns>
        public static bool CheckIDCard15(string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false; //数字验证
            }
            string address =
                "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false; //省份验证
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false; //生日验证
            }
            return true; //符合15位身份证标准
        }

        /// <summary>
        /// 18位身份证验证
        /// </summary>
        /// <param name="Id">身份证号</param>
        /// <returns></returns>
        public static bool CheckIDCard18(string Id)
        {
            long n = 0;
            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) ||
                long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false; //数字验证
            }
            string address =
                "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false; //省份验证
            }
            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false; //生日验证
            }
//            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
//            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
//            char[] Ai = Id.Remove(17).ToCharArray();
//            int sum = 0;
//            for (int i = 0; i < 17; i++)
//            {
//                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
//            }
//            int y = -1;
//            Math.DivRem(sum, 11, out y);
//            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
//            {
//                return false; //校验码验证
//            }
            return true;
        }
    }
}