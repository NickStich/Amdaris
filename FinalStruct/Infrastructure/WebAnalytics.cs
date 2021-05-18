using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class WebAnalytics
    {
        public int Id { get; set; }
        public DateTime RequestTime { get; set; }
        public string RequestURL { get; set; }
        public string IPAdress { get; set; }
        public bool IsRequestAuthenticated { get; set; }
        public int? RequestLength { get; set; }
        public string BrowserType { get; set; }
        public string BrowserName { get; set; }
        public string BrowserVersion { get; set; }
    }
}
