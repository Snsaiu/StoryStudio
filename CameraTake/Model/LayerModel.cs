using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CameraTake.Model
{
    /// <summary>
    /// 图层模型
    /// </summary>
   public  class LayerModel:NotificationObject
    {
        /// <summary>
        /// 图层透明度
        /// </summary>
        private int _transparency;

        public int Transparentcy
        {
            get { return _transparency; }
            set { _transparency = value;this.RaisePropertyChanged(() => this.Transparentcy); }
        }
        /// <summary>
        /// 图层可编辑
        /// </summary>
        private bool _CanEdit;

        public bool CanEdit
        {
            get { return _CanEdit; }
            set { _CanEdit = value;this.RaisePropertyChanged(() => this.CanEdit); }
        }

        /// <summary>
        /// 图层索引号
        /// </summary>
        private int _index;

        public int Index
        {
            get { return _index; }
            set { _index = value; this.RaisePropertyChanged(() => this.Index); }
        }

        /// <summary>
        /// 图层
        /// </summary>
        private InkCanvas   _inkcanvas;

        public InkCanvas InkCanvas
        {
            get { return _inkcanvas; }
            set { _inkcanvas = value; this.RaisePropertyChanged(() => this.InkCanvas); }
        }

        /// <summary>
        /// 所属分镜ID
        /// </summary>
        private int _takeId;

        public int TakeId
        {
            get { return _takeId; }
            set { _takeId = value; this.RaisePropertyChanged(() => this.TakeId); }
        }

        /// <summary>
        /// 图层缩略图
        /// </summary>
        private InkCanvas _thumbnail;

        public InkCanvas Thumbnail
        {
            get { return _thumbnail; }
            set { _thumbnail = value; this.RaisePropertyChanged(() => this.Thumbnail); }
        }





    }
}
