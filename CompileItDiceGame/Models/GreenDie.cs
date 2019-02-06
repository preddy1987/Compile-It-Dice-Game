using System;
using System.Collections.Generic;
using System.Text;

namespace CompileIt
{
    [Serializable]
    public class GreenDie : Die
    {
        public GreenDie() : base(DieType.Green)
        {

        }

        protected override void CreateDie()
        {
            _dieSides.Add(CompileType.Error);
            _dieSides.Add(CompileType.Warning);
            _dieSides.Add(CompileType.Warning);
            _dieSides.Add(CompileType.Success);
            _dieSides.Add(CompileType.Success);
            _dieSides.Add(CompileType.Success);
        }
    }
}
