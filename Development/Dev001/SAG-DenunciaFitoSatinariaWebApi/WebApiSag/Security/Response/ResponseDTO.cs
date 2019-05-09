using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSag.Security.Response
{
    public class ResponseDTO
    {
        public int Code { get; set; }
        public string Message { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="Message"></param>
        public ResponseDTO(int Code, string Message)
        {
            this.Code = Code;
            this.Message = Message;
        }

        public ResponseDTO()
        {
        }
    }
}