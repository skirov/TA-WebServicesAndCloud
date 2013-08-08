using System;
using System.ServiceModel;

namespace _01.DateTimeService
{
    [ServiceContract]
    public interface IServiceDatetime
    {

        [OperationContract]
        string GetWeekDay(DateTime date);
    }
}
