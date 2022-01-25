﻿
using System.Collections.Generic;

namespace Copyright.View
{
    public interface ICopyrightView
    {
        void Order(string order);
        void Notification(string message);        
        void Notification(string message1, string message2);        
        Presenter.CopyrightPresenter Presenter { set; }
    }
}
