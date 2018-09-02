using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceManager.Models
{
    public enum MessageLevel
    {
        ERROR,
        WARNING,
        SUCCESS,
        INFO
    }

    public enum ActionEnum
    {
        ADD,
        EDIT,
        DELETE,
        NONE
    }
}