using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertDataIntoDB.Model
{
    class Students
    {
        public int id { get; set; }
        public string Ename { get; set; }
        public DateTime dob { get; set; }
        public string _image { get; set; }
        public string contact { get; set; }

        //After get set please do compile/bulid
        //ctrl + shift + b
    }
}
