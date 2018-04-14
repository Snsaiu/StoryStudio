namespace NodeBase
{
    /// <summary>
    /// bool 属性类
    /// </summary>
    public class BoolAttr
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
        public bool DefaultValue { get; set; }

        /// <summary>
        /// 属性是否要显示在Node面板中
        /// </summary>
        public bool DisplayOnNode { get; set; }

    }
}