using System;
using System.Collections.Generic;

using System.Text;


namespace LazyPressClick
{
   public class ProgramSetting
    {
       /// <summary>
       ///是否按住Alt
       /// </summary>
       public bool IsPressAlt {get;set; }
       /// <summary>
       /// 按键速度
       /// </summary>
       public double ClickSpeed { get; set; }
       /// <summary>
       /// 0左键还是 1右键
       /// </summary>
       public bool LeftOrRight { get; set; }


    }
}
