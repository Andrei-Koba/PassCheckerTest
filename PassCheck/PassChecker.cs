using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PassCheck
{

    public interface IRepository
    {
        int CreateUser(string pass, string userName, bool isAdmin);
    }

    public class PassChecker
    {
        public IRepository Repository;

        public PassChecker(IRepository repository)
        {
            Repository = repository;
        }

        public Result Verify(string pass, string userName, bool isAdmin)
        {
            Regex isDigit = new Regex(@"\d");
            Regex isCaracter = new Regex(@"\w");
            if (userName == null || userName.Length == 0) return new Result(false, "Bad username");
            if (!Regex.Match(pass, @"\d").Success) return new Result(false, "Pass should contain at least one digit");
            if (!Regex.Match(pass, "[A-z]").Success) return new Result(false, "Pass should contain at least one alphabetical character");
            if (isAdmin)
            {
                if (pass.Length < 10) return new Result(false, "Admin pass should have 10 character lenght");
                if (!Regex.Match(pass, @"\W").Success) return new Result(false, "Admin pass should contain at least one spesial character");
            }
            else
            {
                if (pass.Length < 7) return new Result(false, "Pass should have 7 character lenght");
            }
            Repository.CreateUser(pass, userName, isAdmin);
            return new Result(true, "OK");
        }
    }
}
