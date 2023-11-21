using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;

namespace IFix
{
    public class WrapperMethod : IEquatable<WrapperMethod>
    {
        public List<TypeReference> Parameters { get; private set; } = new List<TypeReference>();

        public List<bool> Ins { get; private set; } = new List<bool>();
        public List<bool> Outs { get; private set; } = new List<bool>();

        public TypeReference ReturnType { get; private set; }

        public MethodDefinition Method { get; set; }

        public MethodBody Body => Method.Body;

        public void AddParameter(bool isIn, bool isOut, TypeReference wrapperType)
        {
            Ins.Add(isIn);
            Outs.Add(isOut);
            Parameters.Add(wrapperType);
        }

        public void FinalReturn(TypeReference returnType)
        {
            ReturnType = returnType;
        }

        //TODO body writer

        public override int GetHashCode()
        {
            int code = Parameters.Count;

            for (int i = 0; i < Parameters.Count; ++i)
            {
                code += Parameters[i].Name.GetHashCode();
                code += (Ins[i] ? 1 : 0) * 2;
                code += (Outs[i] ? 1 : 0);
            }

            code += ReturnType.Name.GetHashCode();

            return code;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj as WrapperMethod);
        }

        public bool Equals(WrapperMethod other)
        {
            if (other == null)
                return false;
            if (!ReturnType.IsSameType(other.ReturnType))
                return false;
            if (Parameters.Count != other.Parameters.Count)
                return false;
            for (int i = 0; i < Parameters.Count; ++i)
            {
                if (Ins[i] !=  other.Ins[i])
                    return false;
                if (Outs[i] != other.Outs[i])
                    return false;
                if (!Parameters[i].IsSameType(other.Parameters[i]))
                    return false;
            }
            return true;
        }
    }
}