using System;
using System.Collections.Generic;
using System.Text;

namespace EODHistoricalData.NET
{
    public abstract class AuthentifiedClient
    {
        protected string _apiToken;

        public AuthentifiedClient(string apiToken)
        {
            _apiToken = apiToken;
        }
    }
}
