using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frames_Pages
{
   public class UserData
    {
        string username;
        string password;
        string app;

        public string Username
        {
            get { return username; }
            set { this.username = value;}
        }

        public string Password
        {
            get { return password; }
            set { this.password = value; }
        }

        public string Application
        {
            get { return app; }
            set { this.app = value; }
        }

        
    }
}
