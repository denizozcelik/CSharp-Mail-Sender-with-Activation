using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMail.SingletonPattern
{
    using Models;
    public class DBTool
    {
        private DBTool() { }

        private static MyContext _dbInstance;

        public static MyContext DBInstance
        {
            get
            {

                if (_dbInstance == null)
                {

                    _dbInstance = new MyContext();
                }

                return _dbInstance;

            }
        }


    }
}