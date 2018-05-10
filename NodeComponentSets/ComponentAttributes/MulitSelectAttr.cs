using System.Collections.Generic;

namespace NodeBase
{
    public class MulitSelectAttr
    {

        #region Fields

        private List<string> _value;

        /// <summary>
        /// 存储控件
        /// </summary>
        private MulitSelectAttrUI _ui = null;

        #endregion



        #region Properties

        /// <summary>
        /// string多选列表
        /// </summary>
        public List<string> Value
        {
            get { return _value; }
            set { _value = value; }
        }


        /// <summary>
        /// 唯一标识名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 属性显示名
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 属性列表索引列表
        /// </summary>
        public List<string> DefaultItems { get=>this._ui.MulitListUIContent; set; }

        /// <summary>
        /// 属性是否要显示在Node面板中
        /// </summary>
        public bool DisplayOnNode { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// 添加ui控件实例
        /// </summary>
        /// <param name="ui">ui控件实例</param>
        public void SetUi(MulitSelectAttrUI ui)
        {
            this._ui = ui;
        }

        /// <summary>
        /// 设置新的内容并更新组件,如果组件存在
        /// </summary>
        /// <param name="content">更新内容</param>
        public void UpdateUiContent(List<string> content)
        {
            this.DefaultItems = content;
            if (this._ui != null)
            {
                this._ui.MulitListUIContent = content;
            }
        }

        #endregion
    }
}