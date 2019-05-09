using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApiSag.Models.Response
{
    public class DynamicResponse
    {
            public HeaderResponse header { get; set; }
            public int statusCode { get; set; }
            public BodyResponse response { get; set; }
            public ErrorResponse error { get; set; }
        
    }
}