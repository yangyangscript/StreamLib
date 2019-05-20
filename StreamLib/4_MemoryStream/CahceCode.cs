using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StreamLib._4_MemoryStream
{
    public class CahceCode
    {
        private HttpClient _client;

        public CahceCode()
        {
            _client = new HttpClient();
        }

        /// <summary>
        /// 时间戳
        /// </summary>
        /// <returns></returns>
        private long Timestamp_second()
        {
            return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }

        public System.IO.Stream GetCode()
        {
            var ret = _client.GetAsync($"https://yn.122.gov.cn/captcha?nocache={Timestamp_second()}");
            return ret.Result.Content.ReadAsStreamAsync().Result;
        }
    }
}
