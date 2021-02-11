using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    /*
     Bu katman operasyonlar ile birlikte işlemin başarılı olup olmadığını 
     ve beraberine bir mesajı bildirimi yapan bir katmandır.
     */
    public interface IResult
    {
        /*Bir değer döndürmeyen bir işlem yapan operasyonlarda 
         * sadece bu iki properti döndürülür.
         * */
        bool IsSuccess { get; }
        string Message { get; }
    }
}
