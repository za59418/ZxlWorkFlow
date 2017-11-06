using System;
using System.Collections.Generic;
using System.Text;

namespace FormDesigner.Attribute
{
    public class GridColumnAttribute
    {
        #region Variables
        private string ctrlValue;
        private string input;
        private string datasource;
        private string description;
        private string defaultValue;
        #endregion

        #region Properties

        public string DefaultValue
        {
            get { return defaultValue; }
            set {
                defaultValue = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public string Value
        {
            get
            {
                return ctrlValue;
            }
            set
            {
                ctrlValue = value;
            }
        }

        public string Input
        {
            get
            {
                return input;
            }
            set
            {
                input = value;
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

        #endregion
    }
}
