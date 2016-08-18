using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDatabase.Common
{
    public class Error
    {
        public static class ErrorCode
        {
            public static int UNKNOWN_DATABASE = 1;
            public static int UNKNOWN_SERVER = 2;
            public static int ACCESS_DENIED = 3;
        }

        public static class ErrorMessage
        {
            public static string UNKNOWN_DATABASE = "找不到数据库";
            public static string UNKNOWN_Server = "找不到数据库服务器";
            public static string ACCESS_DENIED = "账号密码错误";
        }
    }
}
