namespace NodeBase
{
    public class IntAttr
    {

        private IntAttrUI _attrui;
        /// <summary>
        /// 唯一标识名
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 属性显示名
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 属性默认值
        /// </summary>
        public int DefaultValue { get; set; }

        /// <summary>
        /// 属性是否要显示在Node面板中
        /// </summary>
        public bool DisplayOnNode { get; set; }

        /// <summary>
        /// 组件属性设置显示ui
        /// </summary>
        /// <param name="stringAttrUI">匹配的ui控件</param>
        public void SetUi(IntAttrUI intAttrui)
        {
            this._attrui = intAttrui;
        }

        /// <summary>
        /// 通知Ui组件更新空间内容
        /// </summary>
        /// <param name="content"></param>
        public void UpdateUiContent(int content)
        {
            this.DefaultValue = content;

            if (this._attrui != null)
            {
                this._attrui.IntUIContent = content.ToString();
            }
        }
    }
}