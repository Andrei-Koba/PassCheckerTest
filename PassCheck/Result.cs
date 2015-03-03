using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassCheck
{
    public class Result
    {
        public bool Success { get; set; }
        public string Mess { get; set; }

        public Result(bool success, string mess)
        {
            Success = success;
            Mess = mess;
        }

        public override bool Equals(object obj)
        {
            Result res = obj as Result;
            if (res == null) return false;
            return Equals(res);
        }

        private bool Equals(Result obj)
        {
            if (Success != obj.Success) return false;
            if (Mess != obj.Mess) return false;
            return true;
        }
    }
}
