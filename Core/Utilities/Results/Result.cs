using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results;

public class Result : IResult
{
    //: this(success) diyerek dedik ki bü üsteki const çalışınca aşagıdaki de çalışsın
    public Result(bool success, string message) : this(success)
    {
        Message = message;
        //Success = success;
    }

    public Result(bool success)
    {
        Success = success;
    }

    public bool Success { get; }


    public string Message { get; }
}
