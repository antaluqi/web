using System;
using WWW16pu;
using Common;
using System.Text.RegularExpressions;
namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            String userStr=Comm.TxTRead(@"./用户.txt");
            string username = Regex.Matches(userStr, @"(?<=用户名：)\d+")[0].Value;
            string password = Regex.Matches(userStr, @"(?<=密码：)\d+")[0].Value;
            //Console.WriteLine("用户名："+ username+ "\n密码:"+ password);

            // www16pu pu = new www16pu("18658131087", "198221");
            //www16pu pu = new www16pu("15988166652", "615919");
           www16pu pu = new www16pu(username, password);
            string logInfo="";
            bool log = pu.Login(ref logInfo);
           // bool log = pu.LoginFromCookie(ref logInfo);
            Console.WriteLine(logInfo);

            /*
            MemberInfo memberInfo= pu.Member();
            List<TzlbInfo> tzlbInfo= pu.MemberTzlb();
            List<PdetailInfo> pdetailInfo= pu.Touzi();

            Console.WriteLine("==============================================\n基本信息：>>>>>>>>>\n");
              Console.WriteLine(memberInfo.ToString());
            Console.WriteLine("==============================================\n已投资列表：>>>>>>>\n");
               www16pu.InfoListView(tzlbInfo);
            Console.WriteLine("==============================================\n可投标的：>>>>>>>>>\n");
               www16pu.InfoListView(pdetailInfo);
            */

            //Console.WriteLine(pu.Buy(1000, "13178"));
            pu.AutoBuy();

            Console.WriteLine("按任意键退出");
            Console.Read();
        }
    }

}

