using System.Collections.Generic;

namespace NodeBase
{
    public class ListAttr
    {

        private ListAttrUI _attrui;


        private List<string> _value;

        /// <summary>
        /// string列表
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
        /// 属性列表索引值
        /// </summary>
        public int DefaultIndex { get; set; }

        /// <summary>
        /// 属性是否要显示在Node面板中
        /// </summary>
        public bool DisplayOnNode { get; set; }

        public void SetUi(ListAttrUI intAttrui)
        {
            this._attrui = intAttrui;
        }

        public void UpdateIndex(int index)
        {
            this.DefaultIndex = index;
            if (this._attrui!=null)
            {
                this._attrui.DefaultIndex = index;
            }
        }

        public void UpdateList(List<string> list)
        {
            this.Value = list;
            if (this._attrui!=null)
            {
                this._attrui.ListUIContent = list;
            }
        }
    }
}