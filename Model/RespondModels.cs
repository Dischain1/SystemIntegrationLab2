using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class RespondAndDataList<T>
    {
        [DataMember]
        public Respond Respond { get; set; }

        [DataMember]
        public List<T> Data { get; set; }

        public RespondAndDataList()
        {
            Data = new List<T>();
        }
    }

    [DataContract]
    public class Respond
    {
        public static Respond CreateOkRespond()
        {
            return new Respond()
            {
                Succeded = true,
                ErrorMessage = null
            };
        }

        public static Respond CreateErrorRespond(string errorMessage)
        {
            return new Respond()
            {
                Succeded = false,
                ErrorMessage = errorMessage
            };
        }

        [DataMember]
        public bool Succeded { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
    }
}
