using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace PC_CodeComparison
{
    public static class NorvayConfig
    {
        //指示灯停顿时间 默认：50 单位 毫秒
        public static uint SampSleep = 50;

        //对码 > 一组闪烁间隔时间 默认：50 单位 毫秒
        public static uint CodeSleep = 50;

        //清码 > 一组闪烁间隔时间 默认：10 单位 毫秒
        public static uint ClearCodeSleep = 10;

        public static void InitNorvayCode()
        {
            try
            {
                var sampSleepStr = ConfigurationManager.AppSettings["SampSleep"];
                var codeSleepStr = ConfigurationManager.AppSettings["CodeSleep"];
                var clearCodeSleepStr = ConfigurationManager.AppSettings["ClearCodeSleep"];
                
                SampSleep = Convert.ToUInt32(sampSleepStr);
                CodeSleep = Convert.ToUInt32(codeSleepStr);
                ClearCodeSleep = Convert.ToUInt32(clearCodeSleepStr);
            }
            catch (Exception)
            {
                
            }
           

        }
    }
}
