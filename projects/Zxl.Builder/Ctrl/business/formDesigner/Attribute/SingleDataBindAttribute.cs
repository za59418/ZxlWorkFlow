using System;
using System.Collections.Generic;
using System.Text;

namespace FormDesigner.Attribute
{
    public class SingleDataBindAttribute : DataBindAttribute
    {
        //private string id;
        private string CtrlValue;
        private string formatter;
        private bool isInputFormatter = false;
        private bool isPrintFormatter = false;
        private string datasource;
        private string datarequired;
        private string requiredMessage;
        private string defaultValue;

        public SingleDataBindAttribute(string controlId)
        {
            id = controlId;
        }

        public string Id
        {
            get { return id; }
        }
        public string Value
        {
            get
            { return CtrlValue; }
            set
            { CtrlValue = value; }
        }

        public string DataRequired
        {
            get
            {
                return datarequired;
            }
            set
            {
                datarequired = value;
            }
        }

        public string Formatter
        {
            get
            {
                return formatter;
            }
            set
            {
                formatter = value;
            }
        }

        public bool IsInputFormatter
        {
            get
            {
                return isInputFormatter;
            }
            set
            {
                isInputFormatter = value;
            }
        }

        public bool IsPrintFormatter
        {
            get
            {
                return isPrintFormatter;
            }
            set
            {
                isPrintFormatter = value;
            }
        }

        public string Datasource
        {
            get
            {
                return datasource;
            }
            set
            {
                datasource = value;
            }
        }

        public string RequiredMessage
        {
            get
            {
                return requiredMessage;
            }
            set
            {
                requiredMessage = value;
            }
        }

        public string DefaultValue
        {
            get
            {
                return defaultValue;
            }
            set {
                defaultValue = value;
            }
        }
    }
}
