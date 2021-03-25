using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInformationCore.Data.Container
{
    public class ContextFactory : IContextFactory
    {
        string _ConString = String.Empty;
        public ContactInfoDbContext GetContaxt()
        {
            if (String.IsNullOrEmpty(_ConString))
            {
                _ConString = Common.GetConnetionString();
            }
            return new ContactInfoDbContext(_ConString);
        }
    }
}
