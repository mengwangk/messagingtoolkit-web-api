using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MessagingToolkit.Service.Common
{
    [DataContract]
    public class ServiceFault
    {
        public ServiceFault Inner { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string Source { get; set; }

        [DataMember]
        public string Target { get; set; }

        public override string ToString()
        {
            if (null == Inner)
                return string.Format("Target: {0} / Source: {1} / Message: {2}", Target, Source, Message);
            else
                return string.Format("Target: {0} / Source: {1} / Message: {2}{3}/ Inner: {4}", Target, Source, Message, Environment.NewLine, Inner.ToString());
        }
    }

    public static class ServiceFaultFactory
    {
        public static ServiceFault CreateServiceFault(Exception ex)
        {
            ServiceFault fault = new ServiceFault() { Message = ex.Message, Source = ex.Source, Target = ex.TargetSite.ToString() };
            if (null != ex.InnerException)
            {
                ServiceFault wrapper = fault;
                Exception te = ex.InnerException;
                while (null != te)
                {
                    wrapper.Inner = new ServiceFault() { Message = te.Message, Source = te.Source, Target = te.TargetSite.ToString() };
                    te = te.InnerException;
                    wrapper = wrapper.Inner;
                }
            }
            return fault;
        }
    }
}
