using System;
using System.Collections.Generic;
using System.Text;

namespace CompileIt
{
    [Serializable]
    public class YellowDie : Die
    {
        public YellowDie() : base(DieType.Yellow)
        {

        }

        protected override void CreateDie()
        {
            _dieSides.Add(CompileType.Error);
            _dieSides.Add(CompileType.Error);
            _dieSides.Add(CompileType.Warning);
            _dieSides.Add(CompileType.Warning);
            _dieSides.Add(CompileType.Success);
            _dieSides.Add(CompileType.Success);
        }
    }
}
