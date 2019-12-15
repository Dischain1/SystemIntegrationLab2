using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class ResponceAndDataList<T>
    {
        [DataMember]
        public Responce Responce { get; set; }

        [DataMember]
        public List<T> Data { get; set; }

        public ResponceAndDataList()
        {
            Data = new List<T>();
        }
    }

    [DataContract]
    public class Responce
    {
        public static Responce CreateOkRespond()
        {
            return new Responce()
            {
                Succeded = true,
                ErrorMessage = null
            };
        }

        public static Responce CreateErrorRespond(string errorMessage)
        {
            return new Responce()
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
