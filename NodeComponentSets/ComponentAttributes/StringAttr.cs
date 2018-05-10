namespace NodeBase
{
    /// <summary>
    /// 字符串属性类
    /// </summary>
    public class StringAttr
    {


        #region Fields

        private StringAttrUI _attrui = null;
        #endregion

        #region Properties
     
        /// <summary>
        /// 唯一标识名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 是否启动面积更大的文本输入框
        /// </summary>
        public bool HasContent { get; set; }
        /// <summary>
        /// 属性显示名
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 属性默认值
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 属性是否要显示在Node面板中
        /// </summary>
        public bool DisplayOnNode { get; set; }

        #endregion


        #region Methods

        /// <summary>
        /// 组件属性设置显示ui
        /// </summary>
        /// <param name="stringAttrUI">匹配的ui控件</param>
        public void SetUi(StringAttrUI stringAttrUI)
        {
            this._attrui = stringAttrUI;
        }

        /// <summary>
        /// 通知Ui组件更新空间内容
        /// </summary>
        /// <param name="content"></param>
        public void UpdateUiContent(string content)
        {
            this.DefaultValue = content;

            if (this._attrui!=null)
            {
                this._attrui.StrUIContent = content;
            }
        }

        #endregion
    }
}