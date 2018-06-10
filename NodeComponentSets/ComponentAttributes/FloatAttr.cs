using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeBase
{
  public class FloatAttr
    {
        private FloatAttrUI _attrui;

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
        public float DefaultValue { get; set; }

        /// <summary>
        /// 属性是否要显示在Node面板中
        /// </summary>
        public bool DisplayOnNode { get; set; }

        public void SetUi(FloatAttrUI floatAttrUI)
        {
            this._attrui = floatAttrUI;
        }

        /// <summary>
        /// 通知Ui组件更新空间内容
        /// </summary>
        /// <param name="content"></param>
        public void UpdateUiContent(float content)
        {
            this.DefaultValue = content;

            if (this._attrui != null)
            {
                this._attrui.FloatUIContent = content.ToString();
            }
        }

    }
}
