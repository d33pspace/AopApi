using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Aop.Api;
using Aop.Api.Request;
using Aop.Api.Response;

namespace AopApi
{
    public class AopService : IAopService
    {
        private string GATEWAY = "https://openapi.alipaydev.com/gateway.do";
        private string APPID = "2016080500170137";
        private string APP_PRIVATE_KEY = "MIIEowIBAAKCAQEAu64L4u8dKSqL/wZCN0INDGohyPcSRDEXfywO41p+yOY7+usi8mprErJ46WMv/mtmpotLZKDKumj8KnA+esfXh7si+UfkZXGG4K05yBeDmaGaZHH++SkV/mCH06J0W7+Oj87FncSbQ405jHGvttU1fehsNcvMCPM2P+AU616s9WxzPxVqZ4BcfokiR5GafdGRcuXokDVciL52IuAMUNCNn+mAD6hQ1l9nZ1Uf/eepQE8Dqs24YyhJi9G3JhifvcuDgjfIW1LQdDf2YwBBdPC+0ROMEw9JKpM9dLPNd3+AQiUndwLBbXuuCHvu54Mbe3Ewb6yUFBSIYrXdhcaxu1l36QIDAQABAoIBAHM+rbfdIqfro2mnOzPZUE/mP/a6mLHc/1OtBztej2nnzr8GckAvTq59fze5G3h8FN2BvXr+LV6IJwgcQpF8c4G6TQCLv9j2/F6soEWZAsts63Rwd6QiMYoxVlaDdDX+i5kM3FZDqx+w8bym9sIrbBxzgzcJfLGmPxK8E7xwN36/2ntH80V3Xkx0McwmDJy+Z05Q2JF3LD24x4H6djopZd2BXIgdcTyDbYic/MdCoVkxXgJ+JhnUbonIzIxNIQKOU/qS9eHRFHXtppWNAkdbej6YAF0LmrKdpiJNVfomuISGszM4GJJh9eSa6MplOVcO5f2YRFLtJgUXASe6TntWpfECgYEA7WOyzcXFkGiHp/nM19nu+LVnKTk9JaP/7vE6fdOM8ycRWHS+Yk/Aoj/NELQScvz/LaumxUYfOi0IL7D8Ro8LALB8rpXJogRuCPfNhkLyWn7Wriez7bDIxUI5mWcNywxPPoPubgxyNUPr9yPEPEanloiXZRBHNoVb1w9RCUSXDdUCgYEAymSy21iAA2/u4CP5uFlMVBI4lRktUiVwaMGi26rsAeOjKHRbmB0OPwgG2GuO48Hd0E9+u4pvQLul7CnWwM+kJ7GHsrGS/SR52pGasIgFFiioi7lYFtd47MaStJ4lMHDeGUibHiaKfBDWFiagW7CT9KALOoi2kmlsE8QaddlPB8UCgYEA1fBu+UHOnimGcF0RPkrbMmuR8DX0pJKbmgTu+O0J7yz7VePInKNRcSfcsLwIkHbvpoI3Bzz98ZkZ8pknkpNhkBp+E31MvWYOoKhrIh/9eI8s/MEtR/51wki/zj9wz9hlJmsSGz2+Q8DVzOH//W6TpHevMVatRzaCoVvdZWPaWo0CgYAecAZ19llKKwtBqidkEgnomtTnl2G5eOfu2TAk2Q+lORbQfq9HsRbzY8Gjyokyt3UkXtAwZCFXGuFZIvGpDZEiZxCBTzNL3rB0rnEVG1+odXTjjnww8za8ZSCrCR2Oq2q7Yq/xWNp6zg1kR2rWXzfhEjCeHPFYE4KtdlCEaKn6AQKBgD4JxJgmDT4E6/7xFxGdXuw3/D6ksHksv2VZVr/0xEPl70sE+Vy8rO6vIJ0uBIv43QXBfwf8pXSMrPyA2IgdfhBqT86jG1gKfN7V218s1KeHyNbSEmfXeIDPKld0i4e0AgJNOgO4RO+LTS/63gBH7kIB6fXVzolRI80sCWWzYAD9";
        private string ALIPAY_PUBLIC_KEY = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAu64L4u8dKSqL/wZCN0INDGohyPcSRDEXfywO41p+yOY7+usi8mprErJ46WMv/mtmpotLZKDKumj8KnA+esfXh7si+UfkZXGG4K05yBeDmaGaZHH++SkV/mCH06J0W7+Oj87FncSbQ405jHGvttU1fehsNcvMCPM2P+AU616s9WxzPxVqZ4BcfokiR5GafdGRcuXokDVciL52IuAMUNCNn+mAD6hQ1l9nZ1Uf/eepQE8Dqs24YyhJi9G3JhifvcuDgjfIW1LQdDf2YwBBdPC+0ROMEw9JKpM9dLPNd3+AQiUndwLBbXuuCHvu54Mbe3Ewb6yUFBSIYrXdhcaxu1l36QIDAQAB";
        private string CHARSET = "UTF-8";
        private string NOTIFY_URL = "http://alipay.renewal365.org/notify";
        private string RETURN_URL = "http://alipay.renewal365.org/success"; 
        private string TOKEN = "json";
        public string SIGNTYPE = "RSA2";

        string IAopService.PagePay(string content)
        {
            IAopClient client = new DefaultAopClient(GATEWAY, APPID, APP_PRIVATE_KEY, TOKEN, "1.0", SIGNTYPE, ALIPAY_PUBLIC_KEY, CHARSET, false);
            var request = new AlipayOpenPublicTemplateMessageIndustryModifyRequest();
            request.SetNotifyUrl(NOTIFY_URL);
            request.SetReturnUrl(RETURN_URL);
            request.BizContent = content;
            var response = client.Execute<AlipayOpenPublicTemplateMessageIndustryModifyResponse>(request);
            return response.ToString();
        }

        string IAopService.Auth(string content)
        {
            throw new NotImplementedException();
        }

        string IAopService.Refund(string content)
        {
            throw new NotImplementedException();
        }

        string IAopService.Close(string content)
        {
            throw new NotImplementedException();
        }

        string IAopService.Query(string content)
        {
            throw new NotImplementedException();
        }

        string IAopService.RefundQuery(string content)
        {
            throw new NotImplementedException();
        }

        string IAopService.DownloadURLQuery(string content)
        {
            throw new NotImplementedException();
        }

        string IAopService.Check(string content)
        {
            throw new NotImplementedException();
        }
    }
}
