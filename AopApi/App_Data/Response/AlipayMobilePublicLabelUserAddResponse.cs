using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayMobilePublicLabelUserAddResponse.
    /// </summary>
    public class AlipayMobilePublicLabelUserAddResponse : AopResponse
    {
        /// <summary>
        /// 结果码
        /// </summary>
        [XmlElement("code")]
#pragma warning disable CS0108 // 'AlipayMobilePublicLabelUserAddResponse.Code' hides inherited member 'AopResponse.Code'. Use the new keyword if hiding was intended.
        public string Code { get; set; }
#pragma warning restore CS0108 // 'AlipayMobilePublicLabelUserAddResponse.Code' hides inherited member 'AopResponse.Code'. Use the new keyword if hiding was intended.

        /// <summary>
        /// 结果信息
        /// </summary>
        [XmlElement("msg")]
#pragma warning disable CS0108 // 'AlipayMobilePublicLabelUserAddResponse.Msg' hides inherited member 'AopResponse.Msg'. Use the new keyword if hiding was intended.
        public string Msg { get; set; }
#pragma warning restore CS0108 // 'AlipayMobilePublicLabelUserAddResponse.Msg' hides inherited member 'AopResponse.Msg'. Use the new keyword if hiding was intended.
    }
}
