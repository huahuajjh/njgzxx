using Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class Database
    {
        private static string key = "Key";

        public static DatabaseEntities Entiyies
        {
            get
            {
                var data = CallContext.GetData(key) as DatabaseEntities;
                if (data == null)
                {
                    data = new DatabaseEntities();
                    CallContext.SetData(key, data);
                }
                return data;
            }
        }
    }
}
