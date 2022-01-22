using Copyright.Model;
using Copyright.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copyright.Presenter
{
    public class CopyrightPresenter
    {
        private readonly ICopyrightView _view;
        private readonly ICopyrightHolderData _data;

        public CopyrightPresenter(ICopyrightView view, ICopyrightHolderData data)
        {
            _view = view;
            view.Presenter = this;
            _data = data;
        }

    }
}
