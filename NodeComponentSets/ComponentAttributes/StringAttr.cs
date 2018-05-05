namespace NodeComponentSets
{
    /// <summary>
    /// 字符串属性类
    /// </summary>
    public class StringAttr
    {
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
    }
}