using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace whnXX.Controllers
{
    [Route("api/shoudongapi")]
    //[Controller]
    public class WhnClass : Controller
    {
        // WhnClassController
        // 添加get 方法
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
