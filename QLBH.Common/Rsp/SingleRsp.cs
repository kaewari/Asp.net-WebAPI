using System;
using System.Collections.Generic;
using System.Text;

namespace QLBH.Common.Rsp
{
    public class SingleRsp : BaseRsp
    {
        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        public SingleRsp() : base() { }

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="message">Message</param>
        public SingleRsp(string message) : base(message) { }

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="titleError">Title error</param>
        public SingleRsp(string message, string titleError) : base(message, titleError) { }

        /// <summary>
        /// Set data
        /// </summary>
        /// <param name="code">Success code</param>
        /// <param name="data">Data</param>
        public void SetData(string code, object data)
        {
            Code = code;
            Data = data;
        }
        /// <summary>
        /// Set token
        /// </summary>
        /// <param name="token">token</param>
        public void SetToken(string token)
        {
            Token = token;
        }
        #endregion

        #region -- Properties --

        /// <summary>
        /// Data
        /// </summary>
        public object Data { get; set; }
        public string Token { get; set; }
        #endregion
    }
}