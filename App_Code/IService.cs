using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
//using System.ServiceModel;
//using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.

    public interface IService
    {

        //[OperationContract]
        DataSet GetData(string sql);

        //[OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        //[OperationContract]
        DataSet GetSelectData(string storedprocedure, DataIUD[] IUD);

        //[OperationContract]
        string GetInsertUpdateData(string storedprocedure, DataIUD[] IUD);

        //[OperationContract]
        DataSet GetParameterlessSelectData(string storedprocedure);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        //[DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        //[DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }




    }

    //[DataContract]
    public class DataIUD
    {

        private string paraname;
        //[DataMember]
        public string Paraname
        {
            get { return paraname; }
            set { paraname = value; }
        }
        private string paravalue;
        //[DataMember]
        public string Paravalue
        {
            get { return paravalue; }
            set { paravalue = value; }
        }

        private string paratype;
        //[DataMember]
        public string Paratype
        {
            get { return paratype; }
            set { paratype = value; }
        }
    }
