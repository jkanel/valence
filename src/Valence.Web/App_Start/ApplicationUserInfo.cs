using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Valence.Commands;

namespace Valence.Web
{
    /// <summary>
    /// Holds application level user information.
    /// </summary>
    public class ApplicationUserInfo
    {
        public ApplicationUserInfo() { }

        public ApplicationUserInfo(ApplicationActions Actions, string DisplayName)
        {
            this.SetApplicationInfo(Actions, DisplayName);
        }

        public ApplicationActions ApplicationActions { get; set; }
        public string DisplayName { get; set; }

        public void SetApplicationInfo(ApplicationActions Actions, string DisplayName)
        {
            this.ApplicationActions = Actions;
            this.DisplayName = DisplayName;
        }

    }
}