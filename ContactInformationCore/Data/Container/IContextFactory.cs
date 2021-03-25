using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInformationCore.Data.Container
{
    public interface IContextFactory
    {
        ContactInfoDbContext GetContaxt();
    }
}
