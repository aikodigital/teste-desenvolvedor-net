using System.Runtime.Serialization;

namespace SharedKernel.Application.Result
{
    [DataContract]
    public class ResultApi<T>
    {
        [DataMember(Name = "success")]
        public bool Success { get; set; }

        [DataMember(Name = "data")]
        public T Data { get; set; }
    }
}
