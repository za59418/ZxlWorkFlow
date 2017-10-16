using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Zxl.Business.Model;
using Zxl.Business.Interface;
using Zxl.Business.Impl;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Zxl.Data;

namespace Zxl.Builder
{
    public partial class businessProcessCtrl : UserControl
    {

        public IBusinessService BusinessService = new BusinessService();

        public businessProcessCtrl()
        {
            InitializeComponent();
        }

        private SYS_BUSINESSPROCESS _currProcess;
        public SYS_BUSINESSPROCESS CurrProcess
        {
            get
            {
                return _currProcess;
            }
            set
            {
                _currProcess = value;
            }
        }
    }
}
