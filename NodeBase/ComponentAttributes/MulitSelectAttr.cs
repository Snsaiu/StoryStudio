using System.Collections.Generic;

namespace NodeBase
{
    public class MulitSelectAttr
    {
        private List<string> _value;

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
        public List<int> DefaultIndexs { get; set; }

        /// <summary>
        /// 属性是否要显示在Node面板中
        /// </summary>
        public bool DisplayOnNode { get; set; }
    }
}