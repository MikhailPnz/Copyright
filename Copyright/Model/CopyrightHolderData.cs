using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copyright.Model
{
    internal class CopyrightHolderData : ICopyrightHolderData
    {
        public IEnumerable<CopyrightHolder> GetAllCopyrightHolders()
        {
            throw new NotImplementedException();
        }

        public CopyrightHolder GetCopyrightHolder(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveCopyrightHolder(int id, CopyrightHolder author)
        {
            throw new NotImplementedException();
        }
    }
}
