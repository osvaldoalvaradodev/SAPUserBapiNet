using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPUserBapiNet
{
    public class DestinationConfiguration : IDestinationConfiguration
    {
        private List<ConfigParameters> configParametersList;

        public DestinationConfiguration(List<ConfigParameters> configParameters)
        {
            this.configParametersList = configParameters;
        }

        public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged;

        public bool ChangeEventsSupported()
        {
            return true;
        }

        public RfcConfigParameters GetParameters(string destinationName)
        {
            ConfigParameters configParameters = this.configParametersList.Single(cp => cp.DestinationName.Equals(destinationName));
            RfcConfigParameters rfcConfigParameters = new RfcConfigParameters();
            rfcConfigParameters.Add(RfcConfigParameters.AppServerHost, configParameters.AppServerHost);
            rfcConfigParameters.Add(RfcConfigParameters.SystemNumber, configParameters.SystemNumber);
            rfcConfigParameters.Add(RfcConfigParameters.User, configParameters.User);
            rfcConfigParameters.Add(RfcConfigParameters.Password, configParameters.Password);
            rfcConfigParameters.Add(RfcConfigParameters.Client, configParameters.Client);
            rfcConfigParameters.Add(RfcConfigParameters.Language, configParameters.Language);
            return rfcConfigParameters;
        }
    }
}
