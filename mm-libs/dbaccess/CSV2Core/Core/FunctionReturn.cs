using System;

namespace CSV2Core.Core
{
    //CSV2Core.Core.FR_Status
    public enum FR_Status
    {
        Success = 200,
        Error_Internal = 500,
        Error_Serialization = 501,
        Error_Security = 502,
    }

    //[Obsolete("This class is deprecated and should not be used anymore.", false)]
    public class FR_Base
    {
        [System.ComponentModel.DefaultValue(FR_Status.Success)]
        private FR_Status _Status { get; set; }
        public string ErrorMessage { get; set; }
        public long RowsUpdated { get; set; }


        public FR_Status Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }


        public FR_Base() {
            Status = FR_Status.Success;
            ErrorMessage = "";
            RowsUpdated = 0;
        }
        /// <summary>
        /// Class constructor used to return the status of the operation
        /// Uses the exeption to postback results, as InternalError
        /// </summary>
        /// <param name="ex"></param>
        public FR_Base(Exception ex)
        {
            this.ErrorMessage = ex.Message;
            this.Status = FR_Status.Error_Internal;
            this.RowsUpdated = 0;
        }

        /// <summary>
        /// Class constructor used to return status of the operation
        /// it implements .NET default constructors, so most of the parameters are optional
        /// </summary>
        /// <param name="Message">String message to show to the user</param>
        /// <param name="Status">Status, from the FR_Status enumeration</param>
        /// <param name="RowsUpdated">Rows that were updated with this execution</param>
        /// <param name="Ex">Execution that occured during this execution (if any)</param>
        public FR_Base(string Message="", FR_Status Status = FR_Status.Success, long RowsUpdated = 0, Exception Ex=null)
        {
            this.ErrorMessage = Message;
            this.Status = Status;
            this.RowsUpdated = RowsUpdated;
        }

        //Change to CreateFromStatus();
        public static FR_Base Status_OK
        {
            get
            {
                return new FR_Base("Status Executed Successfully");
            }
        }

