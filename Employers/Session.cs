using Employers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employers
{
    public class Session
    {
        private Session() 
        {
            context =new MyWorkersContext();
        }
        private static Session? instance;
        public static Session Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Session();
                }
                return instance;
            }
        }
        private MyWorkersContext context;
        public MyWorkersContext Context => context;
    }
}