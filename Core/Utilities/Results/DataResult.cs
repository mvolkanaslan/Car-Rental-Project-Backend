using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    /*
    Değer döndüren bir operasyonu döndürdüğü değerle birlikte
    Result değerleri yani true/false ve bir mesaj döndüren bir katman olarak kullanacağız.
    Burada hali hazırda bir result prop larını döndüren bir katmanımız olduğu için o katmandan
    kalıtım alıp bu isSuccees ve Message işlemlerini de kullanmış olacağız.
    Bu katman default olarak kendiene ait olan Data prop unu barındıracak
     */


    /*
     * BU sınıfı new leyen katmanın artık Data,IsSuccess,Message olarak 3 propertisi olmuş olacak.
     */
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data,bool isSuccess,string message):base(isSuccess,message)
        {
            Data = data;
        }
        public DataResult(T data,bool isSuccess):base(isSuccess)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
