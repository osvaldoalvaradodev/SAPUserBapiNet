using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAP.Middleware.Connector;

namespace SAPUserBapiNet
{
    public class Test
    {
        public Test()
        {
            ConfigParameters configParameters = new ConfigParameters();
            configParameters.DestinationName = "100@DEV";
            configParameters.AppServerHost = "hostname.to.server.com";
            configParameters.SystemNumber = "00";
            //Usuario con privilegios para cambiar passwords.
            configParameters.User = "USERNAME";
            configParameters.Password = "password";
            configParameters.Client = "100";
            configParameters.Language = "ES";
            List<ConfigParameters> configParametersList = new List<ConfigParameters>();
            configParametersList.Add(configParameters);
            UserManager userManager = new UserManager(configParametersList);
            //Usuario a cambiar contraseña.
            string randomPassword = userManager.ChangePassword("100@DEV", "username");
        }
    }
}
