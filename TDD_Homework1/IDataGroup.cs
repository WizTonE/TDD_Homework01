using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Homework1
{
    public interface IDataGroup
    {
        List<int> GetDataByGroup(decimal groupnumber, object orderObject);
    }
}
