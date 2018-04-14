namespace NodeBase
{
    public class IntAttr
    {
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
    }
}