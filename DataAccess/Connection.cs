using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DataAccess
{
    public class Connection
    {
        public NewsDBEntities Entity { get; set; }

        public Connection()
        {
            Entity = new NewsDBEntities();
        }
    }
}
