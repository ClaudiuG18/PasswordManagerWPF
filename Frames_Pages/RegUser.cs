using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frames_Pages
{
    public class RegUser
    {
        string username;
        string password;

      

        public string Username
        {
            get { return this.username; }
            set { this.username = value; }  
        }
        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }
    }
}
