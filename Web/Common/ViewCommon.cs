using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Common
{
    public static class ViewCommon
    {
        public static Services.Data.DatabaseEntities DataEntiyies
        {
            get
            {
                return Services.Database.Entiyies;
            }
        }
    }
}