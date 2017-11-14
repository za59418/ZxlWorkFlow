using System;
using System.Collections.Generic;
using System.Text;

namespace FormDesigner.Attribute
{
    public class ValidatesAttribute : IControlAttribute
    {
        #region Variables
        private string _id;
        private string _validate;
        #endregion

        #region Constructors
        public ValidatesAttribute(string controlId,string validate)
        {
            this._id = controlId;
            this._validate = validate;
        }
        #endregion

        #region Properties
        public string ControlId
        {
            get
            {
                return _id;
            }
        }

        

        public string Validate
        {
            get
            {
                return _validate;
            }
        }
        #endregion

        #region Methods
        public string GetValidate(string controlId)
        {
            return this._validate;
        }
        #endregion
    }
}
