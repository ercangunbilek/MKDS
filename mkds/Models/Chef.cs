using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mkds.Models
{
    public class Chef:User

    {
        public string branch;

        public Chef(string name,string branch)
        {
            this.branch = branch;
            this.name = name;
        }
    }
}