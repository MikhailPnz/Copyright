using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copyright.Model
{
    public interface ICopyrightHolderData
    {
        IEnumerable<CopyrightHolder> GetAllCopyrightHolders();

        CopyrightHolder GetCopyrightHolder(int id);

        void SaveCopyrightHolder(int id, CopyrightHolder author);
    }
}
