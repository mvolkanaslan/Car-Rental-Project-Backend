using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        /*Result sınıfı Constructor ı hem iki parametreli 
        hem de tek paametreli çağırılma durumna karşılık aşağıdaki yapı oluşturuldu.
        Method iki parametreli oalrak  çağırıldığında ":this(isSuccess)" ile tek parametreli constructor ı 
        da çalıştırmış oluyor. Diğer durumda sadece tek parametreli olarak method çağırıldığında
        sadee tek parametreli constructor çalııyor. 
         */
        public Result(bool isSuccess,string message):this(isSuccess)
        {
            Message = message;
        }
        public Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
        public bool IsSuccess { get; }

        public string Message { get; }
    }
}
