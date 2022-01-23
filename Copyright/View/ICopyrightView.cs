
using System.Collections.Generic;

namespace Copyright.View
{
    public interface ICopyrightView
    {
        void notification(string message);        
        void notification(string message1, string message2);
        //IList<string> CopyrightHolderList { get; set; }
        Presenter.CopyrightPresenter Presenter { set; }
    }
}