        public static FR_Base CreateFromException(Exception ex)
        {
            return new FR_Base(ex.Message, FR_Status.Error_Internal, 0, ex);
        }


    }


    #region Standard Return Types
    /// <summary>
    /// Guid
    /// </summary>
    public class FR_Guid : FR_Base
    {
        public Guid Result = default(Guid);
    
        public FR_Guid() { }

        public FR_Guid(Exception ex) : base(ex) { }

        public FR_Guid(FR_Base baseClass, Guid resultId)
        {
            this.Status = baseClass.Status;
            this.RowsUpdated = baseClass.RowsUpdated;
            this.ErrorMessage = baseClass.ErrorMessage;
            this.Result = resultId;
        }

        public FR_Guid(Guid Result)
        {
            this.Status = FR_Status.Success;
            this.Result = Result;
        }

        public FR_Guid(string errorMessage, FR_Status status) : base(errorMessage, status) { }
      

    }
    /// <summary>
    /// Guid array
    /// </summary>
    public class FR_Guids : FR_Base
    {
        public Guid[] Result = default(Guid[]);

        public FR_Guids() { }

        public FR_Guids(Exception ex) : base(ex) { }

         public FR_Guids(string errorMessage, FR_Status status) : base(errorMessage, status) { }

        public FR_Guids(Guid[] Result)
        {
            this.Status = FR_Status.Success;
            this.Result = Result;
        }

    }
    /// <summary>
    /// Boolean
    /// </summary>
    public class FR_Bool : FR_Base
    {
        public bool Result = default(bool);

        public FR_Bool() { }

        public FR_Bool(Exception ex) : base(ex) { }

        public FR_Bool(string errorMessage, FR_Status status) : base(errorMessage, status) { }

        public FR_Bool(bool Result)
        {
            this.Status = FR_Status.Success;
            this.Result = Result;
        }

    }

    /// <summary>
    /// Boolean array
    /// </summary>
    public class FR_Bools : FR_Base
    {
        public bool[] Result = default(bool[]);

        public FR_Bools() { }

        public FR_Bools(Exception ex) : base(ex) { }

        public FR_Bools(string errorMessage, FR_Status status) : base(errorMessage, status) { }

        public FR_Bools(bool[] Result)
        {
            this.Status = FR_Status.Success;
            this.Result = Result;
        }

    }

    /// <summary>
    /// Date Time 
    /// </summary>
    public class FR_DateTime : FR_Base
    {
        public DateTime Result = default(DateTime);

        public FR_DateTime() { }

        public FR_DateTime(Exception ex) : base(ex) { }

        public FR_DateTime(string errorMessage, FR_Status status) : base(errorMessage, status) { }

        public FR_DateTime(DateTime Result)
        {
            this.Status = FR_Status.Success;
            this.Result = Result;
        }

    }

    /// <summary>
    /// DateTime Array
    /// </summary>
    public class FR_DateTimes : FR_Base
    {
        public DateTime[] Result = default(DateTime[]);

        public FR_DateTimes() { }

        public FR_DateTimes(Exception ex) : base(ex) { }

        public FR_DateTimes(string errorMessage, FR_Status status) : base(errorMessage, status) { }

        public FR_DateTimes(DateTime[] Result)
        {
            this.Status = FR_Status.Success;
            this.Result = Result;
        }

    }

    /// <summary>
    /// Integer
    /// </summary>
    public class FR_Int : FR_Base
    {
        public int Result = default(int);

        public FR_Int() { }

        public FR_Int(Exception ex) : base(ex) { }

        public FR_Int(string errorMessage, FR_Status status) : base(errorMessage, status) { }

        public FR_Int(int Result)
        {
            this.Status = FR_Status.Success;
            this.Result = Result;
        }

    }

    /// <summary>
    /// Integers
    /// </summary>
    public class FR_Ints : FR_Base
    {
        public int[] Result = default(int[]);

        public FR_Ints() { }

        public FR_Ints(Exception ex) : base(ex) { }

        public FR_Ints(string errorMessage, FR_Status status) : base(errorMessage, status) { }

        public FR_Ints(int[] Result)
        {
            this.Status = FR_Status.Success;
            this.Result = Result;
        }

    }


    /// <summary>
    /// Standard fuction return double
    /// </summary>
    public class FR_Double : FR_Base
    {
        public double Result = default(double);

        public FR_Double() { }

        public FR_Double(Exception ex) : base(ex) { }

        public FR_Double(string errorMessage, FR_Status status) : base(errorMessage, status) { }

        public FR_Double(double Result)
        {
            this.Status = FR_Status.Success;
            this.Result = Result;
        }
    }

    /// <summary>
    /// Standard fuction return double
    /// </summary>
    public class FR_Doubles : FR_Base
    {
        public double[] Result = default(double[]);

        public FR_Doubles() { }

        public FR_Doubles(Exception ex) : base(ex) { }

        public FR_Doubles(string errorMessage, FR_Status status) : base(errorMessage, status) { }

        public FR_Doubles(double[] Result)
        {
            this.Status = FR_Status.Success;
            this.Result = Result;
        }
    }




    /// <summary>
    /// Standard fuction return str
    /// </summary>
    public class FR_String : FR_Base
    {
        public string Result = default(string);

        public FR_String() { }

        public FR_String(Exception ex) : base(ex) { }

        public FR_String(string errorMessage, FR_Status status) : base(errorMessage, status) { }

        public FR_String(string Result)
        {
            this.Status = FR_Status.Success;
            this.Result = Result;
        }
    }


    /// <summary>
    /// Standard fuction return str
    /// </summary>
    public class FR_Strings : FR_Base
    {
        public string[] Result = default(string[]);

        public FR_Strings() { }

        public FR_Strings(Exception ex) : base(ex) { }

        public FR_Strings(string errorMessage, FR_Status status) : base(errorMessage, status) { }

        public FR_Strings(string[] Result)
        {
            this.Status = FR_Status.Success;
            this.Result = Result;
        }
    }


    #endregion

}
