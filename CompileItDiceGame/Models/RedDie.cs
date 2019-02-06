using System;
using System.Collections.Generic;
using System.Text;

namespace CompileIt
{
    [Serializable]
    public class RedDie : Die
    {
        public RedDie() : base(DieType.Red)
        {

        }

        protected override void CreateDie()
        {
            _dieSides.Add(CompileType.Error);
            _dieSides.Add(CompileType.Error);
            _dieSides.Add(CompileType.Error);
            _dieSides.Add(CompileType.Warning);
            _dieSides.Add(CompileType.Warning);
            _dieSides.Add(CompileType.Success);
        }
    }
}
