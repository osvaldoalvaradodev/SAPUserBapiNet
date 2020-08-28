using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SAPUserBapiNet
{
    public class UserManager
    {
        public UserManager(List<ConfigParameters> configParametersList)
        {
            RfcDestinationManager.RegisterDestinationConfiguration(new DestinationConfiguration(configParametersList));
        }

        public string ChangePassword(string destinationName, string username)
        {
            try
            {
                RfcDestination rfcDestination = RfcDestinationManager.GetDestination(destinationName);
                RfcRepository rfcRepository = rfcDestination.Repository;
                IRfcFunction rfcFunction = rfcRepository.CreateFunction("BAPI_USER_CHANGE");
                rfcFunction.Invoke(rfcDestination);
                rfcFunction.SetValue("Username", username);
                string randomString = RandomString.Generate();
                rfcFunction.GetStructure("Password").SetValue("BAPIPWD", randomString);
                rfcFunction.GetStructure("Passwordx").SetValue("BAPIPWD", "X");
                rfcFunction.Invoke(rfcDestination);
                return randomString;
            }

            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
