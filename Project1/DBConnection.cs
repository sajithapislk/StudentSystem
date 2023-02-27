using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class DBConnection
    {
        public string GetConnection()
        {
            string conn = @"Data Source=APIS;Initial Catalog=SkillsInternationalSchool;Persist Security Info=True;User ID=sa;Password=1235789";
            return conn;

            //In C#, the "@" symbol is used before a string literal to indicate that the string should be treated as a "verbatim string literal".

            //When you use a regular string literal, the backslashes() in the string are treated as escape characters.For example, when you use the following code:

            //string conn = "Data Source=APIS;Initial Catalog=SkillsInt";
            //            The backslash in "Data Source=APIS;Initial Catalog=SkillsInt" would be treated as an escape character, which would cause an error.

            //However, when you use a verbatim string literal, the backslashes are treated as literal characters and are not processed as escape characters.For example, the following code:

            //string conn = @"Data Source=APIS;Initial Catalog=SkillsInt";
            //            Will create a string with the value Data Source = APIS; Initial Catalog = SkillsInt and will not cause any errors.

            //So, in this case, the "@" symbol is used to indicate that the string should be treated as a verbatim string literal, allowing the backslashes in the string to be treated as literal characters rather than escape characters.
        }
    }
}
