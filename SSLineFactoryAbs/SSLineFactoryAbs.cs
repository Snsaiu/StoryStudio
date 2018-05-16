namespace SSLineFactoryAbs
{
    /// <summary>
    /// 创建节点之间的连线的抽象类
    /// </summary>
    public abstract class SSLineFactoryAbs
    {
        /// <summary>
        /// 创建角色节点之间的线样式
        /// </summary>
        /// <returns></returns>
        public abstract SSLine.ArrowBase CreateCharacterLine();

        /// <summary>
        /// 创建事件节点之间的线样式
        /// </summary>
        /// <returns></returns>
        public abstract SSLine.ArrowBase CreateEventLine();

 
    }
}
