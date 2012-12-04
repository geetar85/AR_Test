using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.WebHost;

namespace AR_test
{
    public class CustomWebHostBufferPolicySelector : WebHostBufferPolicySelector
    {
        public override bool UseBufferedInputStream(object hostContext)
        {
            System.Web.HttpContextBase contextBase = hostContext as System.Web.HttpContextBase;
 
            if (contextBase != null
                && contextBase.Request.ContentType != null
                && contextBase.Request.ContentType.Contains("multipart"))
            {
                // we are enabling streamed mode here
                return false;
            }
            // let the default behavior(buffered mode) to handle the scenario
            return base.UseBufferedInputStream(hostContext);
        }
    }
}